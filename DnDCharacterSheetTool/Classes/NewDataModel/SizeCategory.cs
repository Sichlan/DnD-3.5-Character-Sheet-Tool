using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SizeCategory
    {
        Fine = -4,
        Diminutive = -3,
        Tiny = -2,
        Small = -1,
        Medium = 0,
        Large = 1,
        Huge = 2,
        Gargantuan = 3,
        Colossal = 4,
        BiggerThanColossal = 5
    }
}