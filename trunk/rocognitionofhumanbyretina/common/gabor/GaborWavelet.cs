using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

class GaborWavelet
{
    Bitmap sourceIrisImage;
    int[,] irisCodeRealPartMatrix;
    int[,] irisCodeImaginaryPartMatrix;
    Image irisCodeRealPartPicture;
    Image irisCodeImaginaryPartPicture;
    int radiiCount = 60;

    public GaborWavelet(Image image)
    {
        sourceIrisImage = new Bitmap(image);

        irisCodeRealPartMatrix = new int[10, radiiCount];
        irisCodeImaginaryPartMatrix = new int[10, radiiCount];
        CalcIrisCode();
    }

    private int RealCodeBit(int teta0, int r0, double alpha, double beta, double omega)
    {
        int bit = 0;
        double integral = 0;

        for (int i = r0; i < r0 + 6; i++)
            for (int k = teta0; k < teta0 + 6; k++)
            {
                integral = integral + i * sourceIrisImage.SourceHalftoneMatrix[i, k] *
                    Math.Cos(omega * (teta0 + 3 - k)) * Math.Exp(-Math.Pow((r0 + 3 - i) / alpha, 2)) *
                    Math.Exp(-Math.Pow((teta0 + 3 - k) / beta, 2));
            }
        if (integral >= 0)
        {
            bit = 1;
        }
        else if (integral < 0)
        {
            bit = 0;
        }

        return bit;
    }

    private int ImaginaryCodeBit(int teta0, int r0, double alpha, double beta, double omega)
    {
        int bit = 0;
        double integral = 0;

        for (int i = r0; i < r0 + 6; i++)
            for (int k = teta0; k < teta0 + 6; k++)
            {
                integral = integral + i * sourceIrisImage.SourceHalftoneMatrix[i, k] *
                    Math.Sin(omega * (teta0 + 3 - k)) * Math.Exp(-Math.Pow((r0 + 3 - i) / alpha, 2)) *
                    Math.Exp(-Math.Pow((teta0 + 3 - k) / beta, 2));
            }
        if (integral >= 0)
        {
            bit = 1;
        }
        else if (integral < 0)
        {
            bit = 0;
        }

        return bit;
    }

    public void CalcIrisCode()
    {
        double alpha = 0.15;
        double beta = 0.3;
        double v = 0;
        double u = 0;
        double omega = Math.Sqrt(v * v + u * u);
        int teta0 = 0;
        int rad0 = 0;


        for (int z = 0; z < 10; z++)
        {
            for (int i = 0; i < radiiCount; i++)
            {
                irisCodeRealPartMatrix[z, i] = RealCodeBit(teta0, rad0, alpha, beta, omega);
                irisCodeImaginaryPartMatrix[z, i] = ImaginaryCodeBit(teta0, rad0, alpha, beta, omega);
                teta0 = teta0 + 6;
                v = v + 200;
                u = u + 200;
                omega = Math.Sqrt(v * v + u * u);
            }
            teta0 = 0;
            alpha = alpha + 0.15;
            beta = beta + 0.15;
            rad0 = rad0 + 6;
        }
    }

    public Image IrisCodeRealPartPicture()
    {
        Bitmap newImage = new Bitmap(radiiCount, 10, PixelFormat.Format16bppArgb1555);

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 60; j++)
            {
                if (irisCodeRealPartMatrix[i, j] == 0)
                {
                    Color col = Color.FromArgb(255, 255, 255);
                    newImage.SetPixel(j, i, col);
                }
                else if (irisCodeRealPartMatrix[i, j] == 1)
                {
                    Color col = Color.FromArgb(0, 0, 0);
                    newImage.SetPixel(j, i, col);
                }
            }
        irisCodeRealPartPicture = (Image)newImage;
        return irisCodeRealPartPicture;
    }

    public Image IrisCodeImaginaryPartPicture()
    {
        Bitmap newImage = new Bitmap(radiiCount, 10, PixelFormat.Format16bppArgb1555);

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 60; j++)
            {
                if (irisCodeImaginaryPartMatrix[i, j] == 0)
                {
                    Color col = Color.FromArgb(255, 255, 255);
                    newImage.SetPixel(j, i, col);
                }
                else if (irisCodeImaginaryPartMatrix[i, j] == 1)
                {
                    Color col = Color.FromArgb(0, 0, 0);
                    newImage.SetPixel(j, i, col);
                }
            }
        irisCodeImaginaryPartPicture = (Image)newImage;
        return irisCodeImaginaryPartPicture;
    }
}
