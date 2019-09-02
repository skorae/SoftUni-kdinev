using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace OnlineRadioDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            TimeSpan time = new TimeSpan(0, 0, 0);

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(";");

                try
                {
                    string artistName = arr[0];
                    string songName = arr[1];
                    string songLenght = arr[2];

                    songs.Add(new Song(artistName, songName, songLenght));
                   time =  AddTime(time, songLenght);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");

            Console.WriteLine($"Playlist length: {time.Hours}h {time.Minutes}m {time.Seconds}s");
        }

        private static TimeSpan AddTime(TimeSpan time, string songLenght)
        {
            string[] arr = songLenght.Split(":");

            int minutes = int.Parse(arr[0]);
            int seconds = int.Parse(arr[1]);

            TimeSpan temp = new TimeSpan(0, minutes, seconds);

           return time = time.Add(temp);
        }
    }
}
