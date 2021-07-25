using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core
{
    static class SaveLoadModel
    {
        public static JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
#if DEBUG
            Formatting = Formatting.Indented
#endif
        };

        public static T Load<T>(string folderPath, string fileName) where T : new()
        {
            try
            {
                //Ensure the directory to save the object in exists:
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                //Ensure the file exists:
                if (!File.Exists(folderPath + fileName))
                {
                    File.WriteAllText(folderPath + fileName, JsonConvert.SerializeObject(new T(), serializerSettings));
                }

                return JsonConvert.DeserializeObject<T>(File.ReadAllText(folderPath + fileName), serializerSettings);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Save<T>(string folderPath, string fileName, T objectToSave) where T : new()
        {
            //Ensure the directory to save the object in exists:
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            //Well guess what, File.WriteAllText doesn't care whether the named file exists or not, it just creates it if the file does not exist
            File.WriteAllText(folderPath + fileName, JsonConvert.SerializeObject(objectToSave, serializerSettings));
        }
    }
}
