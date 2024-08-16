using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using TaskMaster.Models;
using System.IO;
using System.Windows;

namespace TaskMaster.Services
{
    public static class JsonOperations
    {

        /// <summary>
        /// Получает данные от сервера при аутентификации
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Data GetAllData(Stream stream)
        {
            Data dataTotal = new();
            using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
            {
                JsonSerializerOptions oprions = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string data = reader.ReadToEnd();
                data = Cypher.GetEncryptData(data);
                //string data = Cypher.EncryptData(stream);               
                //// Здесь опасный шифр
                dataTotal = JsonSerializer.Deserialize<Data>(data, oprions)!;


            }
            return dataTotal;
        }




        /// <summary>
        /// Преобразует в строку данные User'a для логина
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string JsonForLogin(string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;

            //JsonSerializerOptions options = new JsonSerializerOptions()
            //{
            //    WriteIndented = true,
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            //};

            string autString = JsonSerializer.Serialize(user, typeof(User));

            return autString;
        }


        /// <summary>
        /// Преобразует в строку объект типа Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static string JsonForNewTask(Models.Task task)
        {
            string taskString = JsonSerializer.Serialize<Models.Task>(task);

            return taskString;
        }
       
    }
}
