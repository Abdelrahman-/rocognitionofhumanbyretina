using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public class Gabor2D
{
	private int[,] image;
    private int GaborWidth = 101, GaborHeight = 101;
    private double[,] KernelRealData, KernelImgData;

    public GaborResult GaborTransform(Bitmap img)
	{
		PrepareImage(img);
		GaborResult result = new GaborResult();
		GaborTransform(image, 0, 0, result);
        return result;
	}

    private void PrepareImage(Bitmap bmp)
	{
        image = new int[bmp.Height, bmp.Width];

        for(int y=0; y<bmp.Height; y++)
			for(int x=0; x<bmp.Width; x++)
				image[y,x]=ColorToGray(bmp.GetPixel(x,y));
	}

	private int ColorToGray(Color color)
	{
		//Gray = 0.299 * R + 0.587 * G + 0.114 * B
		//µ±И»°СёЎµгФЛЛгИ₮µфЈ¬¶јУГХыКэФЛЛг»бёьүмЈөGary = (R * 77 + G * 151 + B * 28) >> 8; 
		//int gray = ((((color.R * 77) + (color.G * 151)) + (color.B * 28)) >> 8);
        int gray = (color.R + color.G + color.B) / 3;

		if(gray<0) gray=0;
		if(gray>255) gray=255;

		return gray;
	}

	public void Init()
	{
		KernelRealData = new double[GaborWidth, GaborHeight];
		KernelImgData = new double[GaborWidth, GaborHeight];
	}

	#region CalculateKernel && KernelRealPart && KenrelImgPart

	private void CalculateKernel(int Orientation, int Frequency)
	{
		Init();

		double real, img;

		for(int x = -(GaborWidth-1)/2; x<(GaborWidth-1)/2+1; x++)
			for(int y = -(GaborHeight-1)/2; y<(GaborHeight-1)/2+1; y++)
			{
				real = KernelRealPart(x, y, Orientation, Frequency);
				img = KernelImgPart(x, y, Orientation, Frequency);

				KernelRealData[x+(GaborWidth-1)/2, y+(GaborHeight-1)/2] = real;
				KernelImgData[x+(GaborWidth-1)/2, y+(GaborHeight-1)/2] = img;
			}
	}

	private double KernelRealPart(int x, int y, int Orientation, int Frequency)
	{
		double U, V;
		double Sigma, Kv, Qu;
		double tmp1, tmp2;

		U = Orientation;
		V = Frequency;
		Sigma = 2 * Math.PI * Math.PI;
		Kv = Math.PI * Math.Exp((-(V+2)/2)*Math.Log(2, Math.E));
		Qu = U * Math.PI  / 8;

		tmp1 = Math.Exp(-(Kv * Kv * ( x*x + y*y)/(2 * Sigma)));
		tmp2 = Math.Cos(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma/2));

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
		Kv = Math.PI * Math.Exp((-(V+2)/2)*Math.Log(2, Math.E));
		Qu = U * Math.PI  / 8;

		tmp1 = Math.Exp(-(Kv * Kv * ( x*x + y*y)/(2 * Sigma)));
		tmp2 = Math.Sin(Kv * Math.Cos(Qu) * x + Kv * Math.Sin(Qu) * y) - Math.Exp(-(Sigma/2));

		return tmp1 * tmp2 * Kv * Kv / Sigma;	
	}

	#endregion

	#region GaborTransform

	public void GaborTransform(int[,] image, int Orientation, int Frequency, GaborResult result)
	{
		CalculateKernel(Orientation, Frequency);

		int imgWidth = image.GetLength(1);
		int imgHeight = image.GetLength(0);

		double real=0, img=0;

		double[,] tmpMag = new double[imgHeight, imgWidth];

		for(int y=0; y < imgHeight; y++)
			for(int x=0; x < imgWidth; x++)
			{
				for(int y1=0; y1 < GaborHeight; y1++)
					for(int x1=0; x1 < GaborWidth; x1++)
					{
						if(((y - GaborHeight/2 + y1)>=0) &&
							((y - GaborHeight/2 + y1)<imgHeight) &&
							((x - GaborWidth/2 + x1)>=0) &&
							((x - GaborWidth/2 + x1)<imgWidth))
						{
							real += image[y - GaborHeight/2 + y1, x - GaborWidth/2 + x1] * KernelRealData[(GaborWidth-1) - x1, (GaborHeight-1) - y1]; 
							img += image[y - GaborHeight/2 + y1, x - GaborWidth/2 + x1] * KernelImgData[(GaborWidth-1) - x1, (GaborHeight-1) - y1]; 
						}
					}

				tmpMag[y,x] = Math.Sqrt(real*real + img*img);

				real=0;
				img=0;
			}

		double Sum=0, Avg=0, Deta=0;
		
		for(int y=0; y < imgHeight; y++)
			for(int x=0; x < imgWidth; x++)
				Sum += tmpMag[y,x];

		Avg = Sum / (imgHeight * imgWidth);

		for(int y=0; y < imgHeight; y++)
			for(int x=0; x < imgWidth; x++)
				Deta += (tmpMag[y,x] - Avg)*(tmpMag[y,x] - Avg);

		Deta = Deta / (imgHeight * imgWidth);

        result.Avg = Avg;
		result.Deta = Deta;
	}

	#endregion
}
