using CharacterCreator.Core;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterCreator.MVVM.Model
{
    public class Character
    {
        #region BackendStuff
        public static event Action ActiveCharacterChanged;
        public string FileName { get; set; }
        public string FolderPath { get; set; }
        #endregion BackendStuff

        #region Profile
        public string CharacterName { get; set; }
        public string DisplayName { get; set; }
        public string PlayerName { get; set; }
        public Enums.CreedAlignment? Creed { get; set; }
        public Enums.SocialAlignment? Social { get; set; }
        #endregion Profile

        [JsonIgnore]
        private static Character _character;

        #region Methods
        public static Character GetActiveCharacter()
        {
            if(_character == null)
            {
                SetActiveCharacter(true);
            }

            return _character;
        }

        public static void SetActiveCharacter(bool loadFromDirectory = false)
        {
            Character character = null;

            if(loadFromDirectory)
            {
                character = LoadCharacter();
            }

            if (character == null)
            {
                character = new Character();
            }

            _character = character;

            ActiveCharacterChanged?.Invoke();
        }

        public static void SetActiveCharacter(string folderPath, string fileName)
        {
            Character character = SaveLoadModel.Load<Character>(folderPath, fileName);

            _character = character;

            ActiveCharacterChanged?.Invoke();
        }

        public void SaveCharacter(bool saveToDirectoryExplicitDecision = false)
        {
            if(String.IsNullOrEmpty(FolderPath))
            {
                FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Properties.Settings.Default.SaveFolder;
            }

            if(String.IsNullOrEmpty(FileName) || saveToDirectoryExplicitDecision == true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    AddExtension = true,
                    DefaultExt = "charactersheet",
                    InitialDirectory = FolderPath,
                    Title = Properties.Resources.SaveCharacterDialogTitle,
                    ValidateNames = true
                };

                if(saveFileDialog.ShowDialog() == true)
                {
                    FileName = saveFileDialog.SafeFileName;
                }
                else
                {
                    MessageBox.Show(Properties.Resources.SaveCharacterCancelledMessage, Properties.Resources.SaveCharacterDialogTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            SaveLoadModel.Save<Character>(FolderPath, FileName, _character);
        }

        private static Character LoadCharacter()
        {
            try
            {
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Properties.Settings.Default.SaveFolder;

                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Title = Properties.Resources.LoadCharacterDialogTitle,
                    FileName = "Select a file",
                    Filter = $"{Properties.Resources.CharacterSheetFileType} (*.characetrsheet)|*.charactersheet|{Properties.Resources.AllFilesFileType} (*.*)|*.*",
                    DefaultExt = "charactersheet",
                    InitialDirectory = folderPath
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    folderPath = openFileDialog.FileName.Substring(0, openFileDialog.FileName.IndexOf(openFileDialog.SafeFileName));

                    return SaveLoadModel.Load<Character>(folderPath, openFileDialog.SafeFileName);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.LoadCharacterCancelledMessage, Properties.Resources.LoadCharacterDialogTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Properties.Resources.LoadCharacterExceptionMessage, Properties.Resources.LoadCharacterDialogTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                return null;
            }
        }
        #endregion Methods
    }
}
