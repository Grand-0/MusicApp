using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace MusicApp.Control
{
    public class PreviousComposition
    {
        public static void ChangeComposition(List<string> compositions, MediaPlayer player, ref int compositionNumber)
        {
            compositionNumber--;

            if (compositionNumber >= 0)
            {
                player.Open(new Uri(compositions.ElementAt(compositionNumber), UriKind.Absolute));
            }
            else
            {
                compositionNumber = compositions.Count - 1;
                player.Open(new Uri(compositions.ElementAt(compositionNumber), UriKind.Absolute));
            }
            player.Play();
        }
    }
}
