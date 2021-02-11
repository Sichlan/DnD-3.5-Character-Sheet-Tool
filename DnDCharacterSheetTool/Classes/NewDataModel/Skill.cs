using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Skill : INotifyPropertyChanged
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AbilityStat")]
        public AbilityStat AbilityStat { get; set; }

        [JsonProperty("TrainedOnly")]
        public bool TrainedOnly { get; set; }

        [JsonProperty("ArmorCheckPenaltyModifier")]
        [Description("The modifier with which AP is applied. Mostly 0 (not applied) or 1 (simply applied). Some cases like swim demand 2 (double penalty)")]
        public int ArmorCheckPenaltyModifier { get; set; }



        [JsonIgnore]
        public ObservableCollection<SkillVariant> SkillVariants
        {
            get => new ObservableCollection<SkillVariant>(Model.GetInstance().SkillVariants.Where(x => x.SkillID == ID));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
