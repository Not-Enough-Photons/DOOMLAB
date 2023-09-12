using MelonLoader;
using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Entities;
using NEP.DOOMLAB.Game;

using UnityEngine;

namespace NEP.DOOMLAB.Rendering
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjRenderer : MonoBehaviour
    {
        public MobjRenderer(System.IntPtr ptr) : base(ptr) { }

        public MobjType mobjType;

        public DoomGame game;

        public Mobj mobj;

        private MeshRenderer meshRenderer;
        private static SpriteDef[] spriteDefs;

        private Camera camera;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            mobj = GetComponentInParent<Mobj>();
            game = DoomGame.Instance;
            camera = Camera.main;
        }

        private void Start()    
        {
            DoomGame.Instance.OnTick += UpdateSprite;
        }

        private void OnEnable()
        {
            LoadSpriteDefs();
            UpdateSprite();
        }

        private void OnDestroy()
        {
            DoomGame.Instance.OnTick -= UpdateSprite;
        }

        private void Update()
        {
            Vector3 cameraPosition = camera.transform.position;
            Quaternion rotation = Quaternion.LookRotation(cameraPosition - transform.position, Vector3.up);
            Vector3 targetRotationEuler = new Vector3(transform.eulerAngles.x, rotation.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Euler(targetRotationEuler);
        }

        public static void LoadSpriteDefs()
        {
            spriteDefs = SpriteLumpGenerator.sprites;
        }

        public void UpdateSprite()
        {
            float rad2Deg = 57.29578f; // because deg2rad doesn't exist in the unhollowed unity assemblies
            float angle = Mathf.Atan2(mobj.transform.forward.x, mobj.transform.forward.z) * rad2Deg;

            int index = (int)((angle - (45 / 2) * 9) / 45) & 7;

            int stateFrame = mobj.frame;

            if (mobj.frame >= 32768)
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

            // absolutely do NOT render anything if
            // the patch array is null/empty
            if(spriteFrame.patches == null)
            {
                return;
            }

            float spriteWidth = spriteFrame.patches[index].width / 32f;
            float spriteHeight = spriteFrame.patches[index].height / 32f;

            float spriteOffsetTop = spriteFrame.patches[index].topOffset / 100f;

            if (!spriteFrame.canRotate)
            {
                meshRenderer.material.mainTexture = spriteFrame.patches[0].output;
                transform.localScale = new Vector3(-spriteWidth, spriteHeight, -1);

                return;
            }

            if (index >= spriteFrame.numRotations)
            {
                int rotation = 8 - index;
                int invertScale = spriteFrame.flipBits[rotation] ? -1 : 1;

                spriteWidth = invertScale * spriteFrame.patches[rotation].width / 32f;
                spriteHeight = spriteFrame.patches[rotation].height / 32f;

                meshRenderer.material.mainTexture = spriteFrame.patches[rotation].output;
                transform.localScale = new Vector3(spriteWidth, spriteHeight, -1f);
            }
            else
            {
                meshRenderer.material.mainTexture = spriteFrame.patches[index].output;
                transform.localScale = new Vector3(spriteWidth, spriteHeight, -1);
            }

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y);
        }
    }
}
