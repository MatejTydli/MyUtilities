using System;
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
			return (int)Math.Round(Math.Abs(Pythagor(Math.Abs(x.X - y.X), Math.Abs(x.Y - y.Y))));
		}

		public static double DistanceBetween2Points(PointF x, PointF y)
		{
			return Math.Abs(Pythagor(Math.Abs(x.X - y.X), Math.Abs(x.Y - y.Y)));
		}

		public static Speed2 SpeedBetween2Points(int speed, Point x, Point y)
		{
			var d = (int)Math.Round((double)DistanceBetween2Points(x,y) / speed);
			var speed2 = new Speed2((y.X - x.X) / d, (y.Y - x.Y) / d);
			
			return speed2;
		}

		public static Speed2F SpeedBetween2Points(int speed, PointF x, PointF y)
		{
			double d = DistanceBetween2Points(x, y) / speed;
			var speed2F = new Speed2F((y.X - x.X) / d, (y.Y - x.Y) / d);

			return speed2F;
		}

		public struct Speed2
		{
			public int X;
			public int Y;

			public Speed2(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}
		}

		public struct Speed2F
		{
			public double X;
			public double Y;

			public Speed2F(double x, double y)
			{
				this.X = x;
				this.Y = y;
			}
		}
		#endregion

		#region other my math functions 
		public static double Pythagor(double a, double b)
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
			var result = 1;
			for (var i = 1; i <= n; i++) result *= i;

			return result;
		}
		#endregion
	}
}