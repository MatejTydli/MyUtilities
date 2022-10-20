using System;
using System.Collections.Generic;
using System.Drawing;

namespace myUtilities
{
	public static class MyMath
	{
		#region constants
		#endregion

		#region speed and distance
		public static int DistanceBetween2Points(Point x, Point y)
		{
			int a = x.X - y.X;
			int b = x.Y - y.Y;
			return (int)Math.Round(PythagoreanTheorem(a, b));
		}

		public static double DistanceBetween2Points(PointF x, PointF y)
		{
			double a = x.X - y.X;
			double b = x.Y - y.Y;
			return PythagoreanTheorem(a, b);
		}

		public static Speed2 SpeedBetween2Points(int speed, Point x, Point y)
		{
			int a = x.X - y.X;
			int b = x.Y - y.Y;
			int c = DistanceBetween2Points(x, y);
			int d = c / speed;
			Speed2 speed2 = new Speed2(a / d, b / d);

			return speed2;
		}

		public static Speed2F SpeedBetween2Points(int speed, PointF x, PointF y)
		{
			double a = x.X - y.X;
			double b = x.Y - y.Y;
			double c = DistanceBetween2Points(x, y);
			double d = c / speed;
			Speed2F speed2F = new Speed2F(a / d, b / d);

			return speed2F;
		}

		public struct Speed2
		{
			public readonly int X;
			public readonly int Y;

			public Speed2(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		public struct Speed2F
		{
			public readonly double X;
			public readonly double Y;

			public Speed2F(double x, double y)
			{
				X = x;
				Y = y;
			}
		}
		#endregion

		#region other my math functions 
		public static double PythagoreanTheorem(double a, double b)
		{
			return Math.Sqrt(a * a + b * b);
		}

		public static int Clamp(int min, int max, int value)
		{
			return Math.Max(min, Math.Min(value, max));
		}

		public static double Clamp(double min, double max, double value)
		{
			return Math.Max(min, Math.Min(value, max));
		}

		public static int Factorial(int n)
		{
			int result = 1;
			for (int i = 1; i <= n; i++)
			{
				result *= i;
			}
			return result;
		}
		#endregion
	}
}