﻿using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterCreator.MVVM.ViewModel
{
    public class NewCharacterViewModel : BaseViewModel
    {
        public RelayCommand LowerStat { get; set; }
        public RelayCommand RaiseStat { get; set; }
        public RelayCommand ChangePicture { get; set; }


        public NewCharacterViewModel()
        {
            Character.SetActiveCharacter();

            LowerStat = new RelayCommand(o => LowerCharacterStat(o), o => CanLowerCharacterStat(o));
            RaiseStat = new RelayCommand(o => RaiseCharacterStat(o), o => CanRaiseCharacterStat(o));
            ChangePicture = new RelayCommand(o => ChangeCharacterPicture(o));
        }

        private void ChangeCharacterPicture(object o)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonPictures);

            OpenFileDialog ofd = new OpenFileDialog()
            {
                InitialDirectory = path
            };

            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;

                Character.ProfilePicture = Image.FromFile(path);
                Character.CharacterEntry.ProfilePicture = Character.ProfilePicture;
            }
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
