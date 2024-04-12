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

namespace TaskMaster.Services
{
    public static class CSVReader
    {
        public static void InfoTotal(ref List<Models.Task> tasks, ref List<User> users, StreamReader stream)
        {
            //var dataReader = new StreamReader(stream);

            string[] temp = stream.ReadToEnd().Split('^');

            //StreamReader tasksInfo = new StreamReader(temp[0]);
            //StreamReader userInfo = new StreamReader (temp[1]);

            TextReader tasksReader = new StringReader(temp[1]);
            TextReader usersReader = new StringReader(temp[0]);

            CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);

            CsvReader reader = new CsvReader(tasksReader, csvConfig);
            tasks = reader.GetRecords<Models.Task>().ToList();

            reader = new CsvReader(usersReader, csvConfig);
            users = reader.GetRecords<User>().ToList();

            tasksReader.Close();
            usersReader.Close();

            stream.Close();

            //dataReader.Close();
        }
    }
}
