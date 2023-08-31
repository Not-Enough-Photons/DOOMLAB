using UnityEngine;

using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Rendering;
using UnityEngine.AI;

namespace NEP.DOOMLAB.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MobjManager : MonoBehaviour
    {
        public MobjManager(System.IntPtr ptr) : base(ptr) { }

        public static MobjManager Instance { get; private set; }

        public GameObject mobjPrefab;

        private void Awake()
        {
            Instance = this;
            mobjPrefab = Main.mobjTemplate;
        }

        private void Start()
        {
            SpawnMobj(Vector3.zero, MobjType.MT_TROOP);
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

            mobjBase.transform.GetChild(0).gameObject.AddComponent<DoomSpriteRenderer>();
            mobjBase.transform.GetChild(0).gameObject.AddComponent<BillboardLookAt>();

            mobj.rigidbody = mobjBase.AddComponent<Rigidbody>();
            mobj.collider = mobjBase.AddComponent<BoxCollider>();

            mobj.OnSpawn(position, type);

            mobj.name = $"[MOBJ] - {mobj.type}";

            mobj.rigidbody.mass = mobj.info.mass / 32f;
            mobj.rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

            mobj.collider.size = new Vector3(mobj.radius / 32f, mobj.height / 32f, mobj.radius / 32f);

            if (!mobj.flags.HasFlag(MobjFlags.MF_SOLID))
            {
                mobj.collider.enabled = false;
            }

            if (mobj.flags.HasFlag(MobjFlags.MF_NOGRAVITY))
            {
                mobj.rigidbody.useGravity = false;
            }

            if(mobj.flags.HasFlag(MobjFlags.MF_MISSILE))
            {
                mobj.collider.enabled = true;
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