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
        /*double temp1 = Math.Exp(-(x*x+y*y)/(0.65*Frequency));
        double temp2 = 2*Math.PI*Frequency*Math.Cos(Orientation);
        return temp1 * temp2;*/

        /////////////////////////////////
        //double gamma = 4.8f;
        //double lambda = 2.3f;
        double sigma = 9.42f;
        double F = 0.1f;
        double x_ = x * Math.Cos(Orientation) + y * Math.Sin(Orientation);
        double y_ = -x * Math.Sin(Orientation) + y * Math.Cos(Orientation);
        double temp1 = 1 / (2 * Math.PI * sigma * sigma) * Math.Exp((x_ * x_ + y_ * y_) / (2 * sigma * sigma));
        double temp2 = Math.Cos(2 * Math.PI * x_ * F);
        return Frequency * temp1 * temp2;
        /////////////////////////////////
        //double U, V;
        //double Sigma, Kv, Qu;
        //double tmp1, tmp2;

        //U = Orientation;
        //V = Frequency;
        //Sigma = 2 * Math.PI * Math.PI;
        //Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        //Qu = U * Math.PI / 8;

        //tmp1 = Math.Exp(-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
        //tmp2 = Math.Cos(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma / 2));

        //return tmp1 * tmp2 * Kv * Kv / Sigma;
    }

    private double KernelImgPart(int x, int y, int Orientation, int Frequency)
    {
        /*double temp1 = Math.Exp(-(x * x + y * y) / (0.65 * Frequency));
        double temp2 = 2 * Math.PI * Frequency * Math.Sin(Orientation);
        return temp1 * temp2;*/

        //////////////////////
        //double gamma = 4.8f;
        //double lambda = 2.3f;
        double sigma = 9.42f;
        double F = 0.1f;
        double x_ = x * Math.Cos(Orientation) + y * Math.Sin(Orientation);
        double y_ = -x * Math.Sin(Orientation) + y * Math.Cos(Orientation);
        double temp1 = 1 / (2 * Math.PI * sigma * sigma) * Math.Exp((x_ * x_ + y_ * y_) / (2 * sigma * sigma));
        double temp2 = Math.Sin(2 * Math.PI * x_ * F);
        return Frequency * temp1 * temp2;
        ////////////////////////////

        //double U, V;
        //double Sigma, Kv, Qu;
        //double tmp1, tmp2;

        //U = Orientation;
        //V = Frequency;
        //Sigma = 2 * Math.PI * Math.PI;
        //Kv = Math.PI * Math.Exp((-(V + 2) / 2) * Math.Log(2, Math.E));
        //Qu = U * Math.PI / 8;

        //tmp1 = Math.Exp(-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
        //tmp2 = Math.Sin(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma / 2));

        //return tmp1 * tmp2 * Kv * Kv / Sigma;

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
               

                for (int l = i-3 ; l < i +4; l++)
                    for (k = j-3 ; k < j +4; k++)
                    {
                        try
                        {
                            if ((k > 0) && (im.GetLength(0) > k) && (l > 0) && (l < im.GetLength(1)))
                            {
                                real = KernelRealPart(k, l, Orientation, Frequency);
                                img = KernelImgPart(k, l, Orientation, Frequency);

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

                //codeArrayReal[i, j] = (byte)Math.Round(integralReal);

                if (integralIma > 0)
                {
                    bitIm = 1;
                }
                else if (integralIma <= 0)
                {
                    bitIm = 0;
                }
                codeArrayIma[i, j] = bitIm;
                //codeArrayIma[i, j] = (byte) Math.Round(integralIma);

                integralReal = 0;
                integralIma = 0;        
            }
        gaborRealCodeByteArray2D = codeArrayReal;
        gaborImCodeByteArray2D = codeArrayIma;
        gaborRealCodeArray = BitmapService.ByteToBmp(codeArrayReal);
        gaborImCodeArray = BitmapService.ByteToBmp(codeArrayIma);
    }
}
