using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MediaPlayer mp;

        public App()
        {
            mp = new MediaPlayer();
            mp.Open(new Uri("music.wav", UriKind.Relative));
            mp.Volume = 0.025;
            mp.Play();
        }
            

    }
}
