﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace rocognitionofhumanbyretina.common
{
    class BitmapService
    {
        public static Bitmap ByteToBmp(byte[,] imgByteArray)
        {
            int width = imgByteArray.GetLength(0);
            int heigh = imgByteArray.GetLength(1);

            Bitmap bmp = new Bitmap(width, heigh);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < heigh; y++)
                {
                    if (imgByteArray[x,y]==0)
                        bmp.SetPixel(x,y,Color.FromArgb(0,0,0));
                        //bmp.SetPixel(x, y, Color.FromArgb(imgByteArray[x, y], imgByteArray[x, y], imgByteArray[x, y]));
                    else
                        bmp.SetPixel(x,y,Color.FromArgb(255,255,255));
                        //bmp.SetPixel(x, y, Color.FromArgb(imgByteArray[x, y], imgByteArray[x, y], imgByteArray[x, y]));
                }
            return bmp;
        }

        public byte[] bmpToByte(Image image)
        {
            return bmpToByte(new Bitmap(image));
        }

        public byte[] bmpToByte(Bitmap image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return memoryStream.GetBuffer();
        }

        public Bitmap ByteToBmp(byte[] imgByteArray)
        {
            return new Bitmap(new MemoryStream(imgByteArray));
        }

        public double HD(byte[] image1, byte[] image2)
        {
            return HD(ByteToBmp(image1), ByteToBmp(image2));
        }

        public double HD(Bitmap image1, Bitmap image2)
        {
            int maxX = image1.Width;
            int maxY = image1.Height;

            int min = 999999;

            double deltaX = maxX * 0.05;

            for (int i = 0; i < deltaX; i++)
            {
                int sum = 0;

                for (int x = (maxX / 4) + i; x < (maxX * 3 / 4 + i); x++)
                    for (int y = 0; y < (maxY * 2 / 3); y++)
                    {
                        if (image1.GetPixel(x, y).ToArgb() != image2.GetPixel(x, y).ToArgb())
                            sum++;
                    }

                if (sum < min)
                    min = sum;
            }

            //return (min / (maxX * maxY));
            return min;
        }
    }
}
