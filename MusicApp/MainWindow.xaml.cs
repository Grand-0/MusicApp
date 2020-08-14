using MusicApp.Control;
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
        List<string> CompositionList = new List<string>();
        string path = "";
        int CompositionNumber;

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            if (Pause.IsChecked == true)
                media.Pause();
            else media.Play();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NextComposition.ChangeComposition(CompositionList, media, ref CompositionNumber);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PreviousComposition.ChangeComposition(CompositionList, media, ref CompositionNumber);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VolumeSlider.Minimum = 0;
            VolumeSlider.Maximum = 100;
            media.Volume = VolumeSlider.Value;
        }

        private void TreakSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (media.Source != null)
            {
                TreakSlider.Maximum = media.NaturalDuration.TimeSpan.TotalMinutes;
                media.Position = TimeSpan.FromMinutes(TreakSlider.Value);
                media.Play();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetPath_Click(object sender, RoutedEventArgs e)
        {
            CompositionNumber = 0;

            path = Take_Path.Text;

            foreach (string d in MusicSearcher.SearchPathMusic(path))
            {
                CompositionList.Add(d);
            }

            ListBox.ItemsSource = CompositionList;

            StartComposition.PlayStartComposition(CompositionList, media, CompositionNumber);

            EndTimeComposition.Content = media.Position.TotalSeconds.ToString();
        }
    }
}
