using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace BlappyFirb
{
    class Trap
    {
        public int XPosition;
        public int UpperPosition { get; private set; }
        public int DownPosition { get; private set; }
        public Image UpperTrap { get; private set; }
        public Image DownTrap { get; private set; }

        Random rand;

        public Trap()
        {
            rand = new Random();
            UpperTrap = new Image();
            DownTrap = new Image();

            XPosition = 900;
            UpperPosition = rand.Next(50, 330);
            DownPosition = UpperPosition + 120;

            UpperTrap.Source = new BitmapImage(new Uri("assets/pipe.png", UriKind.Relative));
            UpperTrap.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            UpperTrap.RenderTransform = new RotateTransform(180);
            UpperTrap.Width = 50;
            UpperTrap.Height = 50;

            DownTrap.Source = new BitmapImage(new Uri("assets/pipe.png", UriKind.Relative));
            DownTrap.Width = 50;
            DownTrap.Height = 50;
        }
        public void Move()
        {
            XPosition -= 5;
        }
    }
}
