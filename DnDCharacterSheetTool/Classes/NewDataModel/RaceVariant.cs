using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class RaceVariant : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("RaceId")]
        public int RaceID { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }

        [JsonProperty("Page")]
        public int? Page { get; set; }

        [JsonProperty("SubraceOf")]
        public int? SubraceOf { get; set; }

        [JsonProperty("CreatureTypeId")]
        [JsonConverter(typeof(StringEnumConverter))]
        public int CreatureTypeID { get; set; }

        [JsonProperty("CreatureSubTypes")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<CreatureSubType> CreatureSubTypes { get; set; }

        [JsonProperty("FavouredClassID")]
        public int? FavouredClassID { get; set; }

        [JsonProperty("CountRacialHitDie")]
        public int CountRacialHitDie { get; set; }

        [JsonProperty("SizeRacialHitDie")]
        public int SizeRacialHitDie { get; set; }

        [JsonProperty("HasRacialHitDie")]
        public int HasRacialHitDie { get; set; }

        [JsonProperty("LevelAdjustment")]
        public int LevelAdjustment { get; set; }

        [JsonProperty("Space")]
        public int Space { get; set; }

        [JsonProperty("Reach")]
        public int Reach { get; set; }

        [JsonProperty("NaturalArmor")]
        public int NaturalArmor { get; set; }

        [JsonProperty("Combat")]
        public string Combat { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("BABType")]
        public double? BABType { get; set; }

        [JsonProperty("FortType")]
        public double? FortType { get; set; }

        [JsonProperty("RefType")]
        public double? RefType { get; set; }

        [JsonProperty("WillType")]
        public double? WillType { get; set; }

        [JsonProperty("BaseSkillPoints")]
        public int? BaseSkillPoints { get; set; }

        [JsonProperty("SizeCategories")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<SizeCategory> SizeCategories { get; set; }

        [JsonProperty("MovementModes")]
        public Dictionary<MovementMode, int> MovementModes { get; set; }

        [JsonProperty("Senses")]
        public Dictionary<Sense, int?> Senses { get; set; }

        [JsonProperty("StatChanges")]
        public ObservableCollection<StatChange> StatChanges { get; set; }

        [JsonProperty("AutomaticLanguagesIds")]
        public ObservableCollection<int> AutomaticLanguagesIDs { get; set; }

        [JsonProperty("BonusLanguagesIds")]
        public ObservableCollection<int> BonusLanguagesIDs { get; set; }

        //TODO: Add RaceFeatures, once you got an idea how to do that
        //TODO: Also maybe extract abilities from the combat description



        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        [JsonIgnore]
        public Race Race
        {
            get => Model.GetInstance().Races.FirstOrDefault(x => x.ID == RaceID);
            set => RaceID = value.ID;
        }

        [JsonIgnore]
        public CreatureType CreatureType
        {
            get => Model.GetInstance().CreatureTypes.FirstOrDefault(x => x.ID == CreatureTypeID);
            set => CreatureTypeID = value.ID;
        }

        [JsonIgnore]
        public RaceVariant AncestorRaceVariant
        {
            get => Model.GetInstance().RaceVariants.FirstOrDefault(x => x.RaceID == SubraceOf.GetValueOrDefault(-1));
            set => RaceID = value.ID;
        }

        [JsonIgnore]
        public ObservableCollection<RaceVariant> SubRaceVariants
        {
            get => new ObservableCollection<RaceVariant>(Model.GetInstance().RaceVariants.Where(x => x.SubraceOf.GetValueOrDefault(-1) == RaceID));
        }

        [JsonIgnore]
        public ObservableCollection<Language> AutomaticLanguages
        {
            get => new ObservableCollection<Language>(Model.GetInstance().Languages.Where(x => AutomaticLanguagesIDs.Contains(x.ID)));
        }

        [JsonIgnore]
        public ObservableCollection<Language> BonusLanguages
        {
            get => new ObservableCollection<Language>(Model.GetInstance().Languages.Where(x => BonusLanguagesIDs.Contains(x.ID)));
        }

        //TODO: Add favoured class constraint when implemented

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
