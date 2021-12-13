using System;
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
using System.Media;

namespace BlappyFirb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        Birb Birb;
        List<User> Users;
        List<Trap> Traps;
        int score = 120;
        int ticker = 0;
        int difficulty = 0;
        string nickname = "";
        int birbChoice = 0;
        string usersPath = "assets/Users.txt";
        public MainWindow()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            Users = LoadUsers(usersPath);
            InitializeComponent();
        }
        private void StartClick(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            title.Visibility = Visibility.Collapsed;
            ActualScoreText.Visibility = Visibility.Visible;
            ActualScoreText.Text = "Score: " + score.ToString();

            Birb = new Birb(40, 50, 250, birbChoice);
            Traps = new List<Trap>();
            score = 120;
            ticker = 0;

            CanvasGame.Children.Add(Birb.Image);
            Canvas.SetLeft(Birb.Image, Birb.XPosition);
            Canvas.SetTop(Birb.Image, Birb.YPosition);

            dispatcherTimer.Start();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            foreach (UIElement element in CanvasGame.Children)
            {
                if (element.Uid == "login")
                {
                    element.Visibility = Visibility.Visible;
                }
            }
            title.Visibility = Visibility.Collapsed;
            login.Visibility = Visibility.Visible;
        }
        private void DifficultyClick(object sender, RoutedEventArgs e)
        {
            difficulty = difficulty == 2 ? 0 : ++difficulty;
            
            if(difficulty == 0)
                difficultyBtn.Background = new SolidColorBrush(Colors.LightGreen);
         
            if(difficulty == 1)
                difficultyBtn.Background = new SolidColorBrush(Colors.Orange);

            if(difficulty == 2)
                difficultyBtn.Background = new SolidColorBrush(Colors.Red);
        }
        private void LoginConfirmClick(object sender, RoutedEventArgs e)
        {
            nickname = nicknameInput.Text;

            CleanBoard();
            foreach(UIElement element in CanvasGame.Children)
            {
                if(element.Uid == "home")
                {
                    element.Visibility = Visibility.Visible;
                }
            }
            loginBtn.Content = nickname != "" && nickname != "Nickname" ? "Hello " + nickname + "!" : "Login";
        }
        private void QuitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Birb1Click(object sender, RoutedEventArgs e)
        {
            birbChoice = 0;

            birb1Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb2Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb3Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb4Btn.Background = new SolidColorBrush(Colors.Transparent);

            birb1Btn.Background = new SolidColorBrush(Colors.Red);
        }
        private void Birb2Click(object sender, RoutedEventArgs e)
        {
            birbChoice = 1;

            birb1Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb2Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb3Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb4Btn.Background = new SolidColorBrush(Colors.Transparent);

            birb2Btn.Background = new SolidColorBrush(Colors.Red);
        }
        private void Birb3Click(object sender, RoutedEventArgs e)
        {
            birbChoice = 2;

            birb1Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb2Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb3Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb4Btn.Background = new SolidColorBrush(Colors.Transparent);

            birb3Btn.Background = new SolidColorBrush(Colors.Red);
        }
        private void Birb4Click(object sender, RoutedEventArgs e)
        {
            birbChoice = 3;

            birb1Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb2Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb3Btn.Background = new SolidColorBrush(Colors.Transparent);
            birb4Btn.Background = new SolidColorBrush(Colors.Transparent);

            birb4Btn.Background = new SolidColorBrush(Colors.Red);
        }
        private void halloffameButton(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            foreach (UIElement element in CanvasGame.Children)
            {
                if (element.Uid == "halloffame")
                {
                    element.Visibility = Visibility.Visible;
                }
            }
            title.Visibility = Visibility.Collapsed;
            halloffame.Visibility = Visibility.Visible;
            returnButton.Visibility = Visibility.Visible;

            Users.Sort((a, b) =>
            {
                int tempa = a.highScore;
                int tempb = b.highScore;

                if (tempa > tempb)
                    return -1;
                if (tempa < tempb)
                    return 1;
                return 0;
            });

            firstPlace.Text = "1. " + Users[0].nickname + " score: " + Users[0].highScore;
            firstPlace.Visibility = Visibility.Visible;

            secondPlace.Text = "2. " + Users[1].nickname + " score: " + Users[1].highScore;
            secondPlace.Visibility = Visibility.Visible;

            thirdPlace.Text = "3. " + Users[2].nickname + " score: " + Users[2].highScore;
            thirdPlace.Visibility = Visibility.Visible;

            fourthPlace.Text = "4. " + Users[3].nickname + " score: " + Users[3].highScore;
            fourthPlace.Visibility = Visibility.Visible;

            fifthPlace.Text = "5. " + Users[4].nickname + " score: " + Users[4].highScore;
            fifthPlace.Visibility = Visibility.Visible;

        }
        private void instructionsClick(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            foreach (UIElement element in CanvasGame.Children)
            {
                if (element.Uid == "halloffame")
                {
                    element.Visibility = Visibility.Visible;
                }
            }
            title.Visibility = Visibility.Collapsed;
            instructions.Visibility = Visibility.Visible;
            returnButton.Visibility = Visibility.Visible;

            ScoreText.Visibility = Visibility.Visible;
            ScoreText.Inlines.Add(new Run{ Text= "Gra polega na przelatywaniu ptakiem pomiędzy przeszkodami\n"});
            ScoreText.Inlines.Add(new Run { Text = "Aby podlecieć do góry, należy użyć spacji.\n" });
            ScoreText.Inlines.Add(new Run { Text = "Trzeba również uważać, aby nie podlecieć zbyt wysoko i nie uderzyć w górną przeszkodę." });
        }
        private void returnClick(object sender, RoutedEventArgs e)
        {
            CleanBoard();
            foreach (UIElement element in CanvasGame.Children)
            {
                if (element.Uid == "home")
                {
                    element.Visibility = Visibility.Visible;
                }
            }
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
                Traps.Add(new Trap(difficulty));
                CanvasGame.Children.Add(Traps[Traps.Count - 1].UpperTrap);
                CanvasGame.Children.Add(Traps[Traps.Count - 1].DownTrap);
                ticker = 0;
            }

            ticker++;
            Birb.Fly();
            Canvas.SetTop(Birb.Image, Birb.YPosition);

            if (Canvas.GetLeft(secondBackground) > 0)
            {
                Canvas.SetLeft(firstBackground, Canvas.GetLeft(firstBackground) - 1);
                Canvas.SetLeft(secondBackground, Canvas.GetLeft(secondBackground) - 1);
            }
            else
            {
                Canvas.SetLeft(firstBackground, 0);
                Canvas.SetLeft(secondBackground, 900);
            }

            foreach (var trap in Traps)
            {
                SetTrapPosition(trap);
            }
            if (Traps[0].XPosition < -40)
            {
                CanvasGame.Children.Remove(Traps[0].UpperTrap);
                CanvasGame.Children.Remove(Traps[0].DownTrap);
                Traps.RemoveAt(Traps.IndexOf(Traps[0]));
            }

            if (Traps[0].XPosition + Traps[0].UpperTrap.Width == Birb.XPosition)
            {
                score++;
                ActualScoreText.Text = "Score: " + score.ToString();
            }

            CheckGame(Birb, Traps[0]);
        }
        private void CheckGame(Birb birb, Trap trap)
        {
            if (birb.YPosition > 500 || ((birb.YPosition - birb.Size/2 >= trap.DownPosition || birb.YPosition <= trap.UpperPosition - birb.Size/2 + 350 /* trap height */) && 
                (trap.XPosition < 65 && trap.XPosition + 50 > 50 )))
            {
                SoundPlayer sound = new SoundPlayer("assets/lose.wav");
                sound.Load();
                sound.Play();

                dispatcherTimer.Stop();
                gameover.Visibility = Visibility.Visible;
                ScoreText.Visibility = Visibility.Visible;
                ScoreText.Text = "Your Score: " + score.ToString();
                Canvas.SetLeft(quitBtn, 450);
                ActualScoreText.Text = "Score: " + score.ToString();
                quitBtn.Visibility = Visibility.Visible;
                retryBtn.Visibility = Visibility.Visible;

                if(nickname != "")
                {
                    bool meet = false;
                    foreach(var x in Users)
                    {
                        if(x.nickname == nickname && x.highScore < score)
                        {
                            x.highScore = score;
                            meet = true;
                        }
                    }
                    if(meet == false)
                    {
                        Users.Add(new User(nickname, birbChoice, score));
                    }
                }

                string UsersString = "";
                foreach(var x in Users)
                {
                    UsersString += x.nickname + " " + x.birbSprite + " " + x.highScore + "\n";
                    System.Diagnostics.Debug.WriteLine(x.nickname);

                }
                System.Diagnostics.Debug.WriteLine(UsersString);
                System.IO.File.WriteAllText(usersPath, UsersString);
            }
        }
        private void SetTrapPosition(Trap t)
        {
            t.Move();

            Canvas.SetTop(t.UpperTrap, t.UpperPosition);
            Canvas.SetLeft(t.UpperTrap, t.XPosition);

            Canvas.SetTop(t.DownTrap, t.DownPosition);
            Canvas.SetLeft(t.DownTrap, t.XPosition);
        }
        private List<User> LoadUsers(string path)
        {
            try
            {
                List<User> tmpUsers = new List<User>();
                string[] TempUsers = System.IO.File.ReadAllLines(path);
                for (int i = 0; i < TempUsers.Length; i++)
                {
                    if (TempUsers[i].Split(' ').Length == 3)
                    {
                        string tmpNickname = TempUsers[i].Split(' ')[0];
                        int tmphighScore = int.Parse(TempUsers[i].Split(' ')[2]);
                        int tmpbirb = int.Parse(TempUsers[i].Split(' ')[1]);
                        tmpUsers.Add(new User(tmpNickname, tmpbirb, tmphighScore));
                    }
                }
                return tmpUsers;
            }
            catch (InvalidOperationException e)
            {
                throw new Exception("Could not load a file: " + e);
            }
        }
        private void CleanBoard()
        {
            foreach (UIElement element in CanvasGame.Children)
            {
                element.Visibility = Visibility.Collapsed;
            }
            firstBackground.Visibility = Visibility.Visible;
            secondBackground.Visibility = Visibility.Visible;
            title.Visibility = Visibility.Visible;
        }
    }
}
