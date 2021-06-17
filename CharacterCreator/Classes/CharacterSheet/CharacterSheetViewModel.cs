using CharacterCreator.CharacterSheet.Classes;
using CharacterCreator.Classes.CommonObject;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CharacterCreator.Classes.CharacterSheet
{
    public class CharacterSheetViewModel : INotifyPropertyChanged
    {
        #region NewCharacter
        public ICommand NewCharacter 
        {
            get => new BasicCommand(ExecuteNewCharacter, CanExecuteNewCharacter);
        }

        /// <summary>
        /// Creates a new character.
        /// Will also save the current character if there is any.
        /// </summary>
        /// <param name="param">Currently not used</param>
        public void ExecuteNewCharacter(object param)
        {
            SaveBeforeChangeActiveCharacter();
            ActiveCharacter = new Character();
        }

        /// <summary>
        /// Returns if the user can currently create a new character
        /// So far there is no reason why the user shouldn't be able to create a new character, thus the method always returns true
        /// </summary>
        /// <param name="param">Currently not used</param>
        /// <returns></returns>
        public bool CanExecuteNewCharacter(object param)
        {
            return true;
        }
        #endregion NewCharacter

        #region SaveCharacter
        public ICommand SaveCharacter 
        {
            get => new BasicCommand(ExecuteSaveCharacter, CanExecuteSave);
        }

        /// <summary>
        /// Saves the active character to either the set file path or a new path that the user selects.
        /// </summary>
        /// <param name="obj">Currently not used</param>
        private void ExecuteSaveCharacter(object obj)
        {
            if (ActiveCharacter == null)
                return;

            if (String.IsNullOrEmpty(ActiveCharacter.FilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Filter = "Character file (*.charactersheet)|*.charactersheet",
                    InitialDirectory = Properties.Settings.Default.CharacterSheetViewLastFileDirectorty
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    ActiveCharacter.FilePath = saveFileDialog.FileName;
                }
                else
                    return;
            }

            string lastDirectory = ActiveCharacter.FilePath.Substring(0, ActiveCharacter.FilePath.LastIndexOf("\\"));
            Properties.Settings.Default.CharacterSheetViewLastFileDirectorty = lastDirectory;

            using (StreamWriter writer = File.CreateText(ActiveCharacter.FilePath))
            {
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Include,
                    TypeNameHandling = TypeNameHandling.All
                };

                string characterAsJson = JsonConvert.SerializeObject(ActiveCharacter, serializerSettings);
                writer.Write(characterAsJson);
            }
        }

        /// <summary>
        /// If there is an active character the user can save it.
        /// </summary>
        /// <param name="arg">Currently not used</param>
        /// <returns></returns>
        private bool CanExecuteSave(object arg)
        {
            if(ActiveCharacter != null)
            {
                return true;
            }
            return false;
        }
        #endregion SaveCharacter

        #region LoadCharacter
        public ICommand LoadCharacter 
        {
            get => new BasicCommand(ExecuteLoadCharacter, CanExecuteLoadCharacter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteLoadCharacter(object obj)
        {
            SaveBeforeChangeActiveCharacter();

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Properties.Settings.Default.CharacterSheetViewLastFileDirectorty,
                Filter = "Character file (*.charactersheet)|*.charactersheet"
            };

            if(openFileDialog.ShowDialog() == true)
            {
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Include,
                    TypeNameHandling = TypeNameHandling.All
                };

                var charTemp = JsonConvert.DeserializeObject(File.ReadAllText(openFileDialog.FileName), serializerSettings);
                if(charTemp is Character)
                {
                    ActiveCharacter = charTemp as Character;
                }
            }
            else
            {
                return;
            }

            string lastDirectory = ActiveCharacter.FilePath.Substring(0, ActiveCharacter.FilePath.LastIndexOf("\\"));
            Properties.Settings.Default.CharacterSheetViewLastFileDirectorty = lastDirectory;
        }

        /// <summary>
        /// There is currently no reason why the user shouldn't be able to load a character, so this always returns true
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanExecuteLoadCharacter(object arg)
        {
            return true;
        }
        #endregion LoadCharacter

        public Character ActiveCharacter { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        /// <summary>
        /// If there is an active character with changes and the user attempts to change the active character, save the active character before it gets changed.
        /// </summary>
        private void SaveBeforeChangeActiveCharacter()
        {
            if (ActiveCharacter?.hasChanges == true && CanExecuteSave(null))
            {
                ExecuteSaveCharacter(null);
            }
        }

        internal void LoadCharacterPicture()
        {
            if (ActiveCharacter == null)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = Properties.Settings.Default.CharacterSheetViewLastFileDirectorty,
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.gif"
            };

            if(openFileDialog.ShowDialog() == true)
            {
                Image temp = Image.FromFile(openFileDialog.FileName);
                if (temp != null)
                    ActiveCharacter.ProfilePicture = temp;
            }
        }
    }
}
