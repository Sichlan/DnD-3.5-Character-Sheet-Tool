using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class SourceBook : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("EditionId")]
        public int EditionID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("PublishingDate")]
        public Nullable<DateTime> PublishedAt { get; set; }


        [JsonIgnore]
        public Edition Edition
        {
            get
            {
                return Model.GetInstance().Editions.FirstOrDefault(x => x.ID == EditionID);
            }
            set
            {
                this.EditionID = value.ID;
            }
        }

        [JsonIgnore]
        public ObservableCollection<FeatVariant> FeatVariants
        {
            get => new ObservableCollection<FeatVariant>(Model.GetInstance().FeatVariants.Where(x => x.RulebookID == ID));
        }

        [JsonIgnore]
        public ObservableCollection<SkillVariant> SkillVariants
        {
            get => new ObservableCollection<SkillVariant>(Model.GetInstance().SkillVariants.Where(x => x.RulebookID == ID));
        }

        [JsonIgnore]
        public ObservableCollection<DomainVariant> DomainVariants
        {
            get => new ObservableCollection<DomainVariant>(Model.GetInstance().DomainVariants.Where(x => x.RulebookID == ID));
        }

        [JsonIgnore]
        public ObservableCollection<RaceVariant> RaceVariants
        {
            get => new ObservableCollection<RaceVariant>(Model.GetInstance().RaceVariants.Where(x => x.RulebookID == ID));
        }

        [JsonIgnore]
        public ObservableCollection<SpellVariant> SpellVariants
        {
            get => new ObservableCollection<SpellVariant>(Model.GetInstance().SpellVariants.Where(x => x.RulebookID == ID));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
