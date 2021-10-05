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
                if(temp == null)
                {
                    temp = RecentlyUsedCharacterModel.AddRecentlyUsedCharacterEntry(this);
                }
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
            get => new ObservableCollection<DataErrorInfoContainer>(GetAlwaysFilledErrorList(GetProfileErrors()));
        }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedStrength),
            nameof(CalculatedDexterity),
            nameof(CalculatedConstitution),
            nameof(CalculatedIntelligence),
            nameof(CalculatedWisdom),
            nameof(CalculatedCharisma))]
        public ObservableCollection<DataErrorInfoContainer> AbilityScoreErrors
        {
            get => new ObservableCollection<DataErrorInfoContainer>(GetAlwaysFilledErrorList(GetAbilityScoreErrors()));
        }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedStrength),
            nameof(CalculatedDexterity),
            nameof(CalculatedConstitution),
            nameof(CalculatedIntelligence),
            nameof(CalculatedWisdom),
            nameof(CalculatedCharisma),
            nameof(CharacterName),
            nameof(DisplayName),
            nameof(PlayerName),
            nameof(Creed),
            nameof(Social),
            nameof(ProfilePicture))]
        public ObservableCollection<DataErrorInfoContainer> CreateNewCharacterErrors
        {
            get => new ObservableCollection<DataErrorInfoContainer>(GetAlwaysFilledErrorList(GetCreateNewCharacterErrors()));
        }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(ProfileErrors))]
        public ObservableCollection<DataErrorInfoContainer> AllErrors
        {
            get
            {
                var output = new List<DataErrorInfoContainer>();

                output.AddRange(GetProfileErrors());
                output.AddRange(GetAbilityScoreErrors());

                return new ObservableCollection<DataErrorInfoContainer>(GetAlwaysFilledErrorList(output));
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

        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseConstitution { get; set; }
        public int BaseIntelligence { get; set; }
        public int BaseWisdom { get; set; }
        public int BaseCharisma { get; set; }

        #region CalculatedStats
        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseStrength))]
        public int CalculatedStrength { get => CalculateStat(CharacterAbilityScore.STR); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseDexterity))]
        public int CalculatedDexterity { get => CalculateStat(CharacterAbilityScore.DEX); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseConstitution))]
        public int CalculatedConstitution { get => CalculateStat(CharacterAbilityScore.CON); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseIntelligence))]
        public int CalculatedIntelligence { get => CalculateStat(CharacterAbilityScore.INT); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseWisdom))]
        public int CalculatedWisdom { get => CalculateStat(CharacterAbilityScore.WIS); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(BaseCharisma))]
        public int CalculatedCharisma { get => CalculateStat(CharacterAbilityScore.CHA); }



        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedStrength))]
        public int CalculatedStrengthMod { get => CalculateStatMod(CharacterAbilityScore.STR); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedDexterity))]
        public int CalculatedDexterityMod { get => CalculateStatMod(CharacterAbilityScore.DEX); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedConstitution))]
        public int CalculatedConstitutionMod { get => CalculateStatMod(CharacterAbilityScore.CON); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedIntelligence))]
        public int CalculatedIntelligenceMod { get => CalculateStatMod(CharacterAbilityScore.INT); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedWisdomMod))]
        public int CalculatedWisdomMod { get => CalculateStatMod(CharacterAbilityScore.WIS); }

        [JsonIgnore]
        [AlsoNotifyFor(nameof(CalculatedCharisma))]
        public int CalculatedCharismaMod { get => CalculateStatMod(CharacterAbilityScore.CHA); }
        #endregion CalculatedStats

        [JsonIgnore]
        private static Character _character;


        #region Methods

        private int CalculateStatMod(CharacterAbilityScore stat)
        {
            return (int)Math.Floor((double)(CalculateStat(stat) / 2)) - 5;
        }

        private int CalculateStat(CharacterAbilityScore stat)
        {
            int output = 0;

            switch (stat)
            {
                case CharacterAbilityScore.STR:
                    output += BaseStrength;
                    break;
                case CharacterAbilityScore.DEX:
                    output += BaseDexterity;
                    break;
                case CharacterAbilityScore.CON:
                    output += BaseConstitution;
                    break;
                case CharacterAbilityScore.INT:
                    output += BaseIntelligence;
                    break;
                case CharacterAbilityScore.WIS:
                    output += BaseWisdom;
                    break;
                case CharacterAbilityScore.CHA:
                    output += BaseCharisma;
                    break;
                default:
                    break;
            }

            return output;
        }

        private void Character_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName != nameof(HasChanges))
                HasChanges = true;
        }

        public static Character GetActiveCharacter()
        {
            return _character;
        }

        /// <summary>
        /// Used to create a character with default values
        /// </summary>
        /// <returns></returns>
        private static Character CreateEmptyCharacter()
        {
            return new Character()
            {
                BaseStrength = 10,
                BaseDexterity = 10,
                BaseConstitution = 10,
                BaseIntelligence = 10,
                BaseWisdom = 10,
                BaseCharisma = 10
            };
        }

        public static void SetActiveCharacter(bool loadFromDirectory = false)
        {
            Character character = CreateEmptyCharacter();
            character.PropertyChanged += character.Character_PropertyChanged;

            if (loadFromDirectory)
            {
                character = LoadCharacter();
            }

            if (_character?.HasChanges == true)
            {
                var result = MessageBox.Show(Properties.Resources.WarningCharacterHasUnsavedChanges, Properties.Resources.SaveCharacterDialogTitle, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _character.SaveCharacter();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            _character = character;

            ActiveCharacterChanged?.Invoke();
        }

        public static void SetActiveCharacter(string folderPath, string fileName, Guid guid)
        {
            Character character = SaveLoadModel.Load<Character>(folderPath, fileName);
            character.ID = guid;
            character.PropertyChanged += character.Character_PropertyChanged;


            if (_character?.HasChanges == true)
            {
                var result = MessageBox.Show(Properties.Resources.WarningCharacterHasUnsavedChanges, Properties.Resources.SaveCharacterDialogTitle, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _character.SaveCharacter();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

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
                    DefaultExt = "cs35",
                    Filter = "Character Sheet (cs35)|*.cs35|JSON (.json)|*.json",
                    InitialDirectory = FolderPath,
                    Title = Properties.Resources.SaveCharacterDialogTitle,
                    ValidateNames = true,
                    FileName = String.IsNullOrEmpty(DisplayName) ? String.IsNullOrEmpty(CharacterName) ? "NewCharacter" : CharacterName : DisplayName,
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

            CharacterEntry.LastUpdate = DateTime.Now;
            CharacterEntry.FolderPath = FolderPath;
            CharacterEntry.FileName = FileName;
            CharacterEntry.Name = DisplayName;

            HasChanges = false;

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

        private List<DataErrorInfoContainer> GetAlwaysFilledErrorList(List<DataErrorInfoContainer> dataErrorInfoContainers)
        {
            if (dataErrorInfoContainers == null || dataErrorInfoContainers.Count < 1)
                return new List<DataErrorInfoContainer>() { new DataErrorInfoContainer(DataErrorType.Info, Properties.Resources.NoWarningToDisplay) };
            return dataErrorInfoContainers;
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

        private List<DataErrorInfoContainer> GetAbilityScoreErrors()
        {
            var output = new List<DataErrorInfoContainer>();

            if (CalculatedStrength <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityStrength + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));
            if (CalculatedDexterity <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityDexterity + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));
            if (CalculatedConstitution <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityConstitution + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));
            if (CalculatedIntelligence <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityIntelligence + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));
            if (CalculatedWisdom <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityWisdom + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));
            if (CalculatedCharisma <= 0)
                output.Add(new DataErrorInfoContainer(DataErrorType.Warning, Properties.Resources.AbilityCharisma + ": " + Properties.Resources.WarningAbilityScoreIsZeroOrBelow));

            return output;
        }

        private List<DataErrorInfoContainer> GetCreateNewCharacterErrors()
        {
            var output = new List<DataErrorInfoContainer>();

            output.AddRange(GetAbilityScoreErrors());
            output.AddRange(GetProfileErrors());

            return output;
        }

        public void ChangeBaseStat(CharacterAbilityScore abilityScore, int value)
        {
            switch (abilityScore)
            {
                case CharacterAbilityScore.STR:
                    BaseStrength += value;
                    break;
                case CharacterAbilityScore.DEX:
                    BaseDexterity += value;
                    break;
                case CharacterAbilityScore.CON:
                    BaseConstitution += value;
                    break;
                case CharacterAbilityScore.INT:
                    BaseIntelligence += value;
                    break;
                case CharacterAbilityScore.WIS:
                    BaseWisdom += value;
                    break;
                case CharacterAbilityScore.CHA:
                    BaseCharisma += value;
                    break;
                default:
                    break;
            }
        }

        public int GetBaseStat(CharacterAbilityScore abilityScore)
        {
            switch (abilityScore)
            {
                case CharacterAbilityScore.STR:
                    return BaseStrength;
                case CharacterAbilityScore.DEX:
                    return BaseDexterity;
                case CharacterAbilityScore.CON:
                    return BaseConstitution;
                case CharacterAbilityScore.INT:
                    return BaseIntelligence;
                case CharacterAbilityScore.WIS:
                    return BaseWisdom;
                case CharacterAbilityScore.CHA:
                    return BaseCharisma;
                default:
                    return 0;
            }
        }
        #endregion Methods
    }

    public enum CharacterAbilityScore
    {
        STR,
        DEX,
        CON,
        INT,
        WIS,
        CHA
    }
}
