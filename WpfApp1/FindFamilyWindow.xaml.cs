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
    /// Логика взаимодействия для FindFamilyWindow.xaml
    /// </summary>
    public partial class FindFamilyWindow : Window
    {
        private string[] AllFamilyCodes;

        public FindFamilyWindow()
        {
            // Связь с сервером для доставания существующих кодов семьи
            AllFamilyCodes = new string[10];
            AllFamilyCodes[0] = "4";

            InitializeComponent();
        }
        private void GoToFamily(Object sender, EventArgs e)
        {
            // Проверка на существующий код семьи
            if(!AllFamilyCodes.Any(n => n == FamilyCode.Text))
            {
                MessageBox.Show("Вы ввели неверный код семьи");
            }
            else
            {
                this.Owner.Visibility = Visibility.Hidden;
                Family window = new Family(FamilyCode.Text)
                {
                    Owner = this.Owner
                };
                this.Close();
                
                
                window.ShowDialog();
            }


            
        }

        private void FamilyCodeChanged(object sender, TextChangedEventArgs args) =>
            GoToFamilyButton.IsEnabled = !string.IsNullOrEmpty(FamilyCode.Text);
    }
}
