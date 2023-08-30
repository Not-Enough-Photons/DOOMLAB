using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEP.DOOMLAB.Data
{
    [System.Serializable]
    public struct State
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
