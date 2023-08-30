using NEP.DOOMLAB.Data;
using NEP.DOOMLAB.Sound;

[System.Serializable]
public struct MobjInfo
{
    public MobjInfo(
        int editorNumber,
        StateNum spawnState,
        float health,
        StateNum seeState,
       SoundType seeSound,
        int reactionTime,
       SoundType attackSound,
        StateNum painState,
        int painChance,
       SoundType painSound,
        StateNum meleeState,
        StateNum missileState,
        StateNum deathState,
        StateNum xDeathState,
       SoundType deathSound,
        float speed,
        float radius,
        float height,
        float mass,
        float damage,
       SoundType activeSound,
        MobjFlags flags,
        StateNum raiseState)
    {
        this.editorNumber = editorNumber;
        this.spawnState = spawnState;
        this.spawnHealth = health;
        this.seeState = seeState;
        this.seeSound = seeSound;
        this.reactionTime = reactionTime;
        this.attackSound = attackSound;
        this.painState = painState;
        this.painChance = painChance;
        this.painSound = painSound;
        this.missileState = missileState;
        this.meleeState = meleeState;
        this.deathState = deathState;
        this.xDeathState = xDeathState;
        this.deathSound = deathSound;
        this.speed = speed;
        this.radius = radius;
        this.height = height;
        this.mass = mass;
        this.damage = damage;
        this.activeSound = activeSound;
        this.flags = flags;
        this.raiseState = raiseState;
    }

    public int editorNumber;

    public StateNum spawnState;
    public StateNum seeState;
    public StateNum painState;
    public StateNum meleeState;
    public StateNum missileState;
    public StateNum deathState;
    public StateNum xDeathState;
    public StateNum raiseState;

    public SoundType seeSound;
    public SoundType attackSound;
    public SoundType painSound;
    public SoundType deathSound;
    public SoundType activeSound;

    public float spawnHealth;
    public float speed;
    public float radius;
    public float height;
    public float mass;
    public float damage;

    public MobjFlags flags;

    public int reactionTime;
    public int painChance;
}
