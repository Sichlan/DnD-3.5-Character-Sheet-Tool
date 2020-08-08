using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnD_3._5_Character_Sheet_Tool.Interfaces
{
    public interface ILoadable
    {
        [JsonIgnore]
        string SavePath { get; }
    }
}