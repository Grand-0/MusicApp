using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace MusicApp.Control
{
    public class NextComposition
    {
        public static void ChangeComposition(List<string> compositions, MediaPlayer player, ref int compositionNumber)
        {
            compositionNumber++;

            if (compositions.Count > compositionNumber)
            {
                player.Open(new Uri (compositions.ElementAt(compositionNumber), UriKind.Absolute));
            }
            else
            {
                player.Open(new Uri(compositions.ElementAt(0), UriKind.Absolute));
                compositionNumber = 0;
            }
            player.Play();
        }
    }
}
