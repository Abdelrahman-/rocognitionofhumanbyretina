
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Gabor
{
	/*

	public class FFTGaborTest
	{
		private int[,] image = new int[128, 128];

		public void FFTGaborTransform ()
		{
			Console.WriteLine ("   ==================== FFT Gabor Transform ===================");
			DateTime begin = DateTime.Now;
			
			PrepareImage ();
			PrepareKernel ();
			GaborResult result = new GaborResult ();
			GaborTransform (image, 0, 0, result);
			
			Console.WriteLine ();
			Console.WriteLine (" Avg = {0,10:F3}\nDeta = {1,10:F3}", result.Avg, result.Deta);
			DateTime end = DateTime.Now;
			TimeSpan ts = end - begin;
			Console.WriteLine ("Total Time used: " + ts.TotalMilliseconds + " ms\r\n");
		}

		private void PrepareImage ()
		{
			//Bitmap bmp = new Bitmap(@"D:\GaborTest.png");
			Bitmap bmp = new Bitmap ("D:\\GaborTest.png");
			//"C:\\tcap\\pics\\SYSMNG"
			
			for (int y = 0; y < 128; y++)
				for (int x = 0; x < 128; x++)
					image[y, x] = ColorToGray (bmp.GetPixel (x, y));
		}

		private int ColorToGray (Color color)
		{
			//Gray = 0.299 * R + 0.587 * G + 0.114 * B
			//µ±И»°СёЎµгФЛЛгИ₮µфЈ¬¶јУГХыКэФЛЛг»бёьүмЈөGary = (R * 77 + G * 151 + B * 28) >> 8; 
			int gray = ((((color.R * 77) + (color.G * 151)) + (color.B * 28)) >> 8);
			
			if (gray < 0)
				gray = 0;
			if (gray > 255)
				gray = 255;
			
			return gray;
		}

		#region FFTGabor

		private const int GaborWidth = 101, GaborHeight = 101;
		private Complex[] KernelFFT2 = new Complex[256 * 256];

		public void PrepareKernel ()
		{
			CalculateKernel (0, 0);
			Fourier.FFT2 (KernelFFT2, 256, 256, FourierDirection.Forward);
		}

		#region CalculateKernel && KernelRealPart && KenrelImgPart

		private void CalculateKernel (int Orientation, int Frequency)
		{
			double real, img;
			
			for (int x = -(GaborWidth - 1) / 2; x < (GaborWidth - 1) / 2 + 1; x++)
				for (int y = -(GaborHeight - 1) / 2; y < (GaborHeight - 1) / 2 + 1; y++) {
					real = KernelRealPart (x, y, Orientation, Frequency);
					img = KernelImgPart (x, y, Orientation, Frequency);
					
					KernelFFT2[(x + (GaborWidth - 1) / 2) + 256 * (y + (GaborHeight - 1) / 2)].Re = real;
					KernelFFT2[(x + (GaborWidth - 1) / 2) + 256 * (y + (GaborHeight - 1) / 2)].Im = img;
				}
		}

		private double KernelRealPart (int x, int y, int Orientation, int Frequency)
		{
			double U, V;
			double Sigma, Kv, Qu;
			double tmp1, tmp2;
			
			U = Orientation;
			V = Frequency;
			Sigma = 2 * Math.PI * Math.PI;
			Kv = Math.PI * Math.Exp ((-(V + 2) / 2) * Math.Log (2, Math.E));
			Qu = U * Math.PI / 8;
			
			tmp1 = Math.Exp (-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
			tmp2 = Math.Cos (Kv * Math.Cos (Qu) * x + Kv * Math.Sin (Qu) * y) - Math.Exp (-(Sigma / 2));
			
			return tmp1 * tmp2 * Kv * Kv / Sigma;
		}

		private double KernelImgPart (int x, int y, int Orientation, int Frequency)
		{
			double U, V;
			double Sigma, Kv, Qu;
			double tmp1, tmp2;
			
			U = Orientation;
			V = Frequency;
			Sigma = 2 * Math.PI * Math.PI;
			Kv = Math.PI * Math.Exp ((-(V + 2) / 2) * Math.Log (2, Math.E));
			Qu = U * Math.PI / 8;
			
			tmp1 = Math.Exp (-(Kv * Kv * (x * x + y * y) / (2 * Sigma)));
			tmp2 = Math.Sin (Kv * Math.Cos (Qu) * x + Kv * Math.Sin (Qu) * y) - Math.Exp (-(Sigma / 2));
			
			return tmp1 * tmp2 * Kv * Kv / Sigma;
		}

		#endregion

		#region GaborTransform

		public void GaborTransform (int[,] image, int Orientation, int Frequency, GaborResult result)
		{
			//Чј±ёНјЖ¬FFT±д»»
			Complex[] imageFFT = new Complex[256 * 256];
			Complex[] ConvolutionResult = new Complex[256 * 256];
			
			for (int y = (GaborWidth - 1) / 2; y < (GaborWidth - 1) / 2 + 128; y++)
				for (int x = (GaborWidth - 1) / 2; x < (GaborWidth - 1) / 2 + 128; x++)
					imageFFT[y * 256 + x].Re = image[y - (GaborWidth - 1) / 2, x - (GaborWidth - 1) / 2];
			
			Fourier.FFT2 (imageFFT, 256, 256, FourierDirection.Forward);
			
			//ФЪЖµУтЦґРРѕн»э
			for (int i = 0; i < 256 * 256; i++)
				ConvolutionResult[i] = imageFFT[i] * KernelFFT2[i] / (256 * 256);
			
			Fourier.FFT2 (ConvolutionResult, 256, 256, FourierDirection.Backward);
			
			//јЖЛгѕщЦµЎў·ЅІој°Ѕб№ы
			double Sum = 0, Avg = 0, Deta = 0;
			double tmpModulus = 0;
			double[,] tmpMag = new double[256, 256];
			
			for (int y = (GaborWidth - 1); y < (GaborWidth - 1) + 128; y++)
				for (int x = (GaborWidth - 1); x < (GaborWidth - 1) + 128; x++) {
					tmpModulus = ConvolutionResult[y * 256 + x].GetModulus ();
					
					Sum += tmpModulus;
					tmpMag[y, x] = tmpModulus;
				}
			
			Avg = Sum / (128 * 128);
			
			//јЖЛг·ЅІо
			for (int y = (GaborWidth - 1); y < (GaborWidth - 1) + 128; y++)
				for (int x = (GaborWidth - 1); x < (GaborWidth - 1) + 128; x++)
					Deta += (tmpMag[y, x] - Avg) * (tmpMag[y, x] - Avg);
			
			Deta = Deta / (128 * 128);
			
			//Кдіц
			for (int y = (GaborWidth - 1) + 0; y < (GaborWidth - 1) + 8; y++) {
				for (int x = (GaborWidth - 1) + 0; x < (GaborWidth - 1) + 8; x++)
					Console.Write ("{0,8:F2}", tmpMag[y, x]);
				Console.WriteLine ();
			}
			
			//·ЕЦГЅб№ы
			result.Avg = Avg;
			result.Deta = Deta;
		}
		
		#endregion
		#endregion
	}
	*/
}
