using System.Drawing;

namespace Utils.Drawing
{
	public static class DrawingUtils
	{
		public static Image RotateImage(Image image, float angle)
		{
			float height = image.Height;
			float width = image.Width;
			int hypotenuse = (int)System.Math.Floor(Math.Pythagor(width, height));
			Bitmap rotatedImage = new Bitmap(hypotenuse, hypotenuse);
			Graphics g = Graphics.FromImage(rotatedImage);

			g.TranslateTransform((float)rotatedImage.Width / 2, (float)rotatedImage.Height / 2);
			g.RotateTransform(angle);
			g.TranslateTransform(-(float)rotatedImage.Width / 2, -(float)rotatedImage.Height / 2);
			g.DrawImage(image, (hypotenuse - width) / 2, (hypotenuse - height) / 2, width, height);

			return rotatedImage;
		}
	}
}