using Newtonsoft.Json;
using System.ComponentModel;

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

        //TODO: Add constraint for Skill when it is implemented
    }
}
