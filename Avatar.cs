using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlappyFirb
{
    class Avatar
    {
        public Image Image { get; private set; } 
        public Avatar(string link, int x = 50)
        {
            Uri uri = new Uri(link);
            BitmapImage bitmap = new BitmapImage(uri);
            this.Image = new Image();
            Image.Source = bitmap;
            Image.Width = x;
            Image.Height = x;
        }
    }
}
