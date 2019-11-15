using System;
using System.Collections.Generic;
using System.IO;

namespace IT2040FinalProjectBenKite
{
    public static class MusicStatsLoader
    {
        private static int NumItemsInRow = 8;

        public static List<songName> Load(string txtFilePath)
        {
            List<songName> songList= new List<songName>();

            try
            {


                using (var reader = new StreamReader(txtFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue; //skips the first line.
                        var values = line.Split("\t"); // splits strings at tab and then puts them in values

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}");
                        }

                        try
                        {
                            // assings each column their values.
                            string name = (values[0]);
                            string artists =(values[1]);
                            string album = (values[2]);
                            string genre = (values[3]);
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);

                            songName songname = new songName(name, artists, album, genre, size, time, year, plays);
                            songList.Add(songname);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invlaid data. ({e.Message})");
                        }




                    }

                }

            }catch(FormatException e)
            {
                throw new Exception($"Unable to open {txtFilePath}. ({e.Message})");
            }




            return songList;
            
        }



       
    }
}
