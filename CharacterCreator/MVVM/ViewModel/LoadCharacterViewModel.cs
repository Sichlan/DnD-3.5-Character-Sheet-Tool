using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public RecentlyUsedCharacterEntry MostRecentUsed
        {
            get
            {
                InitHistoryIfNull();

                return _characterHistory.Aggregate((x, y) => x.LastUpdate > y.LastUpdate ? x : y);
            }
        }

        public void InitHistoryIfNull()
        {
            if (_characterHistory == null)
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
