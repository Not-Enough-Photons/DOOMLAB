using System;
using System.Reflection;
using System.Runtime.InteropServices;

using UnityEngine;

using MelonLoader;

using SLZ.AI;
using SLZ.Combat;
using SLZ.Marrow.Data;

namespace NEP.DOOMLAB.Patches
{
    internal static class AttackPatch
    {

        public static Action<Attack> OnAttackReceived;

        private static AttackPatchDelegate _original;
        private delegate void AttackPatchDelegate(IntPtr instance, IntPtr attack, IntPtr method);

        public static unsafe void Patch()
        {
            AttackPatchDelegate patch = Patch;

            string nativeInfoName = "NativeMethodInfoPtr_ReceiveAttack_Public_Virtual_Final_New_Void_Attack_0";
            var tgtPtr = *(IntPtr*)(IntPtr)typeof(ImpactProperties).GetField(nativeInfoName, BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
            var dstPtr = patch.Method.MethodHandle.GetFunctionPointer();

            MelonUtils.NativeHookAttach((IntPtr)(&tgtPtr), dstPtr);
            _original = Marshal.GetDelegateForFunctionPointer<AttackPatchDelegate>(tgtPtr);
        }

        public static void Patch(IntPtr instance, IntPtr attack, IntPtr method)
        {
            _original(instance, attack, method);

            unsafe
            {
                try
                {
                    Attack_ refAttack = *(Attack_*)attack;

                    Attack _attack = new Attack()
                    {
                        damage = refAttack.damage,
                        normal = refAttack.normal,
                        origin = refAttack.origin,
                        backFacing = refAttack.backFacing == 1 ? true : false,
                        OrderInPool = refAttack.OrderInPool,
                        collider = refAttack.Collider,
                        attackType = refAttack.attackType,
                        proxy = refAttack.Proxy
                    };

                    OnAttackReceived?.Invoke(_attack);
                }
                catch
                {

                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Attack_
        {
            public float damage;
            public Vector3 normal;
            public Vector3 origin;
            public byte backFacing;
            public int OrderInPool;
            public IntPtr collider;
            public AttackType attackType;
            public IntPtr proxy;

            public Collider Collider
            {
                get => new Collider(collider);
                set => collider = value.Pointer;
            }

            public TriggerRefProxy Proxy
            {
                get => new TriggerRefProxy(proxy);
                set => proxy = value.Pointer;
            }
        }
    }
}