﻿using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreator.MVVM.ViewModel
{
    class ProfileViewModel : BaseViewModel
    {
        public Character Character { get => Character.GetActiveCharacter(); }
    }
}
