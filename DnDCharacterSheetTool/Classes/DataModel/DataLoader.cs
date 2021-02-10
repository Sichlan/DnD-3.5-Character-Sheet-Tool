using DnDCharacterSheetTool.Classes.DataModel;
using DnDCharacterSheetTool.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.DataModel
{
    public static class DataLoader
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings() 
        { 
            TypeNameHandling = TypeNameHandling.Auto, 
            Formatting = Formatting.Indented
        };

        private static readonly string BaseSavePath = Environment.CurrentDirectory + "\\..\\..\\..\\DnDCharacterSheetTool\\Saves\\";

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
