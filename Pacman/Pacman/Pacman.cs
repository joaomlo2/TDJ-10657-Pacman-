using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class Pacman
    {
        public int X{get; set;}
        public int Y { get; set; }
        public int boardX { get; set; }
        public int boardY { get; set; }
        public int Direcção { get; set; }

        public Pacman()
        {
            X = 10;
            Y = 10;
            boardX = 1;
            boardY = 1;
            Direcção = 2;
        }
    }
}
