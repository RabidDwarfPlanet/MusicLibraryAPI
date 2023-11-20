using MusicLibraryConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryConsole.ConsoleApp
{
    internal class ConsoleMethods
    {
        public Song CreateNewSong()
        {
            Console.Clear();
            Song song = new Song();
            Console.WriteLine("Please input the songs name");
            var title = Console.ReadLine();
            Console.WriteLine("Please input the artists name");
            var artist = Console.ReadLine();
            Console.WriteLine("Please input the albums name or leave blank if it was a single");
            var album = Console.ReadLine();
            Console.WriteLine("Please input the songs genre");
            var genre = Console.ReadLine();
            Console.WriteLine("Please input the songs name");
            bool num = false;
            int year = 0;
            int month = 0;
            int day = 0;
            Console.WriteLine("What year was the song released (YYYY)");
            while (!num)
            {
                num = int.TryParse(Console.ReadLine(), out year);
                if (!num || year > 9999) { Console.WriteLine("Please write the year as a 4 diget number (YYYY)"); }
            }
            Console.WriteLine("What month was the song released (MM)");
            num = false;
            while (!num)
            {
                num = int.TryParse(Console.ReadLine(), out month);
                if (!num) { Console.WriteLine("Please write the year as a 2 diget number (MM)"); }
                if (month > 12) { Console.WriteLine("That is not a valid month, please try again"); }
            }
            Console.WriteLine("What day was the song released (DD)");
            num = false;
            while (!num)
            {
                num = int.TryParse(Console.ReadLine(), out day);
                if (!num) { Console.WriteLine("Please write the year as a 2 diget number (MM)"); }
                if (day > 31) { Console.WriteLine("That is not a valid day, please try again"); }
            }
            DateTime date = new DateTime(year, month, day);

            song.title = title;
            song.artist = artist;
            if (album == "") { song.album = null; }
            else { song.album = album; }
            song.genre = genre;
            song.releaseDate = date;

            return song;
        }
    }
}
