using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GoCreate(Object sender, EventArgs e)
        {
            MainW.Visibility = Visibility.Hidden;
            CreateWindow window = new CreateWindow
            {
                Owner = this
            };
            window.ShowDialog();
        }

        private void GoFindFamily(Object sender, EventArgs e)
        {
            FindFamilyWindow window = new FindFamilyWindow
            {
                Owner = this
            };
            window.ShowDialog();
        }

        private void GoExit(Object sender, EventArgs e)
        {
            MainW.Close();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
        }

        private void GoSettings(Object sender, EventArgs e)
        {
        }
    }
}
