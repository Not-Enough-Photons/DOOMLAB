using BoneLib;
using Il2CppSLZ.Marrow.Data;
using Il2CppSLZ.Marrow.Pool;
using Il2CppSLZ.Marrow.Warehouse;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace NEP.DOOMLAB
{
    public static class TestLoader
    {
        internal static readonly string companyCode = "NotEnoughPhotons.";
        internal static readonly string modCode = "DOOMLAB.";
        internal static readonly string typeCode = "Spawnable";

        internal static readonly string mobjBarcode = companyCode + modCode + typeCode + ".MOBJNull";

        internal static Poolee loadedObject;

        internal static List<Poolee> Warmup(string barcode, int size, bool startActive = false)
        {
            List<Poolee> cache = new List<Poolee>();

            for (int i = 0; i < size; i++)
            {
                SpawnableCrateReference reference = new SpawnableCrateReference(barcode);
                HelperMethods.SpawnCrate(reference, Vector3.zero, default, default, false, null, new Action<GameObject>((obj) => CreateObject(ref cache, obj, startActive)));
            }

            return cache;
        }

        private static void CreateObject(ref List<Poolee> cache, GameObject obj, bool startActive = false)
        {
            obj.SetActive(startActive);
            cache.Add(obj.GetComponent<Poolee>());
            loadedObject = obj.GetComponent<Poolee>();
        }
    }
}
