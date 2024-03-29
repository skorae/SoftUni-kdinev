﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangledoubleersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }



        public bool doubleersect(Rectangle second)
        {
            if (this.X + this.Width < second.X ||
                second.X + second.Width < this.X ||
                this.Y + this.Height < second.Y ||
                second.Y + second.Height < this.Y)
            {
                return false;
            }
            return true;
        }
    }
}
