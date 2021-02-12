using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class SpellVariant : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("SpellId")]
        public int SpellID { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }

        [JsonProperty("Page")]
        public int? Page { get; set; }

        [JsonProperty("SpellSchools")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<SpellSchool> SpellSchools { get; set; }

        [JsonProperty("SubSpellSchools")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<SubSchool> SubSpellSchools { get; set; }

        [JsonProperty("Descriptor")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<Descriptor> Descriptors { get; set; }

        [JsonProperty("HasVerbal")]
        public bool HasVerbal { get; set; }

        [JsonProperty("HasSomatic")]
        public bool HasSomatic { get; set; }

        [JsonProperty("Material")]
        public string Material { get; set; }

        [JsonProperty("ArcaneFocus")]
        public string ArcaneFocus { get; set; }

        [JsonProperty("DivineFocus")]
        public string DivineFocus { get; set; }

        [JsonProperty("XP")]
        public int? XP { get; set; }

        [JsonProperty("CastingTime")]
        public Tuple<int, CastingTimeIndicator> CastingTime { get; set; }

        //TODO: Fix this mess v
        [JsonProperty("Range")]
        public string Range { get; set; }

        [JsonProperty("Target")]
        public string Target { get; set; }

        [JsonProperty("Area")]
        public string Area { get; set; }

        [JsonProperty("Effect")]
        public string Effect { get; set; }

        [JsonProperty("Concentration")]
        public bool Concentration { get; set; }

        [JsonProperty("Duration")]
        public string Duration { get; set; }

        [JsonProperty("Saves")]
        public ObservableCollection<AllowedSave> AllowedSaves { get; set; }

        [JsonProperty("Harmless")]
        public bool Harmless { get; set; }

        [JsonProperty("TargetsObject")]
        public bool TargetsObject { get; set; }



        [JsonIgnore]
        public Spell Spell
        {
            get => Model.GetInstance().Spells.FirstOrDefault(x => x.ID == SpellID);
            set => this.SpellID = value.ID;
        }

        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
