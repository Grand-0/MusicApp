using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace MusicApp.Control
{
    public class StartComposition
    {
        public static void PlayStartComposition(List<string> compositions, MediaPlayer player, int compositionNumber)
        {
            player.Open(new Uri(compositions.ElementAt(compositionNumber), UriKind.Absolute));
            player.Play();
        }
    }
}
