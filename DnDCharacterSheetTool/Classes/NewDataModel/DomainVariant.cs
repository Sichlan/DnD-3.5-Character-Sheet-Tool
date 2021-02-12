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
        public Dictionary<int, int> SpellsPerLevelIDs { get; set; }

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

        [JsonIgnore]
        public Dictionary<int, Spell> SpellsPerLevel
        {
            get
            {
                Dictionary<int, Spell> output = new Dictionary<int, Spell>();

                foreach (var Level in SpellsPerLevelIDs)
                {
                    output.Add(Level.Key, Model.GetInstance().Spells.FirstOrDefault(x => x.ID == Level.Value));
                }

                return output;
            }
        }

        //TODO: Add granted Power as Ability or so

        public event PropertyChangedEventHandler PropertyChanged;
    }
}