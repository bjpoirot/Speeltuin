using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class SeaOflife
    {
        public Guid ID {get;set;}
        public int Xmax {get; set;}
        public int Ymax {get;set;}
        public List<Amoube> Amoubes {get;set;}

        public void CalculateNextState()
        {
            foreach (var amoube in Amoubes)
            {
                amoube.CalculateNextState();
            }
            foreach (var amoube in Amoubes)
            {
                amoube.SetCurrentState();
            }
        }        
        
    }
}