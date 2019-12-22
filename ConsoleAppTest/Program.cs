using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterAsync().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"There was an exception: {ex.ToString()}");
            }
        }

        private static async Task RegisterAsync()
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", "Admin"),
                new KeyValuePair<string, string>("password", "GoatStar_2020"),
                new KeyValuePair<string, string>("grant_type","password")
            };

           // var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:60292/Token")
            var request = new HttpRequestMessage(HttpMethod.Post, $"http://GoatApi.somee.com/Token")
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = response.Content.ReadAsStringAsync();
            Console.WriteLine(content.Result);
            Console.ReadLine();
        }
    }
}
