using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Alignment
    {
        LG, NG, CG,
        LN, TN, CN,
        LE, NE, CE
    }
}
