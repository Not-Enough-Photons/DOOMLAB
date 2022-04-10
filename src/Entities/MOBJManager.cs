using UnityEngine;

using System.Collections.Generic;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MOBJManager : MonoBehaviour
    {
        public MOBJManager(System.IntPtr ptr) : base(ptr) { }

        public static MOBJManager instance;
        public List<MOBJ> mObjList;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance.gameObject);
            }

            DontDestroyOnLoad(instance.gameObject);
        }

        private void Start()
        {
            mObjList = new List<MOBJ>();

            P_SpawnMobj(Random.insideUnitSphere * 6f, MOBJType.MT_CYBORG);
            P_SpawnMobj(Random.insideUnitSphere * 2f, MOBJType.MT_TROOP);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (MOBJ mObj in mObjList)
                {
                    ThingInteraction.P_DamageMobj(mObj, mObj, mObj, 10);
                }
            }
        }

        public MOBJ P_SpawnMobj(Vector3 position, MOBJType type)
        {
            MOBJ mobj = new GameObject($"{type}").AddComponent<MOBJ>();

            Destroy(mobj.GetComponent<MeshCollider>());

            MOBJInfo info = Info.MobjInfos.infos[(int)type];

            mobj.type = type;
            mobj.info = info;
            mobj.flags = info.flags;
            mobj.speed = info.speed;
            mobj.health = info.spawnhealth;
            mobj.height = info.height;
            mobj.radius = info.radius;
            mobj.position = position;

            MOBJState state = Info.StateTable.states[(int)info.spawnstate];

            mobj.state = state;
            mobj.tics = state.tics;
            mobj.sprite = state.sprite;
            mobj.frame = state.frame;

            ThinkerManager.instance.Add(mobj);

            mObjList.Add(mobj);

            return mobj;
        }

        public MOBJ P_SpawnMissile(MOBJ source, MOBJ dest, MOBJType type)
        {
            Vector3 src = source.transform.position;

            MOBJ th = P_SpawnMobj(new Vector3(src.x, src.y, src.z * ((4f * 8f) / 10f)), type);

            if (th.info.seesound != Sound.SFXEnum.sfx_None)
            {
                Sound.SFXManager.instance.S_StartSoundAtVolume(th.transform.position, th.info.seesound, false);
            }

            th.target = source;
            th.transform.LookAt(source.transform);

            th.rb.velocity += Vector3.forward * th.info.speed;

            float dist = Vector3.Distance(dest.transform.position, source.transform.position);
            dist = dist / th.info.speed;

            if (dist <= 1f)
            {
                dist = 1f;
            }

            th.rb.velocity = new Vector3(th.rb.velocity.x, th.rb.velocity.y, (dest.transform.position.z - src.z) / dist);

            return th;
        }

        public MOBJ P_SpawnMissile(Vector3 source, Vector3 dest, MOBJType type)
        {
            MOBJ th = P_SpawnMobj(new Vector3(source.x, source.y, source.z * ((4f * 8f) / 10f)), type);

            if (th.info.seesound != Sound.SFXEnum.sfx_None)
            {
                Sound.SFXManager.instance.S_StartSoundAtVolume(th.transform.position, th.info.seesound, false);
            }

            th.rb.velocity += Vector3.right * th.info.speed;
            th.rb.velocity += Vector3.forward * th.info.speed;

            float dist = Vector3.Distance(dest, source);
            dist = dist / th.info.speed;

            if (dist <= 1f)
            {
                dist = 1f;
            }

            th.rb.velocity = new Vector3(th.rb.velocity.x, th.rb.velocity.y, (dest.z - source.z) / dist);

            return th;
        }
    }
}
