using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BaseSaveStat
    {
        Fortitude,
        Reflex,
        Will
    }
}
