using Newtonsoft.Json;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class StatChange
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Stat")]
        public AbilityStat Stat { get; set; }

        [JsonProperty("AppliesOnlyIf")]
        public string AppliesOnlyIf { get; set; }
    }
}
