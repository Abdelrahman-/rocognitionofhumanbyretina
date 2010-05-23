using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

    class Gabor1D: Gabor
    {
        private byte[,] gaborRealCodeArray1D;
        private byte[,] gaborImCodeArray1D;

        public byte[,] GaborRealCodeArray1D
        {
            get { return gaborRealCodeArray1D; }
        }
        public byte[,] GaborImCodeArray1D
        {
            get { return gaborImCodeArray1D; }
        }

        public Gabor1D(Bitmap bmp)
            : base(bmp)
        {
        }

        public void CalculateKernel1D(byte[,] im, int Orientation, int Frequency, int width, int height)
        {
            Init();

            double real, img;
            byte bitIm = 0, bitReal = 0;
            double integralReal = 0;
            double integralIma = 0;

            byte[,] codeArrayReal = new byte[width, height];
            byte[,] codeArrayIma = new byte[width, height];
            int k = 0;
            int length = (GaborWidth - 1) * GaborHeight;

            for (int x = 0, i = 0; i < width; i++)
                for (int j = 0; j < height; j++, x++)
                {
                    k = 0;

                    for (k = j - 3; k < j + 3; k++)
                    {
                        try
                        {
                            if (!(j + k < 0) || !(im.Length < j + k))
                            {
                                real = KernelRealPart1D(k, Orientation, Frequency);
                                img = KernelImgPart1D(k, Orientation, Frequency);

                                integralReal = integralReal + im[i, k] * real;
                                integralIma = integralIma + im[i, k] * img;
                            }
                        }
                        catch (Exception exc)
                        {
                            //nothing
                        }
                    }

                    if (integralReal >= 0)
                    {
                        bitReal = 1;
                    }
                    else if (integralReal < 0)
                    {
                        bitReal = 0;
                    }

                    codeArrayReal[i, j] = bitReal;

                    if (integralIma >= 0)
                    {
                        bitIm = 1;
                    }
                    else if (integralIma < 0)
                    {
                        bitIm = 0;
                    }
                    codeArrayIma[i, j] = bitIm;
                    integralReal = 0;
                    integralIma = 0;
                }
            gaborRealCodeArray1D = codeArrayReal;
            gaborImCodeArray1D = codeArrayIma;
        }

        private double KernelRealPart1D(int x, int Orientation, int Frequency)
        {
            double U, V;
            double Sigma, Kv, Qu;
            double tmp1, tmp2;

            U = Orientation;
            V = Frequency;
            Sigma = 2 * Math.PI * Math.PI;
            Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
            Qu = U * Math.PI / 8;

            tmp1 = Math.Exp(-(Kv * Kv * (x * x) / (2 * Sigma)));
            tmp2 = Math.Cos(Kv * Math.Cos(Qu) * x - Math.Exp(-(Sigma / 2)));

            return tmp1 * tmp2 * Kv * Kv / Sigma;
        }

        private double KernelImgPart1D(int x, int Orientation, int Frequency)
        {
            double U, V;
            double Sigma, Kv, Qu;
            double tmp1, tmp2;

            U = Orientation;
            V = Frequency;
            Sigma = 2 * Math.PI * Math.PI;
            Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
            Qu = U * Math.PI / 8;

            tmp1 = Math.Exp(-(Kv * Kv * (x * x) / (2 * Sigma)));
            tmp2 = Math.Sin(Kv * Math.Cos(Qu) * x - Math.Exp(-(Sigma / 2)));

            return tmp1 * tmp2 * Kv * Kv / Sigma;
        }
    }