using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SubSchool
    {
        Calling,
        Creation,
        Healing,
        Summoning,
        Teleportation,
        Scrying,
        Charm,
        Compulsion,
        Figment,
        Glamer,
        Pattern,
        Phantasm,
        Shadow
    }
}
