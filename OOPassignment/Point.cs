using System;
namespace OOPassignment
{
	public class Point: IPoint
	{
		public Point(int x, int y)
		{
            X = x;
            Y = y;
		}

        public int X { get; set; }
        public int Y { get; set; }

        public double CalculateDistance(int x, int y)
        {
            return x * x + y * y;
        }
    }
}

