// E Krupczak
// 10 May 2016
// must include /reference:System.Drawing.dll /reference:System.Windows.Forms.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//using System.Text;
//using System.Printing;
//using System.Internal;
//using System.Imaging;
//using System.Design;


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
//					bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/800.0)*255))));
					bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Cos(Xcount/100.0)*255)),(int)(Math.Abs(Math.Sin(Xcount/100.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/100.0)*255))));
					
					//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
					//bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
				}
			}
		}
	}
	public static void Main()
	{
		var shape = new Shapes();

		Bitmap bmp = new Bitmap(2560,1600);
		Graphics g = Graphics.FromImage(bmp);
		//g.FillRectangle(Brushes.Green, 0, 0, 50, 50);
		
		for (int Xcount = 0; Xcount < bmp.Width; Xcount++)
		{
			for (int Ycount = 0; Ycount < bmp.Height; Ycount++)
			{
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/100.0)*255)/2),(int)(Math.Abs(Math.Cos(Xcount/100.0)*255)/2),(int)(Math.Abs(Math.Cos(Ycount/100.0)*255)/2)));
				bmp.SetPixel(Xcount,Ycount,Color.FromArgb((int)(Math.Abs(Math.Sin(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Xcount/800.0)*255)),(int)(Math.Abs(Math.Cos(Ycount/800.0)*255))));
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Ycount%256,Xcount%256,(Xcount*Ycount)%256));
				//bmp.SetPixel(Xcount, Ycount, Color.FromArgb(((Xcount-55)%256+256)%256,Ycount%256,(Xcount+Ycount)%256));
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(Xcount%256,Ycount%256,(Xcount+Ycount)%256));
				//bmp.SetPixel(Xcount,Ycount,Color.FromArgb(0,0,0));
			}
		}


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
		bmp.Save("desktop.png", System.Drawing.Imaging.ImageFormat.Png);
		bmp.Dispose();



	}
}

