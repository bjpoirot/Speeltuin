using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Amoube
    {
        public int X {get;set;}
        public int Y {get;set;}
        public bool CurrentState {get;set;}
        private bool NextState {get;set;}
        public SeaOflife SeaOflife {get;set;}

        public void CalculateNextState()
        {

            var livingNeighbours = GetNeighbours().Count(n => n.CurrentState);
             
            if(CurrentState && livingNeighbours == 2)
            {
                NextState = true;
                return;
            }
            if(livingNeighbours == 3)
            {
                NextState = true;
                return;
            }
            NextState = false;
        }

        private List<Amoube> GetNeighbours()
        {
            var Xmin1 = X-1;
            var Xplus1 = X+1;
            var Ymin1 = Y-1;
            var Yplus1 = Y+1;
            return SeaOflife.Amoubes.Where(a => (a.X == Xmin1 || a.X == Xplus1) 
                && (a.Y == Ymin1 || a.Y == Yplus1)).ToList();
        }

        public void SetCurrentState()
        {
            CurrentState = NextState;
        }

    }
}
