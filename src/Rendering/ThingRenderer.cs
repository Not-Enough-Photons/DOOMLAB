using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

using NEP.BWDOOM.Entities;

namespace NEP.BWDOOM.Rendering
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class ThingRenderer : MonoBehaviour
    {
        public ThingRenderer(System.IntPtr ptr) : base(ptr) { }

        public MOBJ mobj;

        public Texture2DArray arr;
        public MeshRenderer meshRenderer;
        private static Material material;

        private int rotIdx;
        private int rotFlipIdx;

        private bool rotate;
        private WAD.SpriteLump[] rotations;
        private bool[] flip;

        private Camera mainCamera;

        private void Start()
        {
            mobj = GetComponentInParent<MOBJ>();
            meshRenderer = GetComponentInChildren<MeshRenderer>();
            material = meshRenderer.material;
            material.shader = Shader.Find("Doom/Billboard_Y");

            mainCamera = Camera.main;

            R_ProjectSprite(mobj);
        }

        public void R_ProjectSprite(MOBJ thing)
        {
            if (thing.frame >= 32765) thing.frame -= 32765;

            SpriteNum sprNum = Info.SpriteNames.GetSpriteNum(thing.sprite);
            SpriteDef sprDef = SpriteLookup.spriteDefs[(int)sprNum];
            SpriteFrame sprFrame = sprDef.frames[thing.frame];

            rotate = sprFrame.rotate;
            rotations = sprFrame.lumps;
            flip = sprFrame.flip;

            if (thing.state.sprite == "NULL")
            {
                Texture2D nullTex = new Texture2D(1, 1);
                nullTex.SetPixel(0, 0, Color.clear);
                material.SetTexture("_MainTex", nullTex);
            }
        }

        private void Update()
        {
            R_DrawSprite(mobj);
        }

        private void R_DrawSprite(MOBJ thing)
        {
            Vector3 p_fwd = mainCamera.transform.forward;
            Vector3 fwd = transform.forward;
            Vector3 right = transform.right;

            float f_dot = Vector3.SignedAngle(fwd, p_fwd, Vector3.up);

            rotIdx = 0;
            bool behind = f_dot < 0f;

            if (!rotate)
            {
                rotIdx = 0;
            }
            else
            {
                if (f_dot > 135f) { rotIdx = 0; }
                else if (f_dot < 135f && f_dot > 90f) { rotIdx = flip[1] ? 1 : 7; rotFlipIdx = 1; }
                else if (f_dot < 90f && f_dot > 45f) { rotIdx = flip[2] ? 2 : 6; rotFlipIdx = 2; }
                else if (f_dot < 45f && f_dot > 0f) { rotIdx = flip[3] ? 3 : 5; rotFlipIdx = 3; }

                if (behind)
                {
                    if (Mathf.Abs(f_dot) > 0f && Mathf.Abs(f_dot) < 45f) { rotIdx = flip[4] ? 4 : 4; rotFlipIdx = 4; }

                    if (Mathf.Abs(f_dot) > 45f && Mathf.Abs(f_dot) < 90f) { rotIdx = flip[5] ? 5 : 3; rotFlipIdx = 5; }
                    else if (Mathf.Abs(f_dot) > 90f && Mathf.Abs(f_dot) < 135f) { rotIdx = flip[6] ? 6 : 2; rotFlipIdx = 6; }
                    else if (Mathf.Abs(f_dot) > 135f && Mathf.Abs(f_dot) < 180f) { rotIdx = flip[7] ? 7 : 1; rotFlipIdx = 7; }
                }
            }

            meshRenderer.material.SetTexture("_MainTex", rotations[rotIdx].sprite);
            meshRenderer.material.SetInt("_Flip", flip[rotFlipIdx] ? 1 : -1);
            meshRenderer.material.SetFloat("_ScaleX", rotations[rotIdx].sprite.width / 32f);
            meshRenderer.material.SetFloat("_ScaleY", rotations[rotIdx].sprite.height / 32f);
        }
    }
}