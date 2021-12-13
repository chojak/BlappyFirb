using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlappyFirb
{
    public class Birb
    {
        public int YPosition { get; private set; }
        public int XPosition;
        public Image Image { get; private set; }
        public int Size { get; private set; }
        int gravitySpeed;
        public Birb(int size, int XPosition, int YPosition, int source)
        {
            this.Size = size;
            this.YPosition = YPosition;
            this.XPosition = XPosition;
            string birdPath = source == 0 ? "assets/bird1.png" : source == 1 ? "assets/bird2.png" : source == 2 ? "assets/bird3.png" : source == 3 ? "assets/bird4.png" : "assets/bird1.png";
            Image = new Image();
            Image.Source = new BitmapImage(new Uri("C:/" + birdPath));
            Image.Width = size;
            Image.Height = size;
        }
        public void Jump()
        {
            gravitySpeed = -10;
        }
        public void Fly()
        {
            if (YPosition < -20)
                YPosition = -20;
            else
                YPosition += gravitySpeed;

            if (gravitySpeed < 20)
                gravitySpeed += 1;

            float angleHelper = gravitySpeed + 10;
            var tmp = (angleHelper / 30);
            var angle = -45 + tmp * 90;

            Image.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            Image.RenderTransform = new RotateTransform(angle);
        }
    }
}
