using UnityEditor;
using UnityEngine;

using NEP.DOOMLAB.WAD;
using NEP.DOOMLAB.Rendering;

namespace NEP.DOOMLAB.WAD
{
    [CustomEditor(typeof(DoomSpriteRenderer))]
    public class DoomSpriteRendererEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            DoomSpriteRenderer manager = (DoomSpriteRenderer)target;

            if(GUILayout.Button("Update Sprite"))
            {
                manager.UpdateSprite();
            }
        }
    }
}