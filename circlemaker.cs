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
			Bitmap bmp = new Bitmap(1024,1024);
			Graphics g = Graphics.FromImage(bmp);
			//g.FillRectangle(Brushes.Green, 0, 0, 50, 50);

			for (int Xcount = 0; Xcount < bmp.Width; Xcount++)
			{
				for (int Ycount = 0; Ycount < bmp.Height; Ycount++)
				{
				//	bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
//					if ((Math.Pow(Xcount,2)+Math.Pow(Ycount,2)) < (Math.Pow(100,2)))
//					{
//					       	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,100,100));
//					//	System.Console.WriteLine(Math.Pow(Xcount,2));
//					}
//					else bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
//
					if ((Math.Pow(Xcount-200,2)+Math.Pow(Ycount-200,2))<(Math.Pow(100,2)))
					{
					//	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,0,0));
				//		bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
						bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
				
					}

					else if ((Math.Pow(Xcount-800,2)+Math.Pow(Ycount-800,2))<(Math.Pow(100,2)))
					{
					//	bmp.SetPixel(Xcount,Ycount,Color.FromArgb(255,0,0));
				//		bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
						bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
				
					}
					else bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));

				}

			}


			g.Dispose();
			bmp.Save("testimage1.png", System.Drawing.Imaging.ImageFormat.Png);
			bmp.Dispose();



		}
	}
}

