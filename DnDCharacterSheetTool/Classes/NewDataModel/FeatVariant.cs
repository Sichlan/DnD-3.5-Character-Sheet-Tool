using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class FeatVariant : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("FeatId")]
        public int FeatID { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }

        [JsonProperty("PageNo")]
        public int Page { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Categories")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObservableCollection<FeatCategory> Categories { get; set; }

        [JsonProperty("RequiredFeatIds")]
        public ObservableCollection<int> RequiredFeatIDs { get; set; }

        [JsonProperty("RequiredSkillRanks")]
        public ObservableCollection<SkillRankPrerequisite> RequiredSkillRanks { get; set; }

        [JsonProperty("RequiredStatValues")]
        public Dictionary<AbilityStat, int> RequiredStatValues { get; set; }

        [JsonProperty("RequiredBaseSaves")]
        public Dictionary<BaseSaveStat, int> RequiredBaseSaves { get; set; }

        [JsonProperty("RequiredCharacterLevel")]
        public Nullable<int> RequiredCharacterLevel { get; set; }

        [JsonProperty("RequiredCharacterBAB")]
        public Nullable<int> RequiredCharacterBAB { get; set; }

        [JsonProperty("RequiredCasterLevel")]
        public Nullable<int> RequiredCasterLevel { get; set; }

        [JsonProperty("RequiredPatronDeityId")]
        public Nullable<int> RequiredPatronDeityID { get; set; }

        [JsonProperty("RequiredClassLevel")]
        [Description("Key stores class id, value the needed level")]
        public Dictionary<int, int> RequiredClassLevel { get; set; }

        [JsonProperty("Benefits")]
        public ObservableCollection<IFeatBenefit> Benefits { get; set; }



        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        [JsonIgnore]
        public Feat Feat
        {
            get => Model.GetInstance().Feats.FirstOrDefault(x => x.ID == FeatID);
            set => this.FeatID = value.ID;
        }

        [JsonIgnore]
        public Deity RequiredPatronDeity
        {
            get => Model.GetInstance().Deities.FirstOrDefault(x => x.ID == RequiredPatronDeityID);
            set => this.RequiredPatronDeityID = value.ID;
        }

        [JsonIgnore]
        public ObservableCollection<Feat> RequiredFeats
        {
            get => new ObservableCollection<Feat>(Model.GetInstance().Feats.Where(x => RequiredFeatIDs.Contains(x.ID)));
        }

        [JsonIgnore]
        public ObservableCollection<Feat> RequiredFor
        {
            get => new ObservableCollection<Feat>(Model.GetInstance().Feats.Where(x => x.FeatVariants.Where(y => y.RequiredFeatIDs.Contains(ID)).Count() > 0).GroupBy(x => x.ID).Select(x => x.First()));
        }

        //TODO: Add constraint for each class needed for the feat

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
