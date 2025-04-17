using static System.Net.WebRequestMethods;
using System.IO;
using System.Text.Json;
using System.Net;

namespace ConsoleApp18
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo("Users");
            if (!directory.Exists)
            {
                directory.Create();
            }
            FileInfo file = new FileInfo(Path.Combine(directory.FullName, "users.join"));
            if (!file.Exists)
            {
                file.Create();
            }
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
                response.EnsureSuccessStatusCode();

                string jsonContent = await response.Content.ReadAsStringAsync();


                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonContent);




            }
        }
    }
}
