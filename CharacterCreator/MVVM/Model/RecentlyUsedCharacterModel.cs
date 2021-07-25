using CharacterCreator.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.MVVM.Model
{
    public class RecentlyUsedCharacterModel : ObservableObject
    {
        [JsonIgnore]
        public static readonly string RUSavePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Properties.Settings.Default.RecentlyUsedListFile;
        private DateTime lastUpdate;
        public ObservableCollection<RecentlyUsedCharacterEntry> recentlyUsedCharacter { get; private set; }

        [JsonIgnore]
        private static RecentlyUsedCharacterModel recently;

        public RecentlyUsedCharacterModel()
        {
            recentlyUsedCharacter = new ObservableCollection<RecentlyUsedCharacterEntry>();
        }

        public static RecentlyUsedCharacterModel GetRecentlyUsedCharacterModel()
        {
            if(recently == null)
            {
                string folderPath = RUSavePath.Substring(0, RUSavePath.LastIndexOf("\\") + 1),
                    fileName = RUSavePath.Substring(RUSavePath.LastIndexOf("\\") + 1);

                recently = SaveLoadModel.Load<RecentlyUsedCharacterModel>(folderPath, fileName);
            }

            return recently;
        }

        public void SaveRecentlyUsedCharacterModel()
        {
            lastUpdate = DateTime.Now;

            string folderPath = RUSavePath.Substring(0, RUSavePath.LastIndexOf("\\") + 1),
                fileName = RUSavePath.Substring(RUSavePath.LastIndexOf("\\") + 1);

            SaveLoadModel.Save(folderPath, fileName, this);
        }
    }
}
