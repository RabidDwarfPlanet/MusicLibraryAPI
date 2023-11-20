namespace MusicLibraryAPI.GetEndPoint
{
    public class GetEndpoint
    {
        private string url = "https://localhost:7042/api/Songs";
        public void GetAllEndpoint()
        {
            HttpClient client = new HttpClient();
            client.GetAsync(url);
            client.Dispose();
        }
    }
}
