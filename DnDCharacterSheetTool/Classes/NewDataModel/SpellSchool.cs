using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SpellSchool
    {
        None,
        Abjuration,
        Alteration,
        Conjuration,
        Divination,
        Enchantment,
        Evocation,
        Illusion,
        Necromancy,
        Transmutation,
        Universal
    }
}
