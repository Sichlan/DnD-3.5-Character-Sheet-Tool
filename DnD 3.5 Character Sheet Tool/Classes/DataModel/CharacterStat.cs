using System.ComponentModel;
using System.Diagnostics;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    [DebuggerDisplay("{attribute}: {TotalValue}")]
    public class CharacterStat : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private Attributes attributes;
        public Attributes Attributes
        {
            get { return attributes; }
            set { attributes = value; OnPropertyChanged(nameof(Attributes)); }
        }

        public int TotalValue
        {
            get { return BaseValue; }
        }

        private int baseValue;
        public int BaseValue
        {
            get { return baseValue; }
            set { baseValue = value; OnPropertyChanged(nameof(BaseValue)); OnPropertyChanged(nameof(TotalValue)); }
        }

    }
}