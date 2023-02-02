using System;
namespace OOPassignment
{
	public class Rectangle
	{
		private int length;
		private int width;
		public void AcceptDetials(int inputL, int inputW)
		{
			length = inputL;
			width = inputW;
		}
		public double GetArea()
		{
			return length * width;
		}
	}
}

