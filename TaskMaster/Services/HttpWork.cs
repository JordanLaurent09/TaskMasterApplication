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
        

        public async Task<Stream> GetAuthInfo(string message)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/authorization");

                HttpResponseMessage response =  client.PostAsync("http://176.123.160.24:8080", content).Result;
               


                return await response.Content.ReadAsStreamAsync();
            }
        }

        public async Task<Stream> AddNewTAsk(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/addTask");

                HttpResponseMessage response = client.PostAsync("http://176.123.160.24:8080", content).Result;


                return await response.Content.ReadAsStreamAsync();
            }
        }

        public async Task<Stream> ChangeTaskStatus(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/updateTask");

                HttpResponseMessage responce = client.PostAsync("http://176.123.160.24:8080", content).Result;

                return await responce.Content.ReadAsStreamAsync();
            }
        }


        public async Task<Stream> DepartmentsListRequest(string message)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(message, Encoding.UTF8, "application/depsReq");

                HttpResponseMessage response = client.PostAsync("http://176.123.160.24:8080", content).Result;


                return await response.Content.ReadAsStreamAsync();
            }
        }

    }
}
