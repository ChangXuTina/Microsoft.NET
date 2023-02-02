using System;
namespace OOPassignment
{
	interface IPoint
	{
		int X { get; set; }
		int Y { get; set; }
		double CalculateDistance(int x, int y);
	}
}

