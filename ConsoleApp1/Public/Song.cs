using System;
using System.Collections.Generic; 

namespace Exercises
{ 

    public class Song
    {
        private string name;
        public Song NextSong { get; set; }

        public Song(string name)
        {
            this.name = name;
        }

        public bool IsRepeatingPlaylist()
        {
            /*hashset é o mais performatico, recursão houve perda de desempenho*/
            HashSet<string> playedSongs = new HashSet<string>();

            var current = this;
            playedSongs.Add(current.name);

            while (true)
            {
                if (current.NextSong == null) return false;
                if (playedSongs.Contains(current.NextSong.name)) return true;

                playedSongs.Add(current.NextSong.name);
                current = current.NextSong;
            }

        }

        public static void Run()
        {
            Song first = new Song("Hello");
            Song second = new Song("Eye of the tiger");
            Song third = new Song("Final Countdown");
            Song fourth = new Song("Eye of the tiger");

            first.NextSong = second;
            second.NextSong = third;
            third.NextSong = fourth;
            fourth.NextSong = first;

            /*qualquer musica q repetir ja é considerado true*/
            Console.WriteLine(first.IsRepeatingPlaylist());
        }
    }
}
