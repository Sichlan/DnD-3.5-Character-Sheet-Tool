using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class CreatureType
    {
        [JsonProperty("Id")]
        public int ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("HitDieSize")]
        public int HitDieSize { get; set; }

        [JsonProperty("BABType")]
        public double BABType { get; set; }

        [JsonProperty("FortType")]
        public double FortType { get; set; }

        [JsonProperty("RefType")]
        public double RefType { get; set; }

        [JsonProperty("WillType")]
        public double WillType { get; set; }

        [JsonProperty("BaseSkillPoints")]
        public int BaseSkillPoints { get; set; }

        //TODO: Add standard properties once you figured out how



        [JsonIgnore]
        public ObservableCollection<RaceVariant> RaceVariants
        {
            get => new ObservableCollection<RaceVariant>(Model.GetInstance().RaceVariants.Where(x => x.CreatureTypeID == ID));
        }
    }
}
