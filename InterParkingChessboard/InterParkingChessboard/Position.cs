﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InterParkingChessboard
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Position()
        {

        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
