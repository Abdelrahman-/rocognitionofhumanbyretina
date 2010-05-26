using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using rocognitionofhumanbyretina.common;
using rocognitionofhumanbyretina;

public class Gabor2D : Gabor
{
    
    public byte[,] gaborRealCodeByteArray2D;
    public byte[,] gaborImCodeByteArray2D;

   public Gabor2D(Bitmap bmp)
        : base(bmp)
    {
    }

    private double KernelRealPart(int x, int y, int Orientation, int Frequency)
    {
        double U, V;
        double Sigma, Kv, Qu;
        double tmp1, tmp2;

        U = Orientation;
        V = Frequency;
        Sigma = 2 * Math.PI * Math.PI;
        Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        Qu = U * Math.PI / 8;

        tmp1 = Math.Exp(-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
        tmp2 = Math.Cos(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma / 2));

        return tmp1 * tmp2 * Kv * Kv / Sigma;
    }

    private double KernelImgPart(int x, int y, int Orientation, int Frequency)
    {
        double U, V;
        double Sigma, Kv, Qu;
        double tmp1, tmp2;

        U = Orientation;
        V = Frequency;
        Sigma = 2 * Math.PI * Math.PI;
        Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        Qu = U * Math.PI / 8;

        tmp1 = Math.Exp(-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
        tmp2 = Math.Sin(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma / 2));

        return tmp1 * tmp2 * Kv * Kv / Sigma;

        //return Math.Cos(2*Math.PI)
    }

    public void CalculateKernel2D(byte[,] im, int Orientation, int Frequency, int width, int height)
    {
        double real, img;
        byte bitIm = 0, bitReal = 0;
        double integralReal = 0;
        double integralIma = 0;

        byte[,] codeArrayReal = new byte[width, height];
        byte[,] codeArrayIma = new byte[width, height];
        int k = 0;

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                k = 0;

                for (int l = i - 1; l < i + 2; l++)
                    for (k = j - 1; k < j + 2; k++)
                    {
                        try
                        {
                            if ((k > 0) && (im.GetLength(0) > k) && (l > 0) && (l < im.GetLength(1)))
                            {
                                real = KernelRealPart(l, k, Orientation, Frequency);
                                img = KernelImgPart(l, k, Orientation, Frequency);

                                integralReal = integralReal + im[k, l] * real;
                                integralIma = integralIma + im[k, l] * img;
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
                integralReal = 0;
                integralIma = 0;        
            }
        gaborRealCodeByteArray2D = codeArrayReal;
        gaborImCodeByteArray2D = codeArrayIma;
        gaborRealCodeArray = BitmapService.ByteToBmp(codeArrayReal);
        gaborImCodeArray = BitmapService.ByteToBmp(codeArrayIma);
    }
}
