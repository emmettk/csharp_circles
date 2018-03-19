// E Krupczak
// 10 May 2016 - updated with comments, 19 Mar 2018
//
// Make an image of the specified resolution comprised of a colorful background and colorful circles
// Various options for the mathematical equation used to color the background and the circles
//
// When compiling with mcs: mcs /reference:System.Drawing.dll /reference:System.Windows.Forms.dll desktopmaker.cs
// When compiling on Windows: C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe desktopmaker.cs

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class Shapes
{
	public void DrawCircle(int X, int Y, int radius, Bitmap bmp)
	{
		for (int Xcount = X-radius; Xcount < X+radius; Xcount++)
		{
			for (int Ycount = Y-radius; Ycount < Y+radius; Ycount++)
			{
				if ((Math.Pow(Xcount-X,2)+Math.Pow(Ycount-Y,2))<(Math.Pow(radius,2)) && Ycount >= 0 && Ycount < bmp.Height && Xcount >= 0 && Xcount < bmp.Width)
				{
					//Choose coloration of circles, which will be "cut" from a continuously colored background. 
					//These are just examples; tweaking the parameters will produce a variety of patterns

					//Uncomment one of the following:

					//Solid black
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));

					//Small waves: Red varies with cosine, Green varies with sine, Blue varies with cosine
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Cos(Xcount/100.0)*255)),(int)(Math.Abs(Math.Sin(Xcount/100.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/100.0)*255))));
					
					//Medium waves:  Red varies with sine, Green varies with cosine, Blue varies with cosine
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/200.0)*255)),(int)(Math.Abs(Math.Cos(Xcount/200.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/200.0)*255))));
					
					//Large waves:  Red varies with sine, Green varies with cosine, Blue varies with cosine
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/800.0)*255))));

					//Gradient grid (sum version): Interlaced right triangles
					bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
					
					//Gradient grid (sum version), offset: Striped squares
					//bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));

					//Gradient grid (product version): Subtle, lacy grid-within-a-grid
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Ycount%256,Xcount%256,(Xcount*Ycount)%256));
				}
			}
		}
	}
	public static void Main()
	{
		var shape = new Shapes();

		//Set pixel dimensions of output image (i.e. dimensions of your desktop display)
		Bitmap bmp = new Bitmap(2560,1600); //Macbook pro
		//Bitmap bmp = new Bitmap(3840,2160); //PVPIV Samsung monitor
		Graphics g = Graphics.FromImage(bmp);
		
		for (int Xcount = 0; Xcount < bmp.Width; Xcount++)
		{
			for (int Ycount = 0; Ycount < bmp.Height; Ycount++)
			{
				//Choose color of background. Similar choices to DrawCircle color options.

				//Uncommment one of the following: 

				//Solid black
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));

				//Small waves, darker (pixel brightness divided by 2 relative to circles' small waves)
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/100.0)*255)/2),(int)(Math.Abs(Math.Cos(Xcount/100.0)*255)/2),(int)(Math.Abs(Math.Cos(Ycount/100.0)*255)/2)));

				//Large waves
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/800.0)*255))));

				//Gradient grid (sum version)
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));

				//Gradient grid (sum version), offset
				//bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));

				//Gradient grid (product version)
				bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Ycount%256,Xcount%256,(Xcount*Ycount)%256));
			}
		}


		//Choose locations and sizes of circles
		shape.DrawCircle(800,300,100,bmp);
		shape.DrawCircle(200,150,090,bmp);
		shape.DrawCircle(800,800,70,bmp);
		shape.DrawCircle(350,400,250,bmp);
		shape.DrawCircle(1500,200,100,bmp);
//		shape.DrawCircle(2100,1300,150,bmp);
		shape.DrawCircle(2200,1000,190,bmp);
		shape.DrawCircle(1100,0900,150,bmp);
		shape.DrawCircle(500,1300,100,bmp);
		shape.DrawCircle(2500,1500,150,bmp);
		g.Dispose();

		//Save image
		bmp.Save("desktop.png", System.Drawing.Imaging.ImageFormat.Png);
		bmp.Dispose();



	}
}

