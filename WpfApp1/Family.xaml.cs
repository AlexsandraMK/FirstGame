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
    /// Логика взаимодействия для Family.xaml
    /// </summary>
    public partial class Family : Window
    {
        bool isReturn = false;
        public Family()
        {
            InitializeComponent();
            Return.Click += GoReturn;
            InfoButton.Click += OpenOrCloseInfo;

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
