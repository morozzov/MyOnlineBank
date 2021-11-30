using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFClient.Model
{
    static class DataStorage
    {
        private static Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public static bool Add(string key, object value)
        {
            if (dictionary.ContainsKey(key) == true)
            {
                return false;
            }
            else
            {
                dictionary.Add(key, value);
                return true;
            }
        }

        public static bool Update(string key, object value)
        {
            if (dictionary.ContainsKey(key) == true)
            {
                dictionary[key] = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(string key)
        {
            if (dictionary.ContainsKey(key) == true)
            {
                dictionary.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object Get(string key)
        {
            if (dictionary.ContainsKey(key) == true)
            {
                return dictionary[key];
            }
            else
            {
                return null;
            }
        }
    }
}
