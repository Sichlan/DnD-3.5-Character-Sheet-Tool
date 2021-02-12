using Newtonsoft.Json;
using System.ComponentModel;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class AllowedSave : INotifyPropertyChanged
    {
        [JsonProperty("SaveStat")]
        public BaseSaveStat SaveStat { get; set; }

        [JsonProperty("SaveType")]
        public SaveType SaveType { get; set; }

        [JsonProperty("Extra")]
        public string Extra { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
