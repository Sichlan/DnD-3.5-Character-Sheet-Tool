using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.MVVM.ViewModel
{
    public class AbilityScoresViewModel : BaseViewModel
    {
        public RelayCommand LowerStat { get; set; }
        public RelayCommand RaiseStat { get; set; }

        public AbilityScoresViewModel()
        {
            LowerStat = new RelayCommand(o => LowerCharacterStat(o), o => CanLowerCharacterStat(o));
            RaiseStat = new RelayCommand(o => RaiseCharacterStat(o), o => CanRaiseCharacterStat(o));
        }

        private void LowerCharacterStat(object o)
        {
            if (o is CharacterAbilityScore score)
                Character.ChangeBaseStat(score, -1);
        }

        private bool CanLowerCharacterStat(object o)
        {
            if (o is CharacterAbilityScore score)
                return Character.GetBaseStat(score) > 1;
            return false;
        }

        private void RaiseCharacterStat(object o)
        {
            if (o is CharacterAbilityScore score)
                Character.ChangeBaseStat(score, 1);
        }

        private bool CanRaiseCharacterStat(object o)
        {
            return true;
        }
    }
}
