using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnDCharacterSheetTool.Interfaces
{
    public interface ILoadable
    {
        [JsonIgnore]
        string SavePath { get; }
    }
}