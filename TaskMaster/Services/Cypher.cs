using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskMaster.Models;

namespace TaskMaster.Services
{
    public class Cypher
    {

        private static readonly int _key = 5; 
        

        /// <summary>
        /// Метод, дешифрующий данные
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        
        public static string GetEncryptData(string word)  // Дешифруем данные
        {
            byte[] encryptedBytes = Encoding.UTF8.GetBytes(word);
            byte[] decryptedBytes = new byte[encryptedBytes.Length];
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                decryptedBytes[i] = (byte)(encryptedBytes[i] ^ CreateKey());
            }
            return Encoding.UTF8.GetString(decryptedBytes);
        }



        /// <summary>
        /// Метод, шифрующий данные
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string DecryptData(string word) // Шифруем данные
        {
            byte[] wordBytes = Encoding.UTF8.GetBytes(word);
            byte[] encryptedBytes = new byte[wordBytes.Length];

            for (int i = 0; i < wordBytes.Length; i++)
            {
                encryptedBytes[i] = (byte)(wordBytes[i] ^ CreateKey());
            }
            string result = Encoding.UTF8.GetString(encryptedBytes);
            return result;
        }

        /// <summary>
        /// Метод, формирующий ключ при помощи специального алгоритма
        /// </summary>
        /// <returns></returns>
        private static int CreateKey()
        {
            int day = (int)DateTime.Now.DayOfWeek;
            int key = _key + day;
            return key;
        }
    }

    
}
