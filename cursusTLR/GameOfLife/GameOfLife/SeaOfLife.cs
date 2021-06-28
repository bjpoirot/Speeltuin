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

        public SeaOflife(int xMax, int yMax)
        {
            Amoubes = new List<Amoube>();
            var randomAliveGenerator = new Random();

            for (int x = 0; x < xMax; x++)
            {
                for (int y = 0; y < yMax; y++)
                {
                    var alive = randomAliveGenerator.Next(1000) % 2 != 0;
                    Amoubes.Add(new Amoube(alive, x, y, this));
                }

            }
        }

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