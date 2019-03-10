using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PhoneBookApi.Helper
{
    public class StorageHelper
    {
        public static T LoadData<T>(string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(fileName))
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static void SaveData<T>(T data, string fileName)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = File.CreateText(fileName))
            {
                serializer.Serialize(writer, data);
            }
        }
    }
}