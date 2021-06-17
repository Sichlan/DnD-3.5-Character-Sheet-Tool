using DnDCharacterSheetTool.Classes.DataModel;
using DnDCharacterSheetTool.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Trace.WriteLine("Importing from " + fullPath);

            if (!File.Exists(fullPath))
            {
                var writer = File.CreateText(fullPath);
                writer.Write("[\n\n]");
                writer.Dispose();
            }

            List<T> elements = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(fullPath)).ToList();

            Trace.WriteLine("Imported " + elements.Count + " item(s)\n");

            return elements;
        }

        public static void Save<T>(List<T> elements, string SavePath)
        {
            string fullPath = BaseSavePath + SavePath;

            Trace.WriteLine("Saving to " + fullPath);

            if (!File.Exists(fullPath))
            {
                var writer = File.CreateText(fullPath);
                writer.Write("[\n\n]");
                writer.Dispose();
            }

            File.WriteAllText(fullPath, JsonConvert.SerializeObject(elements, settings));

            Trace.WriteLine("Wrote " + elements.Count + " to file\n");
        }
    }
}
