using System;
using System.Drawing;

namespace KoolBadmaevLab2
{
    internal class CPoint : IDraw
    {
        public int X { get; }
        public int Y { get; }

        public double Df { get; set; }
        public double Ddf { get; set; }

        public CPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Draw(Graphics canvas)
        {
            
        }
    }
}
