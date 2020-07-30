using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        MediaPlayer media = new MediaPlayer();
        List<string> treakWay = Music.TreaksWay();
        int treakCount = 0;

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if(Pause.IsChecked == true)
            {
                media.Play();
            }
            else
            {
                media.Pause();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> treakName = Music.TreakName();
            for (int i = 0; i < treakName.Count; i++)
            {
                Content = treakName[i] + "/n";
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();

            treakCount++;

            if (treakCount <= Music.TreakCount())
            {
                media.Open(new Uri(treakWay[treakCount], UriKind.Absolute));
            }
            else
            {
                treakCount = 0;
                media.Open(new Uri(treakWay[treakCount], UriKind.Absolute));
            }

            media.Play();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();

            treakCount--;

            if (treakCount <= -1)
            {
                treakCount = Music.TreakCount();
                media.Open(new Uri(treakWay[treakCount], UriKind.Absolute));
            }
            else
            {
                media.Open(new Uri(treakWay[treakCount], UriKind.Absolute));
            }

            media.Play();
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VolumeSlider.Maximum = 100;
            VolumeSlider.Minimum = 0;
        }

        private void TreakSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TreakSlider.Maximum = media.NaturalDuration.TimeSpan.TotalMinutes;
            media.Pause();
            media.Position = TimeSpan.FromMinutes(TreakSlider.Value);
            media.Play();
        }

    }
}
