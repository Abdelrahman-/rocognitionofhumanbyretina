using System;

namespace Gabor
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");      
			GaborTest g = new GaborTest();
            g.GaborTransform();

            //FFTGaborTest fg = new FFTGaborTest();
            //fg.FFTGaborTransform();
		}
	}
}
