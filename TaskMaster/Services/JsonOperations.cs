using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public static class JsonOperations
    {
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
    }
}
