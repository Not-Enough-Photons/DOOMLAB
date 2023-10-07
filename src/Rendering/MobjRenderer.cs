using System;
using System.Diagnostics;
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
        private Transform drawQuad;
        private static SpriteDef[] spriteDefs;

        private Camera camera;

        private static WAD.DataTypes.Patch missingPatch;
        private static SpriteFrame missingFrame;

        private Material original;
        private Material unlit;

        private void Awake()
        {
            meshRenderer = GetComponentInChildren<MeshRenderer>();
            mobj = GetComponentInParent<Mobj>();
            game = DoomGame.Instance;
            camera = Camera.main;
            drawQuad = transform.GetChild(0);

            original = meshRenderer.material;
            unlit = Main.unlitMaterial;

            missingPatch = new WAD.DataTypes.Patch("FAILA0", 32, 32, 16, 38);
            missingPatch.output = Main.MissingSprite;

            missingFrame = new SpriteFrame()
            {
                canRotate = false,
                flipBits = new bool[8],
                mirrorSprite = new bool[8],
                numRotations = 0,
                patches = new WAD.DataTypes.Patch[8]
                {
                    missingPatch,
                    missingPatch,
                    missingPatch,
                    missingPatch,
                    missingPatch,
                    missingPatch,
                    missingPatch,
                    missingPatch
                }
            };
        }

        private void Start()    
        {
            DoomGame.Instance.OnTick += UpdateSprite;
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
                meshRenderer.material = unlit;
            }
            else
            {
                meshRenderer.material = original;
            }

            SpriteDef spriteDef = spriteDefs[(int)mobj.sprite];

            if(spriteDef.spriteFrames == null || stateFrame > spriteDef.spriteFrames.Length)
            {
                SetSprite(missingFrame, 0);
                return;
            }

            SpriteFrame spriteFrame = spriteDef.spriteFrames[stateFrame];

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
            int xScale = flipBit ? 1 : -1;

            if(rotation == 0)
            {
                xScale = -1;
            }

            float width = patch.width / 32f;
            float height = patch.height / 32f;

            float leftOffset = patch.leftOffset / 32f;
            float topOffset = patch.topOffset / 32f;

            meshRenderer.material.mainTexture = patch.output;
            transform.localScale = new Vector3(width * xScale, height, 1f);
            drawQuad.localPosition = new Vector3(leftOffset / 100f, (topOffset / 100f) + 0.5f);

            if(mobj.frame >= 32768)
            {
                meshRenderer.material.SetTexture("_EmissionMap", patch.output);
                meshRenderer.material.SetColor("_EmissionColor", Color.white);
                meshRenderer.material.EnableKeyword("_EMISSION");
            }
            else
            {
                meshRenderer.material.DisableKeyword("_EMISSION");
            }
        }
    }
}
