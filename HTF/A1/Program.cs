using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace A1;
class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://app-htf-2022.azurewebsites.net");
        string token = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiMTAiLCJuYmYiOjE2Njg1MDMzNzAsImV4cCI6MTY2ODU4OTc3MCwiaWF0IjoxNjY4NTAzMzcwfQ.ddBXJR6s_O8W8EyzAeLeDSNcCe5ST3a3Ii9fwoyzql8x8SxABobToimr58bwZYZ4CjcKmabW9d2XJ45lcx6PwA";

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var startUrl = "api/path/1/easy/Start";
        var startResponse = await client.GetAsync(startUrl);

        var sampleUrl = "/api/path/1/easy/Puzzle";
        var sampleGetResponse = await client.GetFromJsonAsync<List<string>>(sampleUrl);
        var sampleAnswer = GetAnswer(sampleGetResponse);
        var samplePostResponse = await client.PostAsJsonAsync<string>(sampleUrl, (string)sampleAnswer);
        var samplePostResponseValue = await samplePostResponse.Content.ReadAsStringAsync();
        Console.WriteLine(samplePostResponseValue);

        
            Console.Read();
        }


    private static Dictionary<char, int> RomanNumerals = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
    public static int find_value(char chr)
    {
        switch (chr)
        {
            case 'I': return 1;
            case 'V': return 5;
            case 'X': return 10;
            case 'L': return 50;
            case 'C': return 100;
            case 'D': return 500;
            case 'M': return 1000;
            default: return 0;
        }
    }
    private static object GetAnswer(List<string>? sampleGetResponse)
    {
        string answer;
        int sum = 0;
        int number = 0;
        foreach (string letter in sampleGetResponse)
        {
            Console.WriteLine(letter);
            
            for (int i = 0; i < letter.Length; i++)
            {
                var num = 0;
                if (i > 0 && find_value(letter[i]) > find_value(letter[i - 1]))
                {
                    num += find_value(letter[i]) - find_value(letter[i - 1]) * 2;
                    number += num;
                }
                else
                {
                    num += find_value(letter[i]);
                    number += num;
                }

            }
            Console.WriteLine(number);
        }

        string[] roman_symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
            int[] int_value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            var roman_numerals = new StringBuilder();
            var index_num = 0;
            while (number != 0)
            {
                if (number >= int_value[index_num])
                {
                number -= int_value[index_num];
                    roman_numerals.Append(roman_symbol[index_num]);
                }
                else
                {
                    index_num++;
                }
            }
            answer = roman_numerals.ToString();
            Console.WriteLine(answer);
            
        return answer;
    }
}


       


