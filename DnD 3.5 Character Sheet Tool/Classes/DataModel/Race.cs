using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    class Race : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string basedOn;
        public string BasedOn
        {
            get { return basedOn; }
            set { basedOn = value; OnPropertyChanged(nameof(BasedOn)); }
        }

        private CreatureType type;
        public CreatureType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(nameof(Type)); }
        }

        private List<CreatureSubTypes> subTypes;
        public List<CreatureSubTypes> SubTypes
        {
            get { return subTypes; }
            set { subTypes = value; OnPropertyChanged(nameof(SubTypes)); }
        }

        private string favoredClass;
        public string FavoredClass
        {
            get { return favoredClass; }
            set { favoredClass = value; OnPropertyChanged(nameof(FavoredClass)); }
        }

        private int countHitDice;
        public int CountHitDice
        {
            get { return countHitDice; }
            set { countHitDice = value; OnPropertyChanged(nameof(CountHitDice)); }
        }

        private int sizeHitDice;
        public int SizeHitDice
        {
            get { return sizeHitDice; }
            set { sizeHitDice = value; OnPropertyChanged(nameof(SizeHitDice)); }
        }

        private int levelAdjustment;
        public int LevelAdjustment
        {
            get { return levelAdjustment; }
            set { levelAdjustment = value; OnPropertyChanged(nameof(LevelAdjustment)); }
        }

        private SizeCategory sizeCategory;
        public SizeCategory SizeCategory
        {
            get { return sizeCategory; }
            set { sizeCategory = value; OnPropertyChanged(nameof(SizeCategory)); }
        }

        private int movement;
        public int Movement
        {
            get { return movement; }
            set { movement = value; OnPropertyChanged(nameof(Movement)); }
        }

        private Dictionary<string, int> visions;
        public Dictionary<string, int> Visions
        {
            get { return visions; }
            set { visions = value; OnPropertyChanged(nameof(Visions)); }
        }

        private List<StatChange> statChanges;
        public List<StatChange> StatChanges
        {
            get { return statChanges; }
            set { statChanges = value; OnPropertyChanged(nameof(StatChanges)); }
        }

        private List<string> raceFeatures;
        public List<string> RaceFeatures
        {
            get { return raceFeatures; }
            set { raceFeatures = value; OnPropertyChanged(nameof(RaceFeatures)); }
        }

    }
}
