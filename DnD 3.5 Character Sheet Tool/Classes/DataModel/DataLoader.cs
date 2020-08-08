using DnD_3._5_Character_Sheet_Tool.Classes.DataModel;
using DnD_3._5_Character_Sheet_Tool.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    public static class DataLoader
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings() 
        { 
            TypeNameHandling = TypeNameHandling.Auto, 
            Formatting = Formatting.Indented 
        };

        private static string BaseSavePath = Environment.CurrentDirectory + "\\..\\..\\..\\DnD 3.5 Character Sheet Tool\\Saves\\";

        public static List<T> Load<T>(string SavePath)
        {
            string fullPath = BaseSavePath + SavePath;

            List<T> elements = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fullPath)).ToList();

            return elements;
        }

        public static void Save<T>(List<T> elements, string SavePath)
        {
            string fullPath = BaseSavePath + SavePath;

            File.WriteAllText(fullPath, JsonConvert.SerializeObject(elements, settings));
        }
    }
}
