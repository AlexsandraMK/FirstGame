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
        public CreateWindow()
        {
            InitializeComponent();
            Return.Click += GoReturn;
            NewFamilyButton.Click += GoToFamily;
        }
        private void GoReturn(Object sender, EventArgs e)
        {
            isReturn = true;
            CreateW.Close();
            
        }

        private void GoToFamily(Object sender, EventArgs e)
        {
            Family window = new Family();
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
    }
}
