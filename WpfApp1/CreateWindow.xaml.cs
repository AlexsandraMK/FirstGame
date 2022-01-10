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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        bool isReturn = false;
        bool isGoToFamily = false;
        string path = "Female";
        string photo = "1";
        string uri;

        public CreateWindow()
        {
            InitializeComponent();
            uri = "Images/"+ path + "/portrait_" + photo + ".png";
            Ghost.Fill = new ImageBrush(new BitmapImage(new Uri(uri, UriKind.Relative)));
        }

        private void GoReturn(Object sender, EventArgs e)
        {
            isReturn = true;
            CreateW.Close(); 
        }

        private void GoToFamily(Object sender, EventArgs e)
        {
            Family window = new Family("Новый код");
            window.Owner = CreateW.Owner;
            isGoToFamily = true;
            CreateW.Close();

            window.ShowDialog();
        }

        private void CloseWindow(object sender, EventArgs e)
        {
            if(isReturn)
            {
                CreateW.Owner.Visibility = Visibility.Visible;
            } 
            else
            {
                if (!isGoToFamily)
                {
                    CreateW.Owner.Close();
                }
            }
            
        }

        private void NameGhostChanged(object sender, TextChangedEventArgs args) =>
            NewFamilyButton.IsEnabled = !string.IsNullOrEmpty(NameGhost.Text);

        private void ChooseGhost(object sender, RoutedEventArgs e)
        {
            RadioButton chBox = (RadioButton)sender;
            if (chBox.GroupName == "Gender") path = chBox.Content.ToString();

            if (chBox.GroupName == "Appearance") photo = chBox.Content.ToString();

            uri = "Images/" + path + "/portrait_" + photo + ".png";
            Ghost.Fill = new ImageBrush(new BitmapImage(new Uri(uri, UriKind.Relative)));

        }

    }
}
