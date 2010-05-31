using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace rocognitionofhumanbyretina
{
    class Threshold
    {
        private static double threshold1d = double.MaxValue;
        private static double threshold2d = double.MaxValue;

        public static double Threshold1d
        {
            get { return threshold1d; }
            set { threshold1d = value; }
        }

        public static double Threshold2d
        {
            get { return threshold2d; }
            set { threshold2d = value; }
        }

        public static double calc(LineItem line1, LineItem line2)
        {
            if (line1.Points[0].X > line2.Points[0].X)
                return line1.Points[0].X;
            else
                return line2.Points[0].X;
        }
    }
}
