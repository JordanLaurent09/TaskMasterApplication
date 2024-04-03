using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPLib
{
    public class HTTPRequester
    {
        private static string _data_url = " ";

        private static async Task<Stream> GetDataStream()
        {
            // Создается клиент
            var client = new HttpClient();
            var response = await client.GetAsync(_data_url, HttpCompletionOption.ResponseHeadersRead); // возвращается только заголовок ответа,
            //а пока еще не его тело 
            return await response.Content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Разбивает поток байт на последовательность строк
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<string> GetDataLines()
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
    }
}
