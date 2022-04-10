using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MOBJSensor : MonoBehaviour
    {
        public MOBJSensor(System.IntPtr ptr) : base(ptr) { }

        public List<MOBJ> closestMOBJs = new List<MOBJ>();
        public MOBJ target;

        private SphereCollider sensorCollider;

        private void Awake()
        {
            sensorCollider = GetComponent<SphereCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            MOBJ closest = other.GetComponent<MOBJ>();

            if (closest != null)
            {
                target = closest;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            MOBJ closest = other.GetComponent<MOBJ>();

            if (closest != null)
            {
                target = null;
            }
        }
    }
}

