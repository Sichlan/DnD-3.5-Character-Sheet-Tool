using DnDCharacterSheetTool.Classes.DataModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DnDCharacterSheetTool.Classes.NewDataModel
{
    public class Model : INotifyPropertyChanged
    {
        private static object theLock = new object();
        private static Model model = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Edition> Editions { get; set; }
        public ObservableCollection<Feat> Feats { get; set; }
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<SourceBook> SourceBooks { get; set; }

        private Model()
        {
            Editions = new ObservableCollection<Edition>(DataLoader.Load<Edition>("Editions.json"));
            Feats = new ObservableCollection<Feat>(DataLoader.Load<Feat>("Feats.json"));
            Languages = new ObservableCollection<Language>(DataLoader.Load<Language>("Languages.json"));
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
