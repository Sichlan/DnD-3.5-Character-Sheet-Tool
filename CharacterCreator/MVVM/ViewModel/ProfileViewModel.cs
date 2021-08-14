using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CharacterCreator.MVVM.ViewModel
{
    class ProfileViewModel : BaseViewModel
    {
        public Character Character { get => Character.GetActiveCharacter(); }
        public RelayCommand ChangePicture { get; set; }

        public ProfileViewModel()
        {
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
    }
}
