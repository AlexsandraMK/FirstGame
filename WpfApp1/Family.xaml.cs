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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Family.xaml
    /// </summary>
    public partial class Family : Window
    {
        bool isReturn = false;
        public Family(string FamilyCode)
        {


            // Чтение с сервера информации о призраке
            InitializeComponent();

            

            FamilyCodeTextBox.Text = FamilyCode;
            Return.Click += GoReturn;
            InfoButton.Click += OpenOrCloseInfo;
            GiveFood.Click += GiveFoodToGhost;
            GiveClean.Click += GiveCleanToGhost;
            GiveTeach.Click += GiveTeachToGhost;
        }

        private void Open(object sender, EventArgs e)
        {
            Canvas.SetLeft(GiveFood, ActionsCanvas.Width / 2 - GiveFood.Width / 2);
            Canvas.SetLeft(GiveTeach, ActionsCanvas.Width / 2 - GiveTeach.Width / 2);
            Canvas.SetLeft(GiveClean, ActionsCanvas.Width / 2 - GiveClean.Width / 2);

            double koeffHeight = 1;
            Canvas.SetTop(GiveFood, ActionsCanvas.Height / 4 * koeffHeight++ - GiveFood.Height / 2);
            Canvas.SetTop(GiveTeach, ActionsCanvas.Height / 4 * koeffHeight++ -GiveFood.Height / 2);
            Canvas.SetTop(GiveClean, ActionsCanvas.Height / 4 * koeffHeight - GiveFood.Height / 2);
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
            Move(GiveTeach, 50, -50);
        }

        private void GiveCleanToGhost(object sender, RoutedEventArgs e)
        {
            Move(GiveClean, 50, -50);
        }

        private void GiveFoodToGhost(object sender, RoutedEventArgs e)
        {
            Move(GiveFood, 50, -50);
        }

        private void OpenOrCloseInfo(Object sender, EventArgs e)
        {
            Info.Visibility = (Info.Visibility == Visibility.Collapsed) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoReturn(Object sender, EventArgs e)
        {
            isReturn = true;
            this.Owner.Visibility = Visibility.Visible;
            this.Close();
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
            }
        }
    }
}
