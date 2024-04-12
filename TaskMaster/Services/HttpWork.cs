using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskMaster.Services
{
    public class HttpWork
    {
        private const string old_url = @"http://192.168.10.106:8080/?response=auth&login={login}&pass={password}";
        //private string data_url = string.Empty;
        private static HttpClient httpClient = new HttpClient();

        public async Task<Stream> GetDataStream(string login, string password)
        {
            var data_url = await httpClient.GetAsync($"http://176.123.160.24:8080/?response=auth&login={login}&pass={password}");
            /*var response = await httpClient.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);*/ // возвращается только заголовок ответа,
            //а пока еще не его тело 
            var content = await data_url.Content.ReadAsStringAsync();
            return await data_url.Content.ReadAsStreamAsync();
        }
    }
}
