using System;
using System.Collections.Generic;
using System.Linq;

namespace IT2040FinalProjectBenKite
{
    public class MusicStatsReport
    {
        public static string GenerateText(List<songName> songList)
        {
            string report = "Music Stats Report\n\n";

            if (songList.Count() < 1)
            {
                report += "No data is available.\n";
                return report;
            }


            /*
             *  How many songs received 200 or more plays?
                How many songs are in the playlist with the Genre of “Alternative”?
                How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
                What songs are in the playlist from the album “Welcome to the Fishbowl?”
                What are the songs in the playlist from before 1970?
                What are the song names that are more than 85 characters long?
                What is the longest song? (longest in Time)

             */



            var twoHundredPlays = (from song in songList where song.Plays >= 200 select song);

            report += "Number of songs that received 200 or more plays: ";
            if(twoHundredPlays.Count() > 0)
            {
                report += twoHundredPlays.Count();
            }
            else
            {
                report += "not available";
            }
            report += "\n";

            report += "Number of songs under Alternative: ";

            var alternative = from song in songList where song.Genre == "Alternative" select song;
            if(alternative.Count() > 0)
            {
                report += alternative.Count();

            }
            else
            {
                report += "not available";

            }
            report += "\n";


            report += "Number of songs under Hip-Hop/Rap: ";

            var hiphop = from song in songList where song.Genre == "Hip-Hop/Rap" select song;
            if (hiphop.Count() > 0)
            {
                report += hiphop.Count();

            }
            else
            {
                report += "not available";

            }
            report += "\n";

            report += "Songs from the album 'Welcome to the Fishbowl':\n";
            var fishbowl = from song in songList where song.Album == "Welcome to the Fishbowl" select song.Name;
            if(fishbowl.Count() > 0)
            {
                foreach(var f in fishbowl)
                {
                    report += f + ',';
                }
                report.TrimEnd(',');
                report += "\n";
            }
            else
            {
                report += "not available";
            }

            report += "Songs from before 1970: \n";
            var beforeSeventy = from song in songList where song.Year < 1970 select song.Name;
            if(beforeSeventy.Count() > 0)
            {
                foreach(var b in beforeSeventy)
                {
                    report += b + ',';

                }
                report.TrimEnd(',');
                report += "\n";
            }
            report += "Song names that are more than 85 characters long:\n";
            var songchar = from song in songList where song.Name.Count() > 85 select song.Name;
            if (songchar.Count() > 0)
            {
                foreach (var s in songchar)
                {
                    report += s + ',';

                }
                report.TrimEnd(',');
                report += "\n";

            }

            report += "The longest song (time):\n";
            var longestsong = (from song in songList orderby song.Time descending select song.Name).First();
            if(songchar.Count() > 0)
            {
                foreach(var l in songchar)
                {
                    report += l + ',';
                }
                report.TrimEnd(',');
                report += "\n";

            }

                return report;

        }
    }
}
