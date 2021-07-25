using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    [System.Diagnostics.DebuggerDisplay("{category} - {name} ({edition})")]
    public class SourceBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string edition;
        public string Edition
        {
            get { return edition; }
            set { edition = value; OnPropertyChanged(nameof(Edition)); }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(nameof(Category)); }
        }

    }
}
