using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.DataModel
{
    public class StatChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private Attributes stat;
        [Description("The stat that is changed.\n1 - Strength\n2 - Dexterity\n3 - Constitution\n4 - Intelligence\n5 - Wisdom\n6 - Charisma")]
        [JsonProperty(Required = Required.Always)]
        public Attributes Stat
        {
            get { return stat; }
            set { stat = value; OnPropertyChanged(nameof(Stat)); }
        }

        private int _value;
        [Description("The value of the change")]
        [JsonProperty(Required = Required.Always)]
        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(nameof(Value)); }
        }

        private string onlyIf;
        [Description("The requirements for this change to apply. Set to null if always active/no requirement attached.")]
        public string OnlyIf
        {
            get { return onlyIf; }
            set { onlyIf = value; OnPropertyChanged(nameof(OnlyIf)); }
        }

        private string source;
        [Description("The source of the Statchange, for Example 'Racial' or 'Magical Item'")]
        [JsonProperty(Required = Required.Always)]
        public string Source
        {
            get { return source; }
            set { source = value; OnPropertyChanged(nameof(Source)); }
        }

    }
}
