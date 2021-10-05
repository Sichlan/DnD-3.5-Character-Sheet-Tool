using CharacterCreator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.Core
{
    public class BaseViewModel : ObservableObject
    {
        public Character Character { get => Character.GetActiveCharacter(); }

        public bool IsSelected { get; set; }

        public virtual void SelectViewModel()
        {
            IsSelected = true;
        }

        public virtual void DeselectViewModel()
        {
            IsSelected = false;
        }
    }
}
