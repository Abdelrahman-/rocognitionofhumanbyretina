using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace rocognitionofhumanbyretina.common
{
    class BitmapService
    {
        public byte[] bmpToByte(Bitmap image)
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return memoryStream.GetBuffer();
        }

        public Bitmap ByteToBmp(byte[] imgByteArray)
        {
            return new Bitmap(new MemoryStream(imgByteArray));
        }
    }
}
