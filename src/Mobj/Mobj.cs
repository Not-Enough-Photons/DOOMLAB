using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobj : MonoBehaviour
{
    public enum MoveDirection
    {
        EAST,
        NORTHEAST,
        NORTH,
        NORTHWEST,
        WEST,
        SOUTHWEST,
        SOUTH,
        SOUTHEAST,
        NODIR
    }

    public MobjInfo info;
    public State state;
    public StateNum currentState;
    public MobjType type;
    public MobjFlags flags;

    public Vector3 position;
    public Quaternion rotation;

    public SpriteNum sprite;
    public int frame;
    public float radius;
    public float height;

    public Mobj target;
    public Mobj player;
    public Mobj tracer;

    public Vector3 momentum;

    public int validCount;

    public float health;
    public int tics;
    public MoveDirection moveDirection;
    public int moveCount;
    public int reactionTime;
    public int threshold;
    public int lastLook;

    public Rigidbody rigidbody;
    public BoxCollider collider;

    private void Awake()
    {
        info = Info.MobjInfos[(int)type];
    }

    private void Start()
    {
        DoomGame.OnTick += WorldTick;
    }

    private void OnDestroy()
    {
        DoomGame.OnTick -= WorldTick;
    }

    private void WorldTick()
    {
        UpdateThinker();
    }

    public void UpdateThinker()
    {
        if(tics != 0)
        {
            tics--;

            if (tics <= 0 && !SetState(state.nextstate))
            {
                tics = 0;
                return;
            }
        }
    }

    public bool SetState(StateNum state)
    {
        State st;

        currentState = state;

        if(state == StateNum.S_NULL)
        {
            this.state = Info.GetState(StateNum.S_NULL);
            MobjManager.Instance.RemoveMobj(this);
            return false;
        }

        st = Info.GetState(state);
        this.state = st;
        this.tics = st.tics;
        this.sprite = st.sprite;
        this.frame = st.frame;

        if(st.action != null)
        {
            st.action(this);
        }

        return true;
    }

    public void OnSpawn(Vector3 position, MobjType type)
    {
        this.info = Info.MobjInfos[(int)type];

        this.type = type;
        this.radius = info.radius;
        this.height = info.height;
        this.flags = info.flags;
        this.health = info.spawnHealth;

        State st = Info.GetState(info.spawnState);

        this.state = st;
        this.tics = st.tics;
        this.sprite = st.sprite;
        this.frame = st.frame;

        transform.position = position;
    }
    
    public void OnRemove()
    {
        var spriteRenderer = GetComponentInChildren<NEP.DOOMLAB.Rendering.DoomSpriteRenderer>();
        Destroy(spriteRenderer);
        Destroy(gameObject);
    }
    
    public void Movement()
    {
        float tryX = transform.position.x + rigidbody.velocity.x;
        float tryZ = transform.position.z + rigidbody.velocity.z;

        rigidbody.velocity += new Vector3(tryX, 0f, tryZ);
    }

    public void TakeDamage(float damage, Mobj inflictor)
    {
        if(health <= 0f)
        {
            return;
        }

        health -= damage;

        SetState(info.painState);

        if(health - damage <= 0 && currentState != info.deathState)
        {
            SetState(info.deathState);
            flags ^= MobjFlags.MF_SHOOTABLE | MobjFlags.MF_CORPSE;

            inflictor.target = null;

            collider.size = new Vector3(collider.size.x, collider.size.y / 2, collider.size.z);
        }
        else if(health - damage <= -16 && currentState != info.xDeathState)
        {
            StateNum deathType = info.xDeathState != StateNum.S_NULL ? info.xDeathState : info.deathState;
            SetState(deathType);
            flags ^= MobjFlags.MF_SHOOTABLE | MobjFlags.MF_CORPSE;

            inflictor.target = null;

            collider.size = new Vector3(collider.size.x, collider.size.y / 2, collider.size.z);
        }
    }
}
