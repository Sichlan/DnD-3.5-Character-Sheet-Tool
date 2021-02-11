using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum AbilityStat
    {
        STR,
        DEX,
        CON,
        INT,
        WIS,
        CHA
    }
}
