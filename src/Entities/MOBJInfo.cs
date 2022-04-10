using System.Collections;

namespace NEP.BWDOOM.Entities
{
    public class MOBJInfo
    {
        public MOBJInfo(
            int doomednum,
            StateNum spawnstate,
            int spawnhealth,
            StateNum seestate,
            Sound.SFXEnum seesound,
            int reactiontime,
            Sound.SFXEnum attacksound,
            StateNum painstate,
            int painchance,
            Sound.SFXEnum painsound,
            StateNum meleestate,
            StateNum missilestate,
            StateNum deathstate,
            StateNum xdeathstate,
            Sound.SFXEnum deathsound,
            int speed,
            float radius,
            float height,
            int mass,
            int damage,
            Sound.SFXEnum activesound,
            MOBJFlags flags,
            StateNum raisestate)
        {
            this.doomednum = doomednum;
            this.spawnstate = spawnstate;
            this.spawnhealth = spawnhealth;
            this.seestate = seestate;
            this.seesound = seesound;
            this.reactiontime = reactiontime;
            this.attacksound = attacksound;
            this.painsound = painsound;
            this.meleestate = meleestate;
            this.missilestate = missilestate;
            this.deathstate = deathstate;
            this.xdeathstate = xdeathstate;
            this.speed = speed;
            this.radius = radius;
            this.height = height;
            this.mass = mass;
            this.damage = damage;
            this.activesound = activesound;
            this.flags = flags;
            this.raisestate = this.raisestate;
        }

        public int doomednum;
        public StateNum spawnstate;
        public int spawnhealth;
        public StateNum seestate;
        public Sound.SFXEnum seesound;
        public int reactiontime;
        public Sound.SFXEnum attacksound;
        public StateNum painstate;
        public int painchance;
        public Sound.SFXEnum painsound;
        public StateNum meleestate;
        public StateNum missilestate;
        public StateNum deathstate;
        public StateNum xdeathstate;
        public Sound.SFXEnum deathsound;
        public int speed;
        public float radius;
        public float height;
        public int mass;
        public int damage;
        public Sound.SFXEnum activesound;
        public MOBJFlags flags;
        public StateNum raisestate;
    }
}
