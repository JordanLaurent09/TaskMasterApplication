using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMaster.Models;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Collections.ObjectModel;

namespace TaskMaster.Services
{
    public static class CSVReader
    {            
        /// <summary>
        /// Получение информации об успешности/неудаче при добавлении новой задачи
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string AddTaskServerResponse(Stream stream)
        {
            var dataReader = new StreamReader(stream, Encoding.Unicode);

            string result = dataReader.ReadToEnd();

            return result;
        }
    }
}
