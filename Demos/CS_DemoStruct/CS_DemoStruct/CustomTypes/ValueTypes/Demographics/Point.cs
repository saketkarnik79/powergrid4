using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoStruct.CustomTypes.ValueTypes.Demographics
{
    internal struct Point
    {
        //public int x;
        //public int y;

        private int x;
        private int y;

        public int X
        {
            get 
            { 
                return x; 
            }
            set 
            { 
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "X coordinate cannot be negative.");
                }
                x = value; 
            }
        }

        public int Y 
        { 
            get => y; 
            set 
            {
                if(value < 0)
                {
                    throw new ArgumentException(nameof(value), "Y coordinate cannot be negative.");
                }
                y = value;
            } 
        }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }

        public override string ToString()
        {   
            return $"({X}, {Y})";
        }
    }
}
