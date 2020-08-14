using System.Collections.Generic;
using System.IO;

namespace MusicApp
{
    static class MusicSearcher
    {
        public static List<string> SearchPathMusic(string path)
        {
            List<string> musicPath = new List<string>();
            string[] format = { "*.wav", "*.aiff", "*.ape", "*.flac", "*.mp3", "*.ogg" };

            foreach(string f in format)
            {
                string[] dir = Directory.GetFiles(path, f);
                musicPath.AddRange(dir);
            }

            return musicPath;
        }
    }
}
