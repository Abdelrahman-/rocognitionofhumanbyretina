﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using rocognitionofhumanbyretina.DB;
using rocognitionofhumanbyretina.common.enums;

namespace rocognitionofhumanbyretina.common
{
    class Recognification
    {
        private BitmapService bmpService = new BitmapService();

        public Peoples start(GaborTypes type, Bitmap testBmp)
        {
            Connector cn = new Connector();
            List<Peoples> peoples = cn.GetAllImages();

            double min = double.MaxValue;
            int index = -1;

            if (type == GaborTypes.WAVELET1D)
            {
                Gabor1D gabor = new Gabor1D(testBmp);
                gabor.CalculateKernel1D(gabor.Image, 45, 32, testBmp.Width, testBmp.Height);

                for (int i = 0; i < peoples.Count; i++)
                {
                    double lenght = 
                        bmpService.HD(new Bitmap(gabor.GaborRealCodeArray), bmpService.ByteToBmp(peoples[i].Token1D_AttrOne))+
                        bmpService.HD(new Bitmap(gabor.GaborImCodeArray), bmpService.ByteToBmp(peoples[i].Token1D_AttrTwo));
                    if (lenght < min && lenght < Threshold.Threshold1d)
                    {
                        min = lenght;
                        index = i;
                    }
                }
            }
            else
            {
                Gabor2D gabor = new Gabor2D(testBmp);
                gabor.CalculateKernel2D(gabor.Image, 45, 32, testBmp.Width, testBmp.Height);

                for (int i = 0; i < peoples.Count; i++)
                {
                    double lenght = 
                        bmpService.HD(new Bitmap(gabor.GaborRealCodeArray), bmpService.ByteToBmp(peoples[i].Token2D_AttrOne))+
                        bmpService.HD(new Bitmap(gabor.GaborImCodeArray), bmpService.ByteToBmp(peoples[i].Token2D_AttrTwo));
                    if (lenght < min && lenght < Threshold.Threshold2d)
                    {
                        min = lenght;
                        index = i;
                    }
                }
            }
            if (index == -1)
                return null;
            else
                return peoples[index];
        }
    }
}
