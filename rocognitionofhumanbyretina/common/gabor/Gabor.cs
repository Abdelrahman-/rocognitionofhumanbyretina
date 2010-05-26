using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

    abstract public class Gabor
    {
        protected byte[,] image;
        protected int GaborWidth = 101, GaborHeight = 101;

        protected double[,] KernelRealData, KernelImgData;

        public Gabor(Bitmap bmp)
        {
            PrepareImage(bmp);
        }

        public byte[,] Image
        {
            get { return image; }
        }

        public void PrepareImage(Bitmap bmp)
        {
            image = new byte[bmp.Height, bmp.Width];

            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    image[y, x] = (byte)ColorToGray(bmp.GetPixel(x, y));
        }

        private int ColorToGray(Color color)
        {
            int gray = (color.R + color.G + color.B) / 3;

            if (gray < 0) gray = 0;
            if (gray > 255) gray = 255;

            return gray;
        }

        public void Init()
        {
            KernelRealData = new double[GaborWidth, GaborHeight];
            KernelImgData = new double[GaborWidth, GaborHeight];
        }
    }

