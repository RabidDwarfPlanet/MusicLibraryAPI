using MusicLibraryConsole.GetEndpoints;
using MusicLibraryConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryConsole.ConsoleApp
{
    public class ConsoleMenu
    {
        int option = 1;
        Endpoints endpoints = new Endpoints();
        ConsoleMethods consoleMethods = new ConsoleMethods();
        public ConsoleMenu()
        {

        }

        public void WelcomeMessage()
        {
            Console.WriteLine("Welcome to your music library!");
            Console.WriteLine("Use the arrow keys to select what you would like to do then press enter");
            Console.WriteLine();
        }

        private void ArrowKeyMovement(ConsoleKeyInfo keyInfo, int options )
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (option > 1) { option--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (option < options) { option++; }
                    break;
            }
        }

        public void ConsoleOptions()
        {
            int options = 6;
            option = 1;
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                do
                {
                    Console.Clear();
                    WelcomeMessage();
                    if (option == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Show all songs\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Show all songs\n"); }
                    if (option == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Show song by Id\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Show song by Id\n"); }
                    if (option == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Add new song\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Add new song\n"); }
                    if (option == 4) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Update song\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Update song\n"); }
                    if (option == 5) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Delete Song\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Delete Song\n"); }
                    if (option == 6) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Quit\n"); }
                    else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Quit\n"); }
                    Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                    keyInfo = Console.ReadKey();
                    ArrowKeyMovement(keyInfo, options);
                } while (keyInfo.Key != ConsoleKey.Enter);
                switch (option)
                {
                    case 1:
                        GetAll();
                        break;
                    case 2:
                        GetId();
                        break;
                    case 3:
                        PostNew();
                        break;
                    case 4:
                        PatchSong();
                        break;
                    case 5:
                        DeleteId();
                        break;
                    case 6:
                        return;
                }
            }
        }

        private void PostNew()
        {
            Song songToAdd = consoleMethods.CreateNewSong();
            Song song = endpoints.PostSongEndpoint(songToAdd);
            ConsoleKeyInfo keyInfo;
            do
            {

                Console.Clear();
                Console.WriteLine("Your song has been added");
                Console.WriteLine("Id: " + song.id);
                Console.WriteLine("Title: " + song.title);
                Console.WriteLine("Artist: " + song.artist);
                if (song.album == null) { Console.WriteLine("Single"); }
                else { Console.WriteLine("Album: " + song.album); }
                Console.WriteLine("Release Date: " + song.releaseDate.Date.ToShortDateString());
                Console.WriteLine("Genre: " + song.genre);
                Console.WriteLine("Likes: " + song.likes);
                Console.WriteLine();
                Console.WriteLine("Press escape to go back");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
            
        }

        private void GetId()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Id of the song you would like to look up");
            int Id;
            while (true)
            {
                bool num = int.TryParse(Console.ReadLine(), out Id);
                if (!num) { Console.WriteLine("That is not a valid Id, please try again"); }
                else { break; }
            }
            Song song = endpoints.GetIdEndpoint(Id);
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("Id: " + song.id);
                Console.WriteLine("Title: " + song.title);
                Console.WriteLine("Artist: " + song.artist);
                if (song.album == null) { Console.WriteLine("Single"); }
                else { Console.WriteLine("Album: " + song.album); }
                Console.WriteLine("Release Date: " + song.releaseDate.Date.ToShortDateString());
                Console.WriteLine("Genre: " + song.genre);
                Console.WriteLine("Likes: " + song.likes);
                Console.WriteLine();
                Console.WriteLine("Press escape to go back");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
            
        }

        private void DeleteId()
        {
            Console.Clear();
            Console.WriteLine("Please enter the Id of the song you would like to delete");
            int Id;
            while (true)
            {
                bool num = int.TryParse(Console.ReadLine(), out Id);
                if (!num) { Console.WriteLine("That is not a valid Id, please try again"); }
                else { break; }
            }
            Song song = endpoints.GetIdEndpoint(Id);
            endpoints.DeleteSongEndpoint(Id);
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                Console.WriteLine("You have deleted " + song.title + " from your library");
                Console.WriteLine();
                Console.WriteLine("Press escape to go back");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private void GetAll()
        {
            List<Song> songs = endpoints.GetAllEndpoint();
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                foreach (Song song in songs)
                {
                    Console.WriteLine("Id: " + song.id);
                    Console.WriteLine("Title: " + song.title);
                    Console.WriteLine("Artist: " + song.artist);
                    if (song.album == null) { Console.WriteLine("Single"); }
                    else { Console.WriteLine("Album: " + song.album); }
                    Console.WriteLine();
                }
                Console.WriteLine("Press escape to go back");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        private void PatchSong()
        {
            int options = 6;
            string optionName;
            option = 1;
            int id;
            ConsoleKeyInfo keyInfo;

            Console.Clear();
            Console.WriteLine("Please enter the Id of the song you would like to update");
            while (true)
            {
                bool num = int.TryParse(Console.ReadLine(), out id);
                if (!num) { Console.WriteLine("That is not a valid Id, please try again"); }
                else { break; }
            }
            do
            {
                Console.Clear();
                Console.WriteLine("What part of this song would you like to update");
                if (option == 1) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Title\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Title\n");}
                if (option == 2) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Artist\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Artist\n");}
                if (option == 3) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Album\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Album\n");}
                if (option == 4) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Release Date\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Release Date\n");}
                if (option == 5) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Genre\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Genre\n");}
                if (option == 6) { Console.BackgroundColor = ConsoleColor.White; Console.ForegroundColor = ConsoleColor.Black; Console.Write("Likes\n");}
                else { Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White; Console.Write("Likes\n");}
                Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.White;
                keyInfo = Console.ReadKey();
                ArrowKeyMovement(keyInfo, options);
            } while (keyInfo.Key != ConsoleKey.Enter);
            Console.Clear();
            if (keyInfo.Key == ConsoleKey.Escape) { return; }
            SongUpdaterDTO songUpdaterDTO = new SongUpdaterDTO();
            switch (option)
            {
                case 1:
                    Console.WriteLine($"What would you like to change the title to?");
                    string updatedTitle = Console.ReadLine();
                    songUpdaterDTO.Title = updatedTitle;
                    break;
                case 2:
                    Console.WriteLine($"What would you like to change the artist to?");
                    string updatedArtist = Console.ReadLine();
                    songUpdaterDTO.Artist = updatedArtist;
                    break;
                case 3:
                    Console.WriteLine($"What would you like to change the album to (Keep blank if it is a single)?");
                    string updatedAlbum = Console.ReadLine();
                    if (updatedAlbum == "") { songUpdaterDTO.Album = null; }
                    else { songUpdaterDTO.Album = updatedAlbum; }
                    break;
                case 5:
                    Console.WriteLine($"What would you like to change the genre to?");
                    string updatedGenre = Console.ReadLine();
                    songUpdaterDTO.Genre = updatedGenre;
                    break;
                case 4:
                    int year;
                    int month;
                    int day;
                    Console.WriteLine($"What would you like to change the release date to?");
                    while (true)
                    {
                        Console.Write("\nYear: ");
                        bool num = int.TryParse(Console.ReadLine(), out year);
                        if (!num) { Console.WriteLine("Please enter a number (YYYY)"); }
                        else { break; }
                    }
                    while (true)
                    {
                        Console.Write("\nMonth: ");
                        bool num = int.TryParse(Console.ReadLine(), out month);
                        if (!num) { Console.WriteLine("Please enter a number (MM)"); }
                        else { break; }
                    }
                    while (true)
                    {
                        Console.Write("\nDay: ");
                        bool num = int.TryParse(Console.ReadLine(), out day);
                        if (!num) { Console.WriteLine("Please enter a number (DD)"); }
                        else { break; }
                    }
                    DateTime date = new DateTime(year, month, day);
                    songUpdaterDTO.ReleaseDate = date;
                    break;
                case 6:
                    Console.WriteLine($"What would you like to change the likes to?");
                    int likes;
                    while (true)
                    {
                        bool num = int.TryParse(Console.ReadLine(), out likes);
                        if (!num) { Console.WriteLine("Please enter a number"); }
                        else { break; }
                    }
                    songUpdaterDTO.Likes = likes;
                    break;
            }
            Song song = endpoints.PatchSongEndpoint(songUpdaterDTO, id);
            do
            {
                Console.Clear();
                Console.WriteLine("Id: " + song.id);
                Console.WriteLine("Title: " + song.title);
                Console.WriteLine("Artist: " + song.artist);
                if (song.album == null) { Console.WriteLine("Single"); }
                else { Console.WriteLine("Album: " + song.album); }
                Console.WriteLine("Release Date: " + song.releaseDate.Date.ToShortDateString());
                Console.WriteLine("Genre: " + song.genre);
                Console.WriteLine("Likes: " + song.likes);
                Console.WriteLine();
                Console.WriteLine("Press escape to go back");
                keyInfo = Console.ReadKey();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
