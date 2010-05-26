using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using rocognitionofhumanbyretina.common;

class Gabor1D : Gabor
{
    private Bitmap gaborRealCodeArray1D;
    private Bitmap gaborImCodeArray1D;

    public Image GaborRealCodeArray1D
    {
        get { return gaborRealCodeArray1D; }
    }
    public Image GaborImCodeArray1D
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
                integralReal = 0;
                integralIma = 0;

                for (k = j - 1; k < j + 2; k++)
                {
                    try
                    {
                        if ((k > 0) && (im.GetLength(0) > k))
                        {
                            real = KernelRealPart1D(x, Orientation, Frequency);
                            img = KernelImgPart1D(x, Orientation, Frequency);

                            integralReal = integralReal + im[k, i] * real;
                            integralIma = integralIma + im[k, i] * img;
                        }
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message);
                    }
                }

                if (integralReal > 0)
                {
                    bitReal = 1;
                }
                else if (integralReal <= 0)
                {
                    bitReal = 0;
                }

                codeArrayReal[i, j] = bitReal;

                if (integralIma > 0)
                {
                    bitIm = 1;
                }
                else if (integralIma <= 0)
                {
                    bitIm = 0;
                }
                codeArrayIma[i, j] = bitIm;
            }
        gaborRealCodeArray1D = BitmapService.ByteToBmp(codeArrayReal);
        gaborImCodeArray1D = BitmapService.ByteToBmp(codeArrayIma);
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