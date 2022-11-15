using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Linq;

namespace B1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://app-htf-2022.azurewebsites.net");
            string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAiLCJuYmYiOjE2Njg1MDMzNzAsImV4cCI6MTY2ODU4OTc3MCwiaWF0IjoxNjY4NTAzMzcwfQ.ddBXJR6s_O8W8EyzAeLeDSNcCe5ST3a3Ii9fwoyzql8x8SxABobToimr58bwZYZ4CjcKmabW9d2XJ45lcx6PwA";

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var startUrl = "api/path/2/easy/Start";
            var startResponse = await client.GetAsync(startUrl);

            var sampleUrl = "api/path/2/easy/Puzzle";
            var sampleGetResponse = await client.GetFromJsonAsync<List<string>>(sampleUrl);
            //var sampleAnswer = GetAnswer(sampleGetResponse);
            //var samplePostResponse = await client.PostAsJsonAsync<string>(sampleUrl, (string)sampleAnswer);
            //var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
            //Console.WriteLine(samplePostResponseValue);
            foreach (string item in sampleGetResponse)
            {
                while (item.Length > 0)
                {
                    Console.Write(item[0] + " = ");
                    int cal = 0;
                    for (int j = 0; j < item.Length; j++)
                    {
                        if (item[0] == item[j])
                        {
                            cal++;
                        }
                    }
                    Console.WriteLine(cal);
                    string items = item.Replace(item[0].ToString(), string.Empty);

                }
                //Console.WriteLine(item);
            }

            Console.Read();
        }

        private static object GetAnswer(List<string>? sampleGetResponse)
        {
            throw new NotImplementedException();
        }
    }
}