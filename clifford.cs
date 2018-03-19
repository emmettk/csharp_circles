// e krupczak
// 10 May 2016
// must include /reference:System.Drawing.dll /reference:System.Windows.Forms.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//using System.Windows.Media;
//using System.Text;
//using System.Printing;
//using System.Internal;
//using System.Imaging;
//using System.Design;


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
//			for (int Xcount = 0; Xcount < bmp.Width; Xcount++)
//			{
//				for (int Ycount = 0; Ycount < bmp.Height; Ycount++)
//				{
//				//	bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
////					if ((Math.Pow(Xcount,2)+Math.Pow(Ycount,2)) < (Math.Pow(100,2)))
////					{
////					       	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,100,100));
////					//	System.Console.WriteLine(Math.Pow(Xcount,2));
////					}
////					else bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
////
//					if ((Math.Pow(Xcount-200,2)+Math.Pow(Ycount-200,2))<(Math.Pow(100,2)))
//					{
//					//	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,0,0));
//				//		bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
//						bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
//				
//					}
//
//					else if ((Math.Pow(Xcount-800,2)+Math.Pow(Ycount-800,2))<(Math.Pow(100,2)))
//					{
//					//	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,0,0));
//				//		bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
//						bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
//				
//					}
//					else bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
//
//				}
//
//			}


			g.Dispose();
			bmp.Save("clifford.png", System.Drawing.Imaging.ImageFormat.Png);
			bmp.Dispose();



		}
	}
}




