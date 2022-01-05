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
        public Family()
        {
            InitializeComponent();
            Return.Click += GoReturn;
        }

        private void GoReturn(Object sender, EventArgs e)
        {

            this.Close();
            this.Owner.Visibility = Visibility.Visible;
        }
    }
}
