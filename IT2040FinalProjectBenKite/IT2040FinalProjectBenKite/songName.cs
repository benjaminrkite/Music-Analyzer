using System;
namespace IT2040FinalProjectBenKite
{
    public class songName
    {
        public string Name;
        public string Artists;
        public string Album;
        public string Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;


        public songName(string name, string artists, string album, string genre,
            int size, int time, int year, int plays)
        {
            Name = name;
            Artists = artists;
            Album = album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;

            
        }
    }
}
