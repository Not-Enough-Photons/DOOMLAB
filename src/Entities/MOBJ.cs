using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

namespace NEP.BWDOOM.Entities
{
    [MelonLoader.RegisterTypeInIl2Cpp]
    public class MOBJ : Thinker
    {
        public MOBJ(System.IntPtr ptr) : base(ptr) { }

        public System.Action<MOBJ> OnStateUpdated;

        public enum DirType
        {
            DI_EAST,
            DI_NORTHEAST,
            DI_NORTH,
            DI_NORTHWEST,
            DI_WEST,
            DI_SOUTHWEST,
            DI_SOUTH,
            DI_SOUTHEAST,
            DI_NODIR,
            NUMDIRS
        }

        public Rigidbody rb { get; private set; }

        public MOBJState state;
        public MOBJType type;
        public MOBJInfo info;
        public MOBJFlags flags;
        public int tics;
        public string sprite;
        public int frame;

        public int health;
        public int reactiontime;
        public int threshold;
        public int speed;

        public MOBJ target;
        public GameObject targetGameObject;
        public DirType moveDir;
        public int moveCount;

        public Vector3 position;
        public Quaternion rotation;

        public MOBJSensor sensor;

        public BoxCollider boxCollider;
        public float radius;
        public float height;

        public ThingMovement thingMovement;
        public EnemyBehaviour enemyBehaviour;
        public Rendering.ThingRenderer thingRenderer;

        public System.Action<MOBJ> action;

        public float[] dirRotations = new float[(int)DirType.NUMDIRS]
        {
            -90f,
            -45f,
            0f,
            45f,
            90f,
            135f,
            180f,
            225f,
            270f
        };

        private void Awake()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            boxCollider = gameObject.AddComponent<BoxCollider>();

            thingMovement = gameObject.AddComponent<ThingMovement>();
            enemyBehaviour = gameObject.AddComponent<EnemyBehaviour>();

            rb = gameObject.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            GameObject sensorObject = new GameObject("MOBJSensor");
            GameObject srSprite = GameObject.CreatePrimitive(PrimitiveType.Cube);

            Destroy(srSprite.GetComponent<Collider>());

            sensorObject.transform.parent = transform;
            srSprite.transform.parent = transform;

            SphereCollider col = sensorObject.AddComponent<SphereCollider>();
            col.radius = 5f;
            sensor = col.gameObject.AddComponent<MOBJSensor>();
            col.isTrigger = true;

            thingRenderer = srSprite.AddComponent<Rendering.ThingRenderer>();
        }

        private void Start()
        {
            ThinkerManager.instance.Add(this);
            SetupBounds(info.radius, info.height);
            InitFlags();
        }

        private void InitFlags()
        {
            if (rb == null)
            {
                return;
            }

            rb.drag = 0f;
            rb.angularDrag = 0f;

            rb.useGravity =
                (flags &= MOBJFlags.MF_NOGRAVITY) == 0 ||
                (flags &= MOBJFlags.MF_SKULLFLY) != 0 ||
                (flags &= MOBJFlags.MF_FLOAT) != 0 ||
                (flags &= MOBJFlags.MF_MISSILE) != 0;

            boxCollider.enabled =
                (flags &= MOBJFlags.MF_NOCLIP) != 0 ||
                (flags &= MOBJFlags.MF_SOLID) == 0;
        }

        private void SetupBounds(float radius, float height)
        {
            boxCollider.size = new Vector3(radius * 1.25f, height * 1.25f, radius * 1.25f) / 50f;
            boxCollider.center = Vector3.up * -0.25f;
        }

        private void Update()
        {
            position = transform.position;
            transform.rotation = rotation;
        }

        public bool P_SetMobjState(MOBJ mobj, StateNum state)
        {
            do
            {
                if (state == StateNum.S_NULL)
                {
                    mobj.state = Info.StateTable.states[(int)StateNum.S_NULL];
                    ThinkerManager.instance.Remove(this);
                    GameObject.Destroy(gameObject);
                    return false;
                }

                MOBJState st = Info.StateTable.states[(int)state];

                mobj.state = st;
                mobj.tics = st.tics;
                mobj.sprite = st.sprite;
                mobj.frame = st.frame;

                thingRenderer.R_ProjectSprite(mobj);

                if (st.action != null)
                {
                    st.action(this);
                }

                state = st.nextState;
            }
            while (tics == 0);

            return true;
        }

        public override void Run()
        {
            base.Run();

            if (rb.velocity.x != 0f || rb.velocity.z != 0f || (flags & MOBJFlags.MF_SKULLFLY) != 0)
            {
                thingMovement.P_XYMovement(this);
            }

            if (rb.velocity.y != 0f)
            {
                thingMovement.P_ZMovement(this);
            }

            if (tics != -1)
            {
                tics--;

                if (tics == 0)
                {
                    if (!P_SetMobjState(this, state.nextState))
                    {
                        return;
                    }
                }
            }
            else
            {
                moveCount++;

                if (moveCount < 12 * 35)
                {
                    return;
                }
            }
        }
    }
}

