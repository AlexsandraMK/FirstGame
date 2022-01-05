using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            CreateGhostButton.Click += GoCreate;
            GoToFamilyButton.Click += GoFindFamily;
            Exit.Click += GoExit;
        }

        private void GoCreate(Object sender, EventArgs e)
        {
            MainW.Visibility = Visibility.Hidden;
            CreateWindow window = new CreateWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void GoFindFamily(Object sender, EventArgs e)
        {
            FindFamilyWindow window = new FindFamilyWindow();
            window.Owner = this;
            window.ShowDialog();
        }

        private void GoExit(Object sender, EventArgs e)
        {
            MainW.Close();
        }
    }
}
