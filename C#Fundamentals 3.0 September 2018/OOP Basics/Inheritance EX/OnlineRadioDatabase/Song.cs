using OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private string songLenght;

        public Song(string artistName, string songName, string songLenght)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongLenght = songLenght;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                this.artistName = value;
            }

        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                this.songName = value;
            }
        }

        public string SongLenght
        {
            get { return this.songLenght; }
            set
            {
                IsValid(value);
                this.songLenght = value;
            }
        }

        public void IsValid(string value)
        {
            string[] arr = value.Split(":");

            bool minutes = int.TryParse(arr[0], out int m);
            bool seconds = int.TryParse(arr[1], out int s);

            if (!minutes || !seconds)
            {
                throw new InvalidSongLengthException();
            }
            else if (m < 0 || m > 14)
            {
                throw new InvalidSongMinutesException();
            }
            else if (s < 0 || s > 59)
            {
                throw new InvalidSongSecondsException();
            }
        }
    }
}
