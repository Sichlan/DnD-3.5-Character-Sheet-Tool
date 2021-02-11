using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class SkillVariant : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("SkillId")]
        public int SkillID { get; set; }

        [JsonProperty("RulebookId")]
        public int RulebookID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Usages")]
        public ObservableCollection<Tuple<int, string>> Usages { get; set; }

        [JsonProperty("Action")]
        public string Action { get; set; }

        [JsonProperty("TryAgain")]
        public bool TryAgain { get; set; }

        //TODO: Improve this maybe...
        [JsonProperty("Special")]
        public string Special { get; set; }

        [JsonProperty("SynergySkillIDs")]
        public ObservableCollection<int> SynergySkillIDs { get; set; }

        [JsonProperty("Untrained")]
        public string Untrained { get; set; }

        [JsonProperty("Restrictions")]
        public string Restrictions { get; set; }



        [JsonIgnore]
        public SourceBook Rulebook
        {
            get => Model.GetInstance().SourceBooks.FirstOrDefault(x => x.ID == RulebookID);
            set => this.RulebookID = value.ID;
        }

        [JsonIgnore]
        public Skill Skill
        {
            get => Model.GetInstance().Skills.FirstOrDefault(x => x.ID == SkillID);
            set => this.SkillID = value.ID;
        }

        [JsonIgnore]
        public ObservableCollection<Skill> SynergySkills
        {
            get => new ObservableCollection<Skill>(Model.GetInstance().Skills.Where(x => SynergySkillIDs.Contains(x.ID)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
