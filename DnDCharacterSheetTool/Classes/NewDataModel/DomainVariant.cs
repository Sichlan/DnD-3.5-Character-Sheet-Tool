using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class DomainVariant : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("DomainId")]
        public int DomainID { get; set; }

        [JsonProperty("DeityIds")]
        public ObservableCollection<int> DeityIDs { get; set; }

        [JsonProperty("SpellPerLevel")]
        [Description("Key is Level, value is spell")]
        public Dictionary<int, int> SpellsPerLevel { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }



        [JsonIgnore]
        public Domain Domain
        {
            get => Model.GetInstance().Domains.FirstOrDefault(x => x.ID == DomainID);
            set => DomainID = value.ID;
        }

        [JsonIgnore]
        public ObservableCollection<Deity> Deities
        {
            get => new ObservableCollection<Deity>(Model.GetInstance().Deities.Where(x => DeityIDs.Contains(x.ID)));
        }

        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //TODO: Add constraint to spell when implemented

        //TODO: Add granted Power as Ability or so
    }
}