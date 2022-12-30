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
			var result = -1;

			if (x.X - y.X != 0 && x.Y - y.Y != 0)
				result = (int)Math.Round(Pythagor(Math.Abs(x.X - y.X), Math.Abs(x.Y - y.Y)));
			else if (x.X - y.X == 0) result = x.Y - y.Y;
			else if (x.Y - y.Y == 0) result = x.X - y.X;

			return Math.Abs(result);
		}

		public static double DistanceBetween2Points(PointF x, PointF y)
		{
			double result = -1;

			if (x.X - y.X != 0 && x.Y - y.Y != 0)
				result = Pythagor(Math.Abs(x.X - y.X), Math.Abs(x.Y - y.Y));
			else if (x.X - y.X == 0) result = x.Y - y.Y;
			else if (x.Y - y.Y == 0) result = x.X - y.X;

			return Math.Abs(result);
		}

		public static Speed2 SpeedBetween2Points(int speed, Point x, Point y)
		{
			double d = DistanceBetween2Points(x, y) / speed;
			var speed2 = new Speed2((x.X - y.X) / (int)Math.Round(d), (x.Y - y.Y) / (int)Math.Round(d));
			
			return speed2;
		}

		public static Speed2F SpeedBetween2Points(int speed, PointF x, PointF y)
		{
			double d = DistanceBetween2Points(x, y) / speed;
			var speed2F = new Speed2F((x.X - y.X) / d, (x.Y - y.Y) / d);

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