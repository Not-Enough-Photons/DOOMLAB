using System;
using Harmony;
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
            spriteDefs = FrameBuilder.spriteDefs;
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

            SetSprite(spriteFrame, index);
        }

        private void SetSprite(SpriteFrame spriteFrame, int rotation)
        {
            WAD.DataTypes.Patch patch = spriteFrame.patches[rotation];
            bool flipBit = spriteFrame.flipBits[rotation];
            int xScale = flipBit ? -1 : 1;;

            int heightUnscaled = patch.height;
            int topOffsetUnscaled = patch.topOffset;

            float width = patch.width / 32f;
            float height = patch.height / 32f;
            float topOffset = topOffsetUnscaled / 32f;
            float offset = height - topOffset;
            
            meshRenderer.material.mainTexture = patch.output;
            transform.localScale = new Vector3(width * xScale, height, -1f);
            transform.localPosition = new Vector3(transform.localPosition.x, offset);
        }
    }
}
