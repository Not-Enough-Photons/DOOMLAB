using UnityEngine;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Rendering;
using UnityEngine.AI;

namespace NEP.DOOMLAB.Game
{
    public class MobjManager : MonoBehaviour
    {
        public static MobjManager Instance { get; private set; }

        public GameObject mobjPrefab;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SpawnMobj(Vector3.up, MobjType.MT_POSSESSED);
        }

        public Mobj SpawnMobj(Vector3 position, MobjType type)
        {
            if (mobjPrefab == null)
            {
                throw new System.Exception("MOBJ base prefab doesn't exist!");
            }

            GameObject mobjBase = GameObject.Instantiate(mobjPrefab, position, Quaternion.identity);
            Mobj mobj = mobjBase.AddComponent<Mobj>();
            mobjBase.AddComponent<MobjBrain>();
            DoomSpriteRenderer spriteRenderer = mobj.transform.GetChild(0).gameObject.AddComponent<DoomSpriteRenderer>();

            mobj.rigidbody = mobjBase.AddComponent<Rigidbody>();
            mobj.collider = mobjBase.AddComponent<BoxCollider>();

            mobj.OnSpawn(position, type);

            mobj.name = $"[MOBJ] - {mobj.type}";

            mobj.rigidbody.mass = mobj.info.mass / 32f;
            mobj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            mobj.collider.size = new Vector3(mobj.radius / 32f, (mobj.height / 64f), mobj.radius / 32f);

            if (mobj.flags.HasFlag(MobjFlags.MF_NOGRAVITY))
            {
                mobj.rigidbody.useGravity = false;
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                mobj.rigidbody.drag = 0;
            }

            return mobj;
        }

        public Mobj SpawnMissile(Mobj source, Mobj destination, MobjType type)
        {
            Vector3 position = source.transform.position;
            Quaternion rotation = source.transform.rotation;
            Mobj projectile = SpawnMobj(position, type);

            projectile.gameObject.AddComponent<MobjCollisionEvents>();

            projectile.target = source;

            projectile.transform.rotation = rotation;

            projectile.rigidbody.velocity = (destination.transform.position - source.transform.position).normalized * projectile.info.speed;

            Physics.IgnoreCollision(source.GetComponent<Collider>(), projectile.GetComponent<Collider>());

            return projectile;
        }

        public void RemoveMobj(Mobj mobj)
        {
            mobj.OnRemove();
        }
    }
}