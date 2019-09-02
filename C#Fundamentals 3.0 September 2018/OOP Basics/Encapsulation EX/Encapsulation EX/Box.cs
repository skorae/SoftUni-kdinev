using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBox
{
    public class Box
    {
        private decimal lenght;
        private decimal width;
        private decimal height;

        public Box(decimal lenght, decimal width, decimal height)
        {
            this.Lenght = lenght;
            this.Width = width;
            this.Height = height;
        }


        public decimal Lenght
        {
            get { return this.lenght; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }

        public decimal Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                   throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public void GetArea(decimal length, decimal width, decimal height)
        {
            //2lw + 2lh + 2wh
            decimal area = (2 * (lenght * width)) + (2 * (lenght * height)) + (2 * (width * height));
            Console.WriteLine($"Surface Area - {area:f2}");
        }


        public void GetLateralArea(decimal length, decimal width, decimal height)
        {
            //2lh + 2wh
            decimal lateral = (2 * (lenght * height)) + (2 * (width * height));
            Console.WriteLine($"Lateral Surface Area - {lateral:f2}");
        }

        public void Volume(decimal length, decimal width, decimal height)
        {
            //lwh
            Console.WriteLine($"Volume - {(lenght * height * width):f2}");
        }
    }
}
