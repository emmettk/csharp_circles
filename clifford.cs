// e krupczak
// 10 May 2016
// must include /reference:System.Drawing.dll /reference:System.Windows.Forms.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DrawingShapes 
{
	public class shapes
	{
			
		public static void Main()
		{
			int width = 1024;
			int height = 1024;
			float zoom = 0.5f;
			Bitmap bmp = new Bitmap(width,height);
			Graphics g = Graphics.FromImage(bmp);
			//Background color
			g.FillRectangle(Brushes.Black, 0, 0, width, height);
			
			int trajectory_count = 3000;
			int iteration_count = 30000;
			Random random = new Random();
			//Clifford attractor parameters
			float a = 1.72f, b = -1.95f, c = 1.52f, d = 1.12f;

			for (int trajectory = 0; trajectory < trajectory_count; trajectory++){
				float x = (float)random.NextDouble();
				float y = (float)random.NextDouble();			
				
				for (int iteration = 0; iteration <iteration_count; iteration++){
					float xn = (float) (Math.Sin(a*y)+c*Math.Cos(a*x));
					float yn = (float) (Math.Sin(b*x)+d*Math.Cos(b*y));
					
					int x_index = (int) (width/2 + x*zoom*width);
					int y_index = (int) (height/2 + y*zoom*width);

					if (0 <= x_index && x_index < width && 0 <=y_index && y_index < height)
					{
						Color pixel = bmp.GetPixel(x_index, y_index);
						Color newcolor;
					//	255 0 0 46

					//	Console.WriteLine(pixel.ToArgb().ToString());

						if (-1*(pixel.ToArgb() + 16777000) >=255)
						{
							newcolor = Color.FromArgb(255);
					//		Console.WriteLine("Hello, you are in the if statement");
						}

						else
						{
							newcolor = Color.FromArgb(pixel.ToArgb()+1);
						}
						
					//	Console.WriteLine(newcolor.ToString());
						bmp.SetPixel(x_index, y_index,newcolor);
					}
					x = xn;
					y = yn;

				}
			}

			g.Dispose();
			bmp.Save("clifford.png", System.Drawing.Imaging.ImageFormat.Png);
			bmp.Dispose();



		}
	}
}




