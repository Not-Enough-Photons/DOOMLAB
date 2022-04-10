using System;

namespace NEP.BWDOOM.Entities
{
    public class MOBJState
    {
        public StateNum indexState;
        public string sprite;
        public int frame;
        public int tics;
        public Action<MOBJ> action;
        public StateNum nextState;
        public int dummy1;
        public int dummy2;
    }
}
