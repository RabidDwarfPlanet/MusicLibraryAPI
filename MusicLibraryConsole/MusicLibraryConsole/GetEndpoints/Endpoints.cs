using MusicLibraryConsole.ConsoleApp;
using MusicLibraryConsole.Models;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicLibraryConsole.GetEndpoints
{
    internal class Endpoints
    {
        private string url = "https://localhost:7042/api/Songs";

        public List<Song> GetAllEndpoint()
        {
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> responce = client.GetAsync(url);

            HttpResponseMessage responceMessage = responce.Result;
            Task<string> responceData = responceMessage.Content.ReadAsStringAsync();
            string data = responceData.Result;

            List<Song> songs = JsonSerializer.Deserialize<List<Song>>(data);

            client.Dispose();

            return songs;

            
        }

        public Song GetIdEndpoint(int Id)
        {
            HttpClient client = new HttpClient();
            Task<HttpResponseMessage> responce = client.GetAsync(url + "/" + Id);

            HttpResponseMessage responceMessage = responce.Result;
            Task<string> responceData = responceMessage.Content.ReadAsStringAsync();
            string data = responceData.Result;

            Song song = JsonSerializer.Deserialize<Song>(data);

            client.Dispose();

            return song;
            
        }

        public void DeleteSongEndpoint(int id)
        {
            HttpClient client = new HttpClient();
            client.DeleteAsync(url + "/" + id);

            client.Dispose();
        }

        public Song PostSongEndpoint(Song songToSend)
        {
            HttpClient client = new HttpClient();

            string jsonSong = JsonSerializer.Serialize(songToSend);
            StringContent content = new StringContent(jsonSong, Encoding.UTF8, "application/json");

            var response = (client.PostAsync(url, content).Result.Content.ReadAsStringAsync()).Result;

            Song song = JsonSerializer.Deserialize<Song>(response);
            return song;
        }

        public Song PatchSongEndpoint(SongUpdaterDTO songUpdate, int id)
        {
            HttpClient client = new HttpClient();

            string jsonSong = JsonSerializer.Serialize(songUpdate);
            StringContent content = new StringContent(jsonSong, Encoding.UTF8, "application/json");



            var response = (client.PatchAsync(url + "/" + id, content).Result.Content.ReadAsStringAsync()).Result;

            Song song = JsonSerializer.Deserialize<Song>(response);
            return song;
        }
    }
}
