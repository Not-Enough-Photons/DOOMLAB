using UnityEngine;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Rendering;
using NEP.DOOMLAB.Sound;
using NEP.DOOMLAB.Game;

using SLZ.Combat;

using System.Collections.Generic;

namespace NEP.DOOMLAB.Entities
{
    public class MobjManager
    {
        public MobjManager()
        {
            Instance = this;
            mobjs = new List<Mobj>();
            mobjPrefab = Main.mobjTemplate;
        }

        public static MobjManager Instance { get; private set; }

        public GameObject mobjPrefab;

        public List<Mobj> mobjs;

        public Mobj SpawnMobj(Vector3 position, MobjType type, float angle = 0f)
        {
            if (mobjPrefab == null)
            {
                throw new System.Exception("MOBJ base prefab doesn't exist!");
            }

            GameObject mobjBase = GameObject.Instantiate(mobjPrefab, position, Quaternion.AngleAxis(angle, Vector3.up));
            Mobj mobj = mobjBase.GetComponent<Mobj>();
            mobj.brain = mobjBase.GetComponent<MobjBrain>();

            if(mobj.flags.HasFlag(MobjFlags.MF_SHOOTABLE) || mobj.flags.HasFlag(MobjFlags.MF_COUNTKILL))
            {
                var trpSphere = mobjBase.transform.GetChild(0).gameObject;
                trpSphere.AddComponent<MobjProxy>();
            }

            mobj.rigidbody = mobjBase.GetComponent<Rigidbody>();
            mobj.collider = mobjBase.GetComponent<BoxCollider>();
            mobj.audioSource = mobjBase.GetComponent<AudioSource>();

            mobj.OnSpawn(position, type);

            mobj.name = $"[MOBJ] - {mobj.type}";

            mobj.gameObject.layer = LayerMask.NameToLayer("EnemyColliders");
            mobj.collider.gameObject.layer = LayerMask.NameToLayer("EnemyColliders");

            mobj.rigidbody.mass = mobj.info.mass;
            mobj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
            mobj.rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

            mobj.collider.center = Vector3.up * (mobj.height / 32f) / 2f;
            mobj.collider.size = new Vector3(mobj.radius / 32f, mobj.height / 32f, mobj.radius / 32f);

            ImpactProperties impactProperties = mobjBase.GetComponent<ImpactProperties>();
            impactProperties.surfaceData = Main.mobjSurfaceData;

            if (!mobj.flags.HasFlag(MobjFlags.MF_SOLID))
            {
                mobj.collider.enabled = false;
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_SPECIAL))
            {
                mobj.collider.enabled = true;
                mobj.gameObject.AddComponent<MobjCollisionEvents>();
            }

            if (mobj.flags.HasFlag(MobjFlags.MF_NOGRAVITY))
            {
                mobj.rigidbody.useGravity = false;
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                mobj.collider.enabled = true;
                mobj.rigidbody.drag = 0;
                mobj.gameObject.AddComponent<MobjCollisionEvents>();
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_NOBLOOD))
            {
                impactProperties.enabled = false;
            }

            if(mobj.type == MobjType.MT_SKULL)
            {
                mobj.gameObject.AddComponent<MobjCollisionEvents>();
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_FLOAT))
            {
                mobj.rigidbody.drag = 10f;
            }

            mobjs.Add(mobj);

            return mobj;
        }

        public Mobj SpawnMissile(Mobj source, Mobj destination, MobjType type)
        {
            Vector3 position = source.transform.position + Vector3.up;
            Quaternion rotation = source.transform.rotation;
            Mobj projectile = SpawnMobj(position, type);

            // Who fired this rocket?
            // The target is where it came from
            projectile.target = source;

            projectile.transform.rotation = rotation;

            projectile.rigidbody.velocity = (destination.transform.position - position).normalized * projectile.info.speed;

            UnityEngine.Physics.IgnoreCollision(source.collider, projectile.collider, true);

            if (projectile.info.seeSound != Sound.SoundType.sfx_None)
            {
                SoundManager.Instance.PlaySound(projectile.info.seeSound, projectile.audioSource, false);
            }

            return projectile;
        }

        public void RemoveMobj(Mobj mobj)
        {
            mobj.OnRemove();
            mobjs.Remove(mobj);
        }
    }
}