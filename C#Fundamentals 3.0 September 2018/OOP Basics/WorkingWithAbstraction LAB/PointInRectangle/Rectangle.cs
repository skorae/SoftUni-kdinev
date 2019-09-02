using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        private int topLeftX;
        private int topLeftY;
        private int bottomRightX;
        private int bottomRightY;

        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeftX = topLeftX;
            this.TopLeftY = topLeftY;
            this.BottomRightX = bottomRightX;
            this.BottomRightY = bottomRightY;
        }

        public int TopLeftX
        {
            get { return this.topLeftX; }
            set { this.topLeftX = value; }
        }

        public int TopLeftY
        {
            get { return this.topLeftY; }
            set { this.topLeftY = value; }
        }

        public int BottomRightX
        {
            get { return this.bottomRightX; }
            set { this.bottomRightX = value; }
        }

        public int BottomRightY
        {
            get { return this.bottomRightY; }
            set { this.bottomRightY = value; }
        }
        
    }
}
