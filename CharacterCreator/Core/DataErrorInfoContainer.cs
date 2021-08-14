using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core
{
    public class DataErrorInfoContainer
    {
        public DataErrorType ErrorType { get; set; }
        public string DisplayMessage { get; set; }
    }

    public enum DataErrorType
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}
