using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.DataModel
{
    class AbilityScoreDeterminationRoll : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }

        private string equation;
        /// <summary>
        /// The Equation of the roll.
        /// - To roll some dice use the letter 'd'. Example: '3d4' rolls 3 four-sided die
        /// - To 
        /// </summary>
        public string Equation
        {
            get { return equation; }
            set { equation = value; OnPropertyChanged(nameof(Equation)); }
        }

    }
}
