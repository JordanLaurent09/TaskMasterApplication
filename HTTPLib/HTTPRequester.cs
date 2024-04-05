using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace HTTPLib
{
    public static class HTTPRequester
    {
        private static string _data_url = "";

        private static async Task<Stream> GetDataStream()
        {
            string id = "2";

            string dataUrl = "http://192.168.10.106:8080/";

            var client = new HttpClient();
            var response = await client.GetAsync(dataUrl, HttpCompletionOption.ResponseHeadersRead);
            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Разбивает поток байт на последовательность строк
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetDataLines()
        {
            var data_stream = GetDataStream().Result; 
            var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine(); 
                if (string.IsNullOrWhiteSpace(line)) continue;
                yield return line; 
            }
        }

        public static async void PrimaryHttpMethod()
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"http://192.168.10.106:8080/?response=task&userId=1token=asd");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine($"Ошибка: {response.StatusCode}");
            }
        }
    }
}
