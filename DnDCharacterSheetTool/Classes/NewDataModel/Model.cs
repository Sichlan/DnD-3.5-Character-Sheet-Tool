using DnDCharacterSheetTool.Classes.DataModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Model : INotifyPropertyChanged
    {
        private static readonly object theLock = new object();
        private static Model model = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Condition> Conditions { get; set; }
        public ObservableCollection<Deity> Deities { get; set; }
        public ObservableCollection<Domain> Domains { get; set; }
        public ObservableCollection<DomainVariant> DomainVariants { get; set; }
        public ObservableCollection<Edition> Editions { get; set; }
        public ObservableCollection<Feat> Feats { get; set; }
        public ObservableCollection<FeatVariant> FeatVariants { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<Skill> Skills { get; set; }
        public ObservableCollection<SkillVariant> SkillVariants { get; set; }
        public ObservableCollection<SourceBook> SourceBooks { get; set; }

        private Model()
        {
            Conditions = new ObservableCollection<Condition>(DataLoader.Load<Condition>("Conditions.json"));
            Deities = new ObservableCollection<Deity>(DataLoader.Load<Deity>("Deities.json"));
            Domains = new ObservableCollection<Domain>(DataLoader.Load<Domain>("Domains.json"));
            DomainVariants = new ObservableCollection<DomainVariant>(DataLoader.Load<DomainVariant>("DomainVariants.json"));
            Editions = new ObservableCollection<Edition>(DataLoader.Load<Edition>("Editions.json"));
            Feats = new ObservableCollection<Feat>(DataLoader.Load<Feat>("Feats.json"));
            FeatVariants = new ObservableCollection<FeatVariant>(DataLoader.Load<FeatVariant>("FeatVariants.json"));
            Languages = new ObservableCollection<Language>(DataLoader.Load<Language>("Languages.json"));
            Skills = new ObservableCollection<Skill>(DataLoader.Load<Skill>("Skills.json"));
            SkillVariants = new ObservableCollection<SkillVariant>(DataLoader.Load<SkillVariant>("SkillVariants.json"));
            SourceBooks = new ObservableCollection<SourceBook>(DataLoader.Load<SourceBook>("SourceBooks.json"));
        }

        public static Model GetInstance()
        {
            if (model == null)
            {
                lock (theLock)
                {
                    if (model == null)
                    {
                        model = new Model();
                    }
                }
            }
            return model;
        }
    }
}
