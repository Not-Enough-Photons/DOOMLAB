using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using NEP.DOOMLAB.WAD.DataTypes;
using UnityEditor;
using UnityEngine;

namespace NEP.DOOMLAB.Rendering
{
    public class DoomSpriteRenderer : MonoBehaviour
    {
        public MobjType mobjType;

        public DoomGame game;

        public Mobj mobj;

        [SerializeField] private MeshRenderer meshRenderer;
        private SpriteDef[] spriteDefs;

        private Camera camera;

        private Shader litShader;
        private Shader unlitShader;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            mobj = GetComponentInParent<Mobj>();
            spriteDefs = SpriteLumpGenerator.sprites;

            litShader = Shader.Find("Lit.shader");
            unlitShader = Shader.Find("Unlit.shader");
        }

        private void Start()    
        {
            spriteDefs = SpriteLumpGenerator.sprites;

            DoomGame.OnTick += UpdateSprite;
        }

        private void OnDestroy()
        {
            DoomGame.OnTick -= UpdateSprite;
        }

        public void UpdateSprite()
        {
            if(spriteDefs == null)
            {
                spriteDefs = SpriteLumpGenerator.sprites;
                return;
            }

            camera = Camera.main;
            float angle = Vector3.SignedAngle(mobj.transform.forward, camera.transform.forward, Vector3.up);

            angle = Mathf.Repeat(angle + 180f, 360f) - 180f;

            int index = (int)((angle - (45 / 2) * 9) / 45) & 7;

            int stateFrame = mobj.frame;

            if(mobj.frame >= 32768)
            {
                stateFrame = mobj.frame - 32768;
                // meshRenderer.material.shader = unlitShader;
            }
            else
            {
                // meshRenderer.material.shader = litShader;
            }

            SpriteDef spriteDef = spriteDefs[(int)mobj.sprite];
            SpriteFrame spriteFrame = spriteDef.GetFrame(stateFrame);
            
            float spriteWidth = (spriteFrame.patches[index].width / 10f + (mobj.info.radius / 32f)) / 10f;
            float spriteHeight = (spriteFrame.patches[index].height / 10f + (mobj.info.height / 32f)) / 10f;

            if (!spriteFrame.canRotate)
            {
                meshRenderer.material.mainTexture = spriteFrame.patches[0].output;
                transform.localScale = new Vector3(-spriteWidth, spriteHeight, -1);

                return;
            }

            if(index >= spriteFrame.numRotations)
            {
                int rotation = 8 - index;
                int invertScale = spriteFrame.flipBits[rotation] ? -1 : 1;

                meshRenderer.material.mainTexture = spriteFrame.patches[rotation].output;
                transform.localScale = new Vector3(invertScale * spriteWidth, spriteHeight, -1f);
            }
            else
            {
                meshRenderer.material.mainTexture = spriteFrame.patches[index].output;
                transform.localScale = new Vector3(spriteWidth, spriteHeight, -1);
            }
        }
    }
}
