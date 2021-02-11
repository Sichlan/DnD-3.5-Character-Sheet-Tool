using Newtonsoft.Json;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public interface IFeatBenefit
    {
        [JsonProperty("Description")]
        string Description { get; set; }

        [JsonProperty("Extra")]
        object Extra { get; set; }
    }
}
