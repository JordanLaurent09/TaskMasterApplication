using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public class HttpWork
    {
        private const string old_url = @"http://192.168.10.106:8080/?response=auth&login={login}&pass={password}";
        //private string data_url = string.Empty;
        //private static HttpClient httpClient = new HttpClient();

        //public async Task<Stream> GetDataStream(string login, string password)
        //{
        //    var data_url = await httpClient.GetAsync($"http://176.123.160.24:8080/?response=auth&login={login}&pass={password}");
        //    /*var response = await httpClient.GetAsync(data_url, HttpCompletionOption.ResponseHeadersRead);*/ // возвращается только заголовок ответа,
        //    //а пока еще не его тело 
        //    var content = await data_url.Content.ReadAsStringAsync();
        //    return await data_url.Content.ReadAsStreamAsync();
        //}

        public async Task<Stream> GetAuthInfo(string message)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/auth");

                HttpResponseMessage response =  client.PostAsync("http://176.123.160.24:8080", content).Result;
               

                return await response.Content.ReadAsStreamAsync();
            }
        }

        public async Task<Stream> AddNewTAsk(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/taskAdd");

                HttpResponseMessage response = client.PostAsync("http://176.123.160.24:8080", content).Result;


                return await response.Content.ReadAsStreamAsync();
            }
        }

    }
}
