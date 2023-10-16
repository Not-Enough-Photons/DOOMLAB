using System;

using NEP.DOOMLAB.Entities;

namespace NEP.DOOMLAB.Data
{
    public class State
    {
        public State(SpriteNum sprite, int frame, int tics, Action<Mobj> action, StateNum nextstate)
        {
            this.sprite = sprite;
            this.frame = frame;
            this.tics = tics;
            this.action = action;
            this.nextstate = nextstate;
        }

        public SpriteNum sprite;
        public int frame;
        public int tics;
        public Action<Mobj> action;
        public StateNum nextstate;
    }
}
