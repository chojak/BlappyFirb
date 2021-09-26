﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Controls.Primitives;

namespace BlappyFirb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        Birb Birb;
        List<Trap> Traps;
        int score = 0;
        int ticker = 0;
        public MainWindow()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            InitializeComponent();
        }
        private void StartClick(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            ActualScoreText.Visibility = Visibility.Visible;
            ActualScoreText.Text = "Score: " + score.ToString();

            Birb = new Birb(15, 50, 250);
            Traps = new List<Trap>();
            score = 0;
            ticker = 0;

            CanvasGame.Children.Add(Birb.Rectangle);
            Canvas.SetLeft(Birb.Rectangle, Birb.XPosition);
            Canvas.SetTop(Birb.Rectangle, Birb.YPosition);


            dispatcherTimer.Start();
        }
        void CanvasGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                Birb.Jump();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if(ticker%50 == 0)
            {
                Traps.Add(new Trap());
                CanvasGame.Children.Add(Traps[Traps.Count - 1].UpperTrap);
                CanvasGame.Children.Add(Traps[Traps.Count - 1].DownTrap);
                ticker = 0;
            }

            ticker++;
            Birb.Fly();
            Canvas.SetTop(Birb.Rectangle, Birb.YPosition);
            foreach(var trap in Traps)
            {
                SetTrapPosition(trap);
            }
            if (Traps[0].XPosition < -40)
            {
                CanvasGame.Children.Remove(Traps[0].UpperTrap);
                CanvasGame.Children.Remove(Traps[0].DownTrap);
                Traps.RemoveAt(Traps.IndexOf(Traps[0]));
            }

            if (CheckGame(Birb, Traps[0]))
            {
                CleanBoard();
                dispatcherTimer.Stop();
                MainText.Visibility = Visibility.Visible;
                MainText.Text = "Game Over";
                ScoreText.Visibility = Visibility.Visible;
                ScoreText.Text = "Your Score: " + score.ToString();
                quitBtn.Visibility = Visibility.Visible;
                retryBtn.Visibility = Visibility.Visible; 
            }
            if (Traps[0].XPosition + Traps[0].UpperTrap.Width == Birb.XPosition)
            {
                score++;
                ActualScoreText.Text = "Score: " + score.ToString();
            }
        }

        private void QuitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool CheckGame(Birb birb, Trap trap)
        {
            if (birb.YPosition > 500)
            {
                dispatcherTimer.Stop();
                return true;
            }
            else if ((birb.YPosition >= trap.DownPosition || birb.YPosition <= trap.UpperPosition) &&
            (trap.XPosition < 65 && trap.XPosition + 50 > 50 ))
            {
                return true;
            }
            return false;
        }
        private void SetTrapPosition(Trap t)
        {
            t.Move();

            Canvas.SetTop(t.UpperTrap, 0);
            Canvas.SetLeft(t.UpperTrap, t.XPosition);

            Canvas.SetTop(t.DownTrap, t.DownPosition);
            Canvas.SetLeft(t.DownTrap, t.XPosition);
        }
        private void CleanBoard()
        {
            foreach (UIElement element in CanvasGame.Children)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
    }
}