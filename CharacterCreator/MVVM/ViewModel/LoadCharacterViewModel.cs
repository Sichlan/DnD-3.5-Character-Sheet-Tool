using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.MVVM.ViewModel
{
    public class LoadCharacterViewModel : BaseViewModel
    {
        public RelayCommand CharacterSelected { get; set; }

        private ObservableCollection<RecentlyUsedCharacterEntry> _characterHistory;
        public ObservableCollection<RecentlyUsedCharacterEntry> CharacterHistory
        {
            get
            {
                InitHistoryIfNull();

                return _characterHistory;
            }
        }

        public RecentlyUsedCharacterEntry DummyNewCharacter
        {
            get
            {
                return ConstructNewCharacterButton();
            }
        }

        private RecentlyUsedCharacterEntry ConstructNewCharacterButton()
        {
            var output = new RecentlyUsedCharacterEntry()
            {
                CharacterSelectedCommand = CharacterSelected,
                isNewCharacter = true,
                LastUpdate = DateTime.Now,
                LeftColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("Transparent"),
                RightColor = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("Transparent"),
                Name = Properties.Resources.CreateNewCharacter,
                PreviewInfo = Properties.Resources.ClickToCreateNewCharacter,
                ProfilePicture = Properties.Resources.AddButton// Image.FromFile(Environment.CurrentDirectory + @"\..\..\Images\AddButton.png")
            };
            return output;
        }

        public override void SelectViewModel()
        {
            InitHistoryIfNull(true);

            OnPropertyChanged(nameof(CharacterHistory));
            OnPropertyChanged(nameof(MostRecentUsed));

            base.SelectViewModel();
        }

        public RecentlyUsedCharacterEntry MostRecentUsed
        {
            get
            {
                InitHistoryIfNull();

                if (_characterHistory.Any())
                    return _characterHistory.Aggregate((x, y) => x.LastUpdate > y.LastUpdate ? x : y);
                else
                    return null;
            }
        }

        public void InitHistoryIfNull(bool hardReset = false)
        {
            if (_characterHistory == null || hardReset)
            {
                RecentlyUsedCharacterModel model = RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel(CharacterSelected);
                _characterHistory = new ObservableCollection<RecentlyUsedCharacterEntry>(model.RecentlyUsedCharacter.OrderByDescending(x => x.LastUpdate).ToList());
            }
        }

        public LoadCharacterViewModel(RelayCommand characterSelected)
        {
            CharacterSelected = characterSelected;
        }
    }
}
