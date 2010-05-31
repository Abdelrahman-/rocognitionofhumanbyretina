using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using rocognitionofhumanbyretina.common;

class Gabor1D : Gabor
{
    public Gabor1D(Bitmap bmp)
        : base(bmp)
    {
    }

    public void CalculateKernel1D(byte[,] im, int Orientation, int Frequency, int width, int height)
    {
        double real, img;
        byte bitIm = 0, bitReal = 0;
        double integralReal = 0;
        double integralIma = 0;

        byte[,] codeArrayReal = new byte[width, height];
        byte[,] codeArrayIma = new byte[width, height];
        int k = 0;

        for (int x = 0, i = 0; i < width; i++)
            for (int j = 0; j < height; j++, x++)
            {
                integralReal = 0;
                integralIma = 0;

                for (k = j - 3; k < j + 3; k++)
                {
                    try
                    {
                        if ((k > 0) && (im.GetLength(0) > k))
                        {
                            real = KernelRealPart1D(k, Orientation, Frequency);
                            img = KernelImgPart1D(k, Orientation, Frequency);

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
        gaborRealCodeArray = BitmapService.ByteToBmp(codeArrayReal);
        gaborImCodeArray = BitmapService.ByteToBmp(codeArrayIma);
    }

    private double KernelRealPart1D(int x, int Orientation, int Frequency)
    {
        //double gamma = 4.8f;
        //double lambda = 2.3f;
        double sigma = 9.42f;
        double F = 0.1f;
        double x_ = x * Math.Cos(Orientation) + 0;
        double y_ = -x * Math.Sin(Orientation) + 0;
        double temp1 = 1 / (2 * Math.PI * sigma * sigma) * Math.Exp(-(x_ * x_ + y_ * y_) / (2 * sigma * sigma));
        double temp2 = Math.Cos(2 * Math.PI * x_ * F);
        return Frequency * temp1 * temp2;

        /*double U, V;
        double Sigma, Kv, Qu;
        double tmp1, tmp2;

        U = Orientation;
        V = Frequency;
        Sigma = 2 * Math.PI * Math.PI;
        Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        Qu = U * Math.PI / 8;

        tmp1 = Math.Exp(-(Kv * Kv * (x * x) / (2 * Sigma)));
        tmp2 = Math.Cos(Kv * Math.Cos(Qu) * x - Math.Exp(-(Sigma / 2)));

        return tmp1 * tmp2 * Kv * Kv / Sigma;*/
    }

    private double KernelImgPart1D(int x, int Orientation, int Frequency)
    {

        //double gamma = 4.8f;
        //double lambda = 2.3f;
        double sigma = 9.42f;
        double F = 0.1f;
        double x_ = x * Math.Cos(Orientation) + 0;
        double y_ = -x * Math.Sin(Orientation) + 0;
        double temp1 = 1 / (2 * Math.PI * sigma * sigma) * Math.Exp(-(x_ * x_ + y_ * y_) / (2 * sigma * sigma));
        double temp2 = Math.Sin(2 * Math.PI * x_ * F);
        return Frequency * temp1 * temp2;

        /*double U, V;
        double Sigma, Kv, Qu;
        double tmp1, tmp2;

        U = Orientation;
        V = Frequency;
        Sigma = 2 * Math.PI * Math.PI;
        Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        Qu = U * Math.PI / 8;

        tmp1 = Math.Exp(-(Kv * Kv * (x * x) / (2 * Sigma)));
        tmp2 = Math.Sin(Kv * Math.Cos(Qu) * x - Math.Exp(-(Sigma / 2)));

        return tmp1 * tmp2 * Kv * Kv / Sigma;*/
    }
}