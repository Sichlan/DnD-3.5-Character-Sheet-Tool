using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_3._5_Character_Sheet_Tool.Classes.DataModel
{
    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public class Race : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private string name;
        [Description("The races name")]
        [JsonProperty(Required = Required.Always)]
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private SourceBook source;
        [Description("The title of the source the race was added in")]
        public SourceBook Source
        {
            get { return source; }
            set { source = value; OnPropertyChanged(nameof(Source)); }
        }

        private int? page;
        [Description("The page the race can be found on in the source")]
        public int? Page
        {
            get { return page; }
            set { page = value; OnPropertyChanged(nameof(Page)); }
        }

        private string link;
        [Description("The link to dndtools.net for the race as a reference")]
        public string Link
        {
            get { return link; }
            set { link = value; OnPropertyChanged(nameof(Link)); }
        }

        private string subraceOf;
        [Description("The direct race this race was derived from.\nFor Example: a Lesser Dark Elf is a Subrace of Dark Elf, which is a subrace of Elf.")]
        public string SubraceOf
        {
            get { return subraceOf; }
            set { subraceOf = value; OnPropertyChanged(nameof(SubraceOf)); }
        }

        private string description;
        [Description("Just a short description for the race, should not be more than a paragraph")]
        public string Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged(nameof(Description)); }
        }


        private CreatureType type;
        [Description("The races type.\n0 - Aberration\n1 - Animal\n2 - Celestial\n3 - Construct\n4 - Dragon\n5 - Elemental\n6 - Fey\n7 - Fiend\n8 - Giant\n9 - Humanoid\n10 - Magical_Beast\n11 - Monstrous_Humanoid\n12 - Ooze\n13 - Outsider\n14 - Plant\n15 - Undead\n16 - Vermin")]
        public CreatureType Type
        {
            get { return type; }
            set { type = value; OnPropertyChanged(nameof(Type)); }
        }

        private List<CreatureSubTypes> subTypes;
        [Description("The races subtype(s), if any.\n0 - Air\n1 - Angel\n2 - Aquatic\n3 - Archon\n4 - Augmented\n5 - Chaotic\n6 - Cold\n7 - Demon\n8 - Devil\n9 - Dwarf\n10 - Earth\n11 - Elf\n12 - Evil\n13 - Extraplanar\n14 - Fire\n15 - Good\n16 - Gnoll\n17 - Gnome\n18 - Goblinoid\n19 - Halfling\n20 - Human\n21 - Incorporeal\n22 - Lawful\n23 - Native\n24 - Orc\n25 - Psionic\n26 - Reptilian\n27 - Shapechanger\n28 - Swarm\n29 - Water")]
        public List<CreatureSubTypes> SubTypes
        {
            get { return subTypes; }
            set { subTypes = value; OnPropertyChanged(nameof(SubTypes)); }
        }

        private string favoredClass;
        [Description("The races favored class(es), if any\nIf the race has 'Any' as it's favored class, this field has to be NULL!")]
        public string FavoredClass
        {
            get { return favoredClass; }
            set { favoredClass = value; OnPropertyChanged(nameof(FavoredClass)); }
        }

        private int countHitDice;
        [Description("The number of racial hitdice")]
        public int CountHitDice
        {
            get { return countHitDice; }
            set { countHitDice = value; OnPropertyChanged(nameof(CountHitDice)); }
        }

        private int sizeHitDice;
        [Description("The type of racial hitdie.\nFor example a 'd8' is simply noted as '8'")]
        public int SizeHitDice
        {
            get { return sizeHitDice; }
            set { sizeHitDice = value; OnPropertyChanged(nameof(SizeHitDice)); }
        }

        private int levelAdjustment;
        [Description("The races LA")]
        public int LevelAdjustment
        {
            get { return levelAdjustment; }
            set { levelAdjustment = value; OnPropertyChanged(nameof(LevelAdjustment)); }
        }

        //Multi-sized Races: Dwarf,
        private SizeCategory sizeCategory;
        [Description("The races default sizeCategory.\nMULTI-SIZED RACES HAVE TO BE NOTED IN THE COMMENT ABOVE SIZECATEGORY IN RACE.CS!\n-4 - Fine\n-3 - Diminutive\n-2 - Tiny\n-1 - Small\n0 - Medium\n1 - Large\n2 - Huge\n3 - Gargantuan\n4 - Colossal\n5 - BiggerThanColossal")]
        public SizeCategory SizeCategory
        {
            get { return sizeCategory; }
            set { sizeCategory = value; OnPropertyChanged(nameof(SizeCategory)); }
        }

        private Dictionary<MovementMode, int> movement;
        [Description("The races movement modes.\nUse the name of the movement as Key and the range as value.\nFor Example: Flyspeed 30ft. = \"Fly\": \"30\"\nKeys derived from 'Enums.cs/MovementModes'")]
        public Dictionary<MovementMode, int> Movement
        {
            get { return movement; }
            set { movement = value; OnPropertyChanged(nameof(Movement)); }
        }

        private Dictionary<Sense, int?> senses;
        [Description("The races senses like low-light vision, blindsight, etc.\nIf the sense is limited to a static range (opposed by senses like low light vision, hich just double the standard vision range) enter the range in feet as an int, otherwise enter 'NULL'.\nAn exception is 'Improved Low-Light Vision', to insert this you set 'Low-light Vision' as key and set its value to '2' (aka '2' * LLV Range)'\nKey derived from Enums.cs/Sense.")]
        public Dictionary<Sense, int?> Senses
        {
            get { return senses; }
            set { senses = value; OnPropertyChanged(nameof(Senses)); }
        }

        private List<StatChange> statChanges;
        [Description("The Races StatChanges")]
        public List<StatChange> StatChanges
        {
            get { return statChanges; }
            set { statChanges = value; OnPropertyChanged(nameof(StatChanges)); }
        }

        //Todo: Turn this crap into something the Algorithm can work with!
        private List<object> raceFeatures;
        [Description("The races Race Features")]
        public List<object> RaceFeatures
        {
            get { return raceFeatures; }
            set { raceFeatures = value; OnPropertyChanged(nameof(RaceFeatures)); }
        }

    }
}
