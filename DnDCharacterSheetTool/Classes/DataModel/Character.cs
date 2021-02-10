using DnDCharacterSheetTool.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterSheetTool.Classes.DataModel
{
    public class Character : INotifyPropertyChanged
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

        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; OnPropertyChanged(nameof(Gender)); }
        }

        private LNCAlignment lNCAlignment;
        public LNCAlignment LNCAlignment
        {
            get { return lNCAlignment; }
            set { lNCAlignment = value; OnPropertyChanged(nameof(LNCAlignment)); }
        }

        private GNEAlignment gNEAlignment;
        public GNEAlignment GNEAlignment
        {
            get { return gNEAlignment; }
            set { gNEAlignment = value; OnPropertyChanged(nameof(GNEAlignment)); }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        private double height;
        public double Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged(nameof(Height)); }
        }

        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = value; OnPropertyChanged(nameof(Weight)); }
        }

        private string eyeColor;
        public string EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; OnPropertyChanged(nameof(EyeColor)); }
        }

        private string hairColor;
        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; OnPropertyChanged(nameof(HairColor)); }
        }

        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged(nameof(Notes)); }
        }

        private CharacterStat strengthStat;
        public CharacterStat StrengthStat
        {
            get { return strengthStat; }
            set { strengthStat = value; OnPropertyChanged(nameof(StrengthStat)); }
        }

        private CharacterStat dexterityStat;
        public CharacterStat DexterityStat
        {
            get { return dexterityStat; }
            set { dexterityStat = value; OnPropertyChanged(nameof(DexterityStat)); }
        }

        private CharacterStat constitutionStat;
        public CharacterStat ConstitutionStat
        {
            get { return constitutionStat; }
            set { constitutionStat = value; OnPropertyChanged(nameof(ConstitutionStat)); }
        }

        private CharacterStat intelligenceStat;
        public CharacterStat IntelligenceStat
        {
            get { return intelligenceStat; }
            set { intelligenceStat = value; OnPropertyChanged(nameof(IntelligenceStat)); }
        }

        private CharacterStat wisdomStat;
        public CharacterStat WisdomStat
        {
            get { return wisdomStat; }
            set { wisdomStat = value; OnPropertyChanged(nameof(WisdomStat)); }
        }

        private CharacterStat charismaStat;
        public CharacterStat CharismaStat
        {
            get { return strengthStat; }
            set { strengthStat = value; OnPropertyChanged(nameof(CharismaStat)); }
        }

    }
}
