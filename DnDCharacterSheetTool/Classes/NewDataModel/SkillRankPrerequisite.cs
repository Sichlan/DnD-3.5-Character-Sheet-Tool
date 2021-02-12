using Newtonsoft.Json;
using System.ComponentModel;
using System.Linq;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class SkillRankPrerequisite
    {
        [JsonProperty("Skill")]
        public int SkillID { get; set; }

        [JsonProperty("MinRanks")]
        public int MinRanks { get; set; }

        [JsonProperty("Extra")]
        [Description("Ususally used to add a specification, such as \"Arcane\" for Knowledge(Arcane) or \"Weaving\" for Craft(Weaving)")]
        public string Extra { get; set; }


        [JsonIgnore]
        public Skill Skill
        {
            get
            {
                return Model.GetInstance().Skills.FirstOrDefault(x => x.ID == SkillID);
            }
            set
            {
                this.SkillID = value.ID;
            }
        }
    }
}
