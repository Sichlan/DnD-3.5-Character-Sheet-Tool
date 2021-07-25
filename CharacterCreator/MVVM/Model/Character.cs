using CharacterCreator.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.MVVM.Model
{
    class Character
    {
        #region Profile
        public string CharacterName { get; set; }
        public string DisplayName { get; set; }
        public string PlayerName { get; set; }
        public Enums.CreedAlignment? Creed { get; set; }
        public Enums.SocialAlignment? Social { get; set; }
        #endregion Profile

        [JsonIgnore]
        private static Character _character;
        public static Character GetActiveCharacter()
        {
            if(_character == null)
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Properties.Settings.Default.SaveFolder,
                    fileName = "TestChar.charactersheet";

                _character = SaveLoadModel.Load<Character>(folderPath, fileName);
            }

            return _character;
        }
    }
}
