using CharacterCreator.Classes.CommonObject;
using CharacterCreator.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.CharacterSheet.Classes
{
    /// <summary>
    /// The main class for storing character data.
    /// Can implement a changetracker via 
    /// </summary>
    public class Character : INotifyPropertyChanged
    {
        #region Attributes

        #region BackgroundData

        public string FilePath { get; set; }
        [JsonIgnore]
        public bool hasChanges;

        #endregion BackgroundData

        #region BioAttributes

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string PlayerName { get; set; }
        public bool UseExperiencePoints { get; set; }
        public int CurrentExperiencePoints { get; set; }
        public int ExperienceForNextLevel { get; set; }
        public RaceVariant RaceVariant {get;set;}
        [JsonConverter(typeof(JsonImageConverter))]
        public Image ProfilePicture { get; set; }

        #endregion BioAttributes

        #endregion Attributes

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty = "")
        {
            hasChanges = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }
    }
}
