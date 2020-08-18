using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    class StatChange : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private Attribute stat;
        public Attribute Stat
        {
            get { return stat; }
            set { stat = value; OnPropertyChanged(nameof(Stat)); }
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(nameof(Value)); }
        }

        private string onlyIf;
        public string OnlyIf
        {
            get { return onlyIf; }
            set { onlyIf = value; OnPropertyChanged(nameof(OnlyIf)); }
        }

    }
}
