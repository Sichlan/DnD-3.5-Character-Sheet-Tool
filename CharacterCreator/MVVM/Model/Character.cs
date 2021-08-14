using CharacterCreator.Core;
using CharacterCreator.Core.Converter;
using Microsoft.Win32;
using Newtonsoft.Json;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CharacterCreator.MVVM.Model
{
    public class Character : ObservableObject
    {
        #region BackendStuff
        public static event Action ActiveCharacterChanged;
        public string FileName { get; set; }
        public string FolderPath { get; set; }
        public Guid ID { get; set; }
        [JsonIgnore]
        public RecentlyUsedCharacterEntry CharacterEntry
        {
            get
            {
                var temp = RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel(null).RecentlyUsedCharacter.FirstOrDefault(x => x.ID == ID);
                return temp;
            }
        }
        public bool HasChanges { get; private set; }
        #endregion BackendStuff


        #region DataValidation
        [JsonIgnore]
        [AlsoNotifyFor(nameof(CharacterName), 
            nameof(DisplayName), 
            nameof(PlayerName), 
            nameof(Creed), 
            nameof(Social), 
            nameof(ProfilePicture))]
        public ObservableCollection<DataErrorInfoContainer> ProfileErrors
        {
            get => new ObservableCollection<DataErrorInfoContainer>(GetProfileErrors());
        }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(ProfileErrors))]
        public ObservableCollection<DataErrorInfoContainer> AllErrors
        {
            get
            {
                var output = new List<DataErrorInfoContainer>();

                output.AddRange(GetProfileErrors());

                return new ObservableCollection<DataErrorInfoContainer>(output);
            }
        }
        #endregion


        #region Profile
        public string CharacterName { get; set; }
        public string DisplayName { get; set; }
        public string PlayerName { get; set; }
        public CreedAlignment? Creed { get; set; }
        public SocialAlignment? Social { get; set; }
        [JsonConverter(typeof(JsonImageConverter))]
        public Image ProfilePicture { get; set; }
        public string Notes { get; set; }
        #endregion Profile


        [JsonIgnore]
        private static Character _character;


        #region Methods

        private void Character_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            HasChanges = true;
        }

        public static Character GetActiveCharacter()
        {
            return _character;
        }

        public static void SetActiveCharacter(bool loadFromDirectory = false)
        {
            Character character = new Character();

            if(loadFromDirectory)
            {
                character = LoadCharacter();
            }

            _character = character;

            ActiveCharacterChanged?.Invoke();
        }

        public static void SetActiveCharacter(string folderPath, string fileName, Guid guid)
        {
            Character character = SaveLoadModel.Load<Character>(folderPath, fileName);
            character.ID = guid;
            character.PropertyChanged += character.Character_PropertyChanged;

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

            HasChanges = false;
            CharacterEntry.LastUpdate = DateTime.Now;
            CharacterEntry.FolderPath = FolderPath;
            CharacterEntry.FileName = FileName;
            CharacterEntry.Name = DisplayName;

            SaveLoadModel.Save<Character>(FolderPath, FileName, _character);
            RecentlyUsedCharacterModel.GetRecentlyUsedCharacterModel(null).SaveRecentlyUsedCharacterModel();
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

                    var character = SaveLoadModel.Load<Character>(folderPath, openFileDialog.SafeFileName);
                    character.PropertyChanged += character.Character_PropertyChanged;
                    return character;
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
                DebugLogger.WriteLog(ex.Message, DebugLogger.LogLevel.ERROR);
                return null;
            }
        }

        private List<DataErrorInfoContainer> GetProfileErrors()
        {
            var output = new List<DataErrorInfoContainer>();

            if (String.IsNullOrEmpty(CharacterName))
                output.Add(new DataErrorInfoContainer(DataErrorType.Info, Properties.Resources.ErrorNoCharacterName));
            if (String.IsNullOrEmpty(PlayerName))
                output.Add(new DataErrorInfoContainer(DataErrorType.Info, Properties.Resources.ErrorNoPlayerName));
            if (Creed == null)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.ErrorNoCreedAlignment));
            if (Social == null)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.ErrorNoSocialAlignment));
            if (ProfilePicture == null)
                output.Add(new DataErrorInfoContainer(DataErrorType.Info, Properties.Resources.ErrorNoProfilePicture));

            return output;
        }
        #endregion Methods
    }
}
