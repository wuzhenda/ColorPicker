using System.Windows;
using System.Windows.Media;
using Bitmap = System.Drawing.Bitmap;
using Graphics = System.Drawing.Graphics;
using Size = System.Drawing.Size;

namespace ColorPicker
{
    internal class PointColorPicker
    {
        private static Bitmap cache = new Bitmap(1, 1);
        private static Graphics tempGraphics = Graphics.FromImage(cache);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Color GetColorFromPoint(Point point)
        {
            tempGraphics.CopyFromScreen((int)point.X, (int)point.Y, 0, 0, new Size(1, 1));

            return cache.GetPixel(0, 0).Upgrade();
        }
    }
}
