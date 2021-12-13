using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace BlappyFirb
{
    class User
    {
        public int birbSprite { get; set; }
        public string nickname { get; set; }
        public int highScore { get; set; }
        public User(string nickname, int birb, int highScore)
        {
            this.nickname = nickname;
            this.highScore = highScore;
            this.birbSprite = birb;
        }
    }
}
