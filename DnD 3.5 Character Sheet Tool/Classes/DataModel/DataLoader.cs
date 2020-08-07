using DnD_3._5_Character_Sheet_Tool.Classes.DataModel;
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

        private static string SpellSavePath = BaseSavePath + "Spells.json";

        public static List<Spell> LoadSpells()
        {
            List<Spell> spells = new List<Spell>();

            FileStream fileStream = new FileStream(SpellSavePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader reader = new StreamReader(fileStream);
            spells = JsonConvert.DeserializeObject<List<Spell>>(reader.ReadToEnd()).OrderBy(x => x.Name).ToList();

            reader.Close();
            fileStream.Close();

            return spells;
        }

        public static void SaveSpells(List<Spell> spells)
        {
            FileStream fileStream = new FileStream(SpellSavePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.Write(JsonConvert.SerializeObject(spells, settings));

            writer.Close();
            fileStream.Close();
        }
    }
}
