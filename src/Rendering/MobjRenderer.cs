using System;
using Il2CppSystem.Numerics;
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
            float angle = Vector3.SignedAngle(mobj.transform.forward, camera.transform.forward, Vector3.up);
            angle = Mathf.Repeat(angle + 180f, 360f) - 180f;
            int index = (int)((angle - (45 / 2) * 9) / 45) & 7;
            
            int stateFrame = mobj.frame;

            if (mobj.frame >= 32768)
            {
                stateFrame = mobj.frame - 32768;
            }

            SpriteDef spriteDef = spriteDefs[(int)mobj.sprite];
            SpriteFrame spriteFrame = spriteDef.GetFrame(stateFrame);

            // absolutely do NOT render anything if
            // the patch array is null/empty
            if(spriteFrame.patches == null)
            {
                return;
            }

            if (!spriteFrame.canRotate)
            {
                SetSprite(spriteFrame, 0);
                return;
            }

            if (index > spriteFrame.numRotations)
            {
                int rotation = spriteFrame.numRotations - index;
                SetSprite(spriteFrame, rotation);
            }
            else
            {
                SetSprite(spriteFrame, index);
            }
        }

        private void SetSprite(SpriteFrame spriteFrame, int rotation)
        {
            int xScale = spriteFrame.flipBits[rotation] ? -1 : 1;
            
            xScale = rotation != 0 ? -1 : 1;

            int heightUnscaled = spriteFrame.patches[rotation].height;
            int topOffsetUnscaled = spriteFrame.patches[rotation].topOffset;
            int offsetUnscaled = heightUnscaled - topOffsetUnscaled;

            float width = spriteFrame.patches[rotation].width / 32f;
            float height = spriteFrame.patches[rotation].height / 32f;
            
            meshRenderer.material.mainTexture = spriteFrame.patches[rotation].output;
            transform.localScale = new Vector3(width * xScale, height, -1f);
            transform.localPosition = new Vector3(transform.localPosition.x, -offsetUnscaled / 32f);
        }
    }
}
