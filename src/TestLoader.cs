using BoneLib.Nullables;
using SLZ.Marrow.Data;
using SLZ.Marrow.Pool;
using SLZ.Marrow.Warehouse;
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

        internal static AssetPoolee loadedObject;

        internal static List<AssetPoolee> Warmup(string barcode, int size, bool startActive = false)
        {
            List<AssetPoolee> cache = new List<AssetPoolee>();

            for (int i = 0; i < size; i++)
            {
                SpawnableCrateReference reference = new SpawnableCrateReference(barcode);

                Spawnable spawnable = new Spawnable()
                {
                    crateRef = reference
                };

                AssetSpawner.Register(spawnable);
                NullableMethodExtensions.PoolManager_Spawn(spawnable, default, default, null, false, null, new Action<GameObject>((obj) => CreateObject(ref cache, obj, startActive)));
            }

            return cache;
        }

        private static void CreateObject(ref List<AssetPoolee> cache, GameObject obj, bool startActive = false)
        {
            obj.SetActive(startActive);
            cache.Add(obj.GetComponent<AssetPoolee>());
            loadedObject = obj.GetComponent<AssetPoolee>();
        }
    }
}
