using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace Local_OpenCvSharp.Extensions
{
    public static class ImageRotator
    {
        public static Mat Rotate(this Mat src, double angle)
        {
            var imageCenter = new Point2f(src.Cols / 2f, src.Rows / 2f);
            var rotationMat = Cv2.GetRotationMatrix2D(imageCenter, angle, 1);
            var dst = new Mat();
            Cv2.WarpAffine(src, dst, rotationMat, src.Size());
            return dst;
        }

    }
}
