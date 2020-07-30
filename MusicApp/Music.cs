using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp
{
    class Music
    {
        public static List<string> TreakName()
        {
            List<string> treakName = new List<string>();
            var dir = new DirectoryInfo(@"D:/Progects/C# PRO/MusicApp/MusicApp/Music");
            foreach(FileInfo file in dir.GetFiles())
            {
                treakName.Add(dir.Name);
            }
            return treakName;
        }

        public static List<string> TreaksWay()
        {
            List<string> treaksWay = new List<string>();
            var dir = new DirectoryInfo(@"D:/Progects/C# PRO/MusicApp/MusicApp/Music");
            foreach (FileInfo file in dir.GetFiles())
            {
                treaksWay.Add(file.FullName);
            }
            return treaksWay;
        }

        public static int TreakCount()
        {
            List<string> lid = TreaksWay();
            int treakCount = lid.Count;
            return treakCount;
        }

        public static int TreakVolume()
        {
            int volume = 0;
            return volume;
        }

        public static int TreakLenght
        {

        }
    }
}
