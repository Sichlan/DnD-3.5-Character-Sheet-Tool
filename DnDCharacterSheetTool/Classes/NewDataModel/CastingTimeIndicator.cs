using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(StringEnumConverter)]
    public enum CastingTimeIndicator
    {
        Immediate,
        Swift,
        Free,
        Standard,
        Round,
        Minute,
        Hour,
        Day
    }
}
