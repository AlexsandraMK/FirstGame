using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Family.xaml
    /// </summary>
    public partial class Family : Window
    {
        bool isReturn = false;
        Ghost ghost;
        public Family(string FamilyCode)
        {
           
            // Чтение с сервера информации о призраке
            InitializeComponent();
            ghost = new Ghost(GhostHome, Ghost);
            GhostPhoto.Background = new ImageBrush( ghost.ghostPhoto);
            Money.Fill = new ImageBrush(new BitmapImage(new Uri("Images/money.png", UriKind.Relative)));
            GiveFood.Background = new ImageBrush(new BitmapImage(new Uri("Images/rollton.png", UriKind.Relative)));
            GiveClean.Background = new ImageBrush(new BitmapImage(new Uri("Images/broom.png", UriKind.Relative)));
            GiveTeach.Background = new ImageBrush(new BitmapImage(new Uri("Images/book.png", UriKind.Relative)));
            Emotion.Fill = new ImageBrush(new BitmapImage(new Uri("Images/heart.png", UriKind.Relative)));
            FamilyCodeTextBox.Text = FamilyCode;
        }

        private void LoadedWindow(object sender, EventArgs e)
        {
            
           

            GhostHome.Height = MainGrid.RowDefinitions[0].ActualHeight;
            GhostHome.Width = MainGrid.ColumnDefinitions[0].ActualWidth;

            ActionsCanvas.Height = InfoAndActionsGrid.RowDefinitions[1].ActualHeight;
            ActionsCanvas.Width = InfoAndActionsGrid.ActualWidth;

            double left = ActionsCanvas.Width / 2 - GiveFood.Width / 2;
            Canvas.SetLeft(GiveFood, left);
            Canvas.SetLeft(GiveClean, left);
            Canvas.SetLeft(GiveTeach, left);


            int koeffHeight = 1;
            double centerHeightItem = GiveFood.Height / 2;
            double top = ActionsCanvas.Height / 4;
            Canvas.SetTop(GiveFood, top * koeffHeight++ - centerHeightItem);
            Canvas.SetTop(GiveClean, top * koeffHeight++ - centerHeightItem);
            Canvas.SetTop(GiveTeach, top * koeffHeight++ - centerHeightItem);

        }

        private void Move(Button obj, double ghostX, double ghostY)
        {
            TimeSpan begin = TimeSpan.FromSeconds(0);
            TimeSpan duration = TimeSpan.FromSeconds(1);


            TranslateTransform toGhost = new TranslateTransform();
            obj.RenderTransform = toGhost;

            DoubleAnimation animXto = new DoubleAnimation
            {
                To = ghostX,
                Duration = duration,
                BeginTime = begin,
                SpeedRatio = 0.5,
                FillBehavior = FillBehavior.Stop
            };
            toGhost.BeginAnimation(TranslateTransform.XProperty, animXto);

            DoubleAnimation animYto = new DoubleAnimation
            {
                To = ghostY,
                Duration = duration,
                BeginTime = begin,
                SpeedRatio = 0.5,
                FillBehavior = FillBehavior.Stop
            };
            toGhost.BeginAnimation(TranslateTransform.YProperty, animYto);

            DoubleAnimation invis = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = duration,
                BeginTime = duration + begin,
                FillBehavior = FillBehavior.Stop
            };
            obj.BeginAnimation(OpacityProperty, invis);

        }

        private void GiveTeachToGhost(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Move(button,
                - (GhostHome.Width - ghost.fromLeft + ActionsCanvas.Width / 2),
                -(GhostHome.Height - ghost.fromTop ) + ActionsCanvas.Height - Canvas.GetTop(button) - button.Height);
        }

        private void GiveCleanToGhost(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Move(button,
                -(GhostHome.Width - ghost.fromLeft + ActionsCanvas.Width / 2),
                -(GhostHome.Height - ghost.fromTop) + ActionsCanvas.Height - Canvas.GetTop(button) - button.Height);
        }

        private void GiveFoodToGhost(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Move(button,
                -(GhostHome.Width - ghost.fromLeft + ActionsCanvas.Width / 2),
                -(GhostHome.Height - ghost.fromTop) + ActionsCanvas.Height - Canvas.GetTop(button) - button.Height/2);
        }

        private void OpenOrCloseInfo(Object sender, EventArgs e)
        {
            Info.Visibility = (Info.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ShowEmotion(object sender, RoutedEventArgs e)
        {
            ObjectAnimationUsingKeyFrames animate = new ObjectAnimationUsingKeyFrames
            {
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };

            DiscreteObjectKeyFrame kf1 = new DiscreteObjectKeyFrame
            {
                Value = Visibility.Visible,
                KeyTime = TimeSpan.FromSeconds(0)
            };
            animate.KeyFrames.Add(kf1);

            Emotion.BeginAnimation(VisibilityProperty, animate);
        }

        private void GoReturn(Object sender, EventArgs e)
        {
            isReturn = true;
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
        }

        private void StopTimer(object sender, EventArgs e)
        {
            ghost.timer.Stop();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            if (isReturn)
            {
                this.Owner.Visibility = Visibility.Visible;
            }
            else
            {
                this.Owner.Close();
                Application.Current.Shutdown();
            }
        }


    }


    public partial class Ghost : Window
    {
        public double  fromLeft = 0;
        public double fromTop = 0;
        Canvas Home;
        StackPanel ghost;
        public ImageSource ghostPhoto;
        public System.Windows.Threading.DispatcherTimer timer;
        public Ghost(Canvas Home, StackPanel ghost)
        {
            this.Home = Home;
            this.ghost = ghost;
            ghostPhoto = new BitmapImage(new Uri("Images/Female/1.png", UriKind.Relative));
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += Move;
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
        }

        public void Move(object sender, EventArgs e)
        {
            Canvas.SetLeft(ghost, fromLeft);
            Canvas.SetTop(ghost, fromTop);

            Random random = new Random();
            double toLeft = random.Next((int)(-fromLeft),(int)(Home.Width - fromLeft - ghost.ActualWidth));
            double toTop = random.Next((int)(-fromTop),(int)(Home.Height - fromTop - ghost.ActualHeight));

            TranslateTransform GhostFly = new TranslateTransform();
            ghost.RenderTransform = GhostFly;

            DoubleAnimation animX = new DoubleAnimation
            {
                From = 0,
                To = toLeft,
                Duration = TimeSpan.FromSeconds(2)
            };
            GhostFly.BeginAnimation(TranslateTransform.XProperty, animX);

            DoubleAnimation animY = new DoubleAnimation
            {
                From = 0,
                To = toTop,
                Duration = TimeSpan.FromSeconds(2)
            };
            GhostFly.BeginAnimation(TranslateTransform.YProperty, animY);

            fromLeft += toLeft;
            fromTop += toTop;
        }
    }
}
