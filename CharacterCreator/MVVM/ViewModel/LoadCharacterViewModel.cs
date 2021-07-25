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
    public class LoadCharacterViewModel : ObservableObject
    {
        private ObservableCollection<RecentlyUsedCharacterEntry> _characterHistory;
        public ObservableCollection<RecentlyUsedCharacterEntry> CharacterHistory
        {
            get
            {
                if(_characterHistory == null)
                {
                    RecentlyUsedCharacterModel model = RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel();
                    _characterHistory = new ObservableCollection<RecentlyUsedCharacterEntry>(model.recentlyUsedCharacter.OrderByDescending(x => x.LastUpdate).ToList());
                }

                return _characterHistory;
            }
        }

        public RecentlyUsedCharacterEntry MostRecentUsed
        {
            get
            {
                if (_characterHistory == null)
                {
                    RecentlyUsedCharacterModel model = RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel();
                    _characterHistory = new ObservableCollection<RecentlyUsedCharacterEntry>(model.recentlyUsedCharacter.OrderByDescending(x => x.LastUpdate).ToList());
                }

                return _characterHistory.Aggregate((x, y) => x.LastUpdate > y.LastUpdate ? x : y);
            }
        }
    }
}
