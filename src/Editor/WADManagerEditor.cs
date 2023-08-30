using UnityEditor;
using UnityEngine;

using NEP.DOOMLAB.WAD;

namespace NEP.DOOMLAB.WAD
{
    [CustomEditor(typeof(WADManager))]
    public class WADManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            WADManager manager = (WADManager)target;

            if(GUILayout.Button("Load WAD Content"))
            {
                manager.LoadWAD(manager.pathToWAD);
            }
        }
    }
}