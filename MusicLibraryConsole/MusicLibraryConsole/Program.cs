using MusicLibraryConsole;
using MusicLibraryConsole.ConsoleApp;
using MusicLibraryConsole.GetEndpoints;
using System.Net;

namespace MusicLibraryConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu();
            consoleMenu.ConsoleOptions();
        }
    }
}
