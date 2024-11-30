using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using Microsoft.SPOT.Presentation.Media;

namespace Conway
{
    public class Painter
    {
        private readonly int _pixelSize;

        private readonly Bitmap _bitmap;

        public Painter(int pixelSize)
        {
            _pixelSize = pixelSize;

            int screenWidth, screenHeight, bitsPerPixel, orientationDeg;
            HardwareProvider.HwProvider.GetLCDMetrics(
                out screenWidth, out screenHeight, out bitsPerPixel, out orientationDeg);
            _bitmap = new Bitmap(screenWidth, screenHeight);
        }

        public void AddCell(int x, int y)
        {
            int xPos = x * _pixelSize;
            int yPos = y * _pixelSize;
            _bitmap.DrawRectangle(Colors.Orange, 1, xPos, yPos, _pixelSize, _pixelSize, 0, 0, Colors.Yellow, xPos, yPos, 0, 0, 0, 255);
        }

        public void Paint()
        {
            _bitmap.Flush();
        }

        public void Clear()
        {
            _bitmap.Clear();
        }
    }
}
