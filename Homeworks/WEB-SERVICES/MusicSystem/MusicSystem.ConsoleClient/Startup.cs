namespace MusicSystem.ConsoleClient
{
    using Data.Repositories;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;

    public class Startup
    {
        private static readonly IMusicSystemData musicSystemData = new MusicSystemData();

        internal static void Main()
        {
            Console.WriteLine("Loading...");
            Thread.Sleep(2000);

            Console.WriteLine("Press any key to start...");
            Console.ReadLine();

            var connection = new Uri("http://localhost:64320/");
            
            PrintXmlCountries(connection, "api/Countries");
            PrintJsonSongs(connection, "api/Songs");
            PostGenres(connection, "api/Genres");
            PutProducer(connection, "api/Producers/", 1);
            DeleteGenre(connection, "api/Genres/", 1);

            Console.ReadLine();
        }

        private static async void PrintXmlCountries(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                
                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Countries: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PrintJsonSongs(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                
                var response = await httpClient.GetAsync(requestPath);
                Console.WriteLine(Environment.NewLine + "Songs: " + await response.Content.ReadAsStringAsync());
            }
        }



        private static async void PostGenres(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                
                var jObject = JObject.Parse("{\"Name\": \"R'n'B\"}");

                var response = await httpClient.PostAsync(requestPath, new StringContent(
                        jObject.ToString(),
                        Encoding.UTF8,
                        "application/json"));
                
                Console.WriteLine(Environment.NewLine + "Added Genre: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void PutProducer(Uri connection, string requestPath, int id)
        {
            if(musicSystemData.Producers.Find(id) == null)
            {
                Console.WriteLine("No such producer was found.");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var jObject = JObject.Parse("{\"Name\": \"The Producer From the Put\"}");

                var response = await httpClient.PutAsync(requestPath + id, new StringContent(
                        jObject.ToString(),
                        Encoding.UTF8,
                        "application/json"));

                Console.WriteLine(Environment.NewLine + "Modified Producer: " + await response.Content.ReadAsStringAsync());
            }
        }

        private static async void DeleteGenre(Uri connection, string requestPath, int id)
        {
            if (musicSystemData.Genres.Find(id) == null)
            {
                Console.WriteLine("No such genre was found.");
                return;
            }

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var jObject = JObject.Parse("{\"Name\": \"The Producer From the Put\"}");

                var response = await httpClient.DeleteAsync(requestPath + id);

                Console.WriteLine(Environment.NewLine + "Deleted Genre:: " + await response.Content.ReadAsStringAsync());
            }
        }
    }
}
