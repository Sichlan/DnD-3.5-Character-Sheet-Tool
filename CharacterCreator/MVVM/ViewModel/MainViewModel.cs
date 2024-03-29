﻿using CharacterCreator.Core;
using CharacterCreator.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterCreator.MVVM.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public WindowState CurrentWindowState { get; set; }

        #region Commands
        public RelayCommand CommandMinimize { get; set; }
        public RelayCommand CommandMaximize { get; set; }
        public RelayCommand CommandClose { get; set; }
        public RelayCommand CommandSwitchView { get; set; }
        public RelayCommand CommandSaveCharacter { get; set; }
        #endregion Commands

        #region ViewModels
        public List<BaseViewModel> SubViewModels { get; set; } = new List<BaseViewModel>();
        public CharacterSheetViewModel CharacterSheetVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        public JournalViewModel JournalVM { get; set; }
        public NewCharacterViewModel NewCharacterVM { get; set; }
        public LoadCharacterViewModel LoadCharacterVM { get; set; }
        public AbilityScoresViewModel AbilityScoresVM { get; set; }
        #endregion ViewModels

        public MainViewModel()
        {
            DebugLogger.WriteLog("Initializing main view model...", DebugLogger.LogLevel.INFO);

            #region InitCommands
            DebugLogger.WriteLog("Initializing commands...", DebugLogger.LogLevel.INFO);

            CommandMinimize = new RelayCommand(o => MinimizeWindow(o));
            CommandMaximize = new RelayCommand(o => MaximizeWindow(o));
            CommandClose = new RelayCommand(o => CloseWindow(o));
            CommandSwitchView = new RelayCommand(o => SwitchView(o), o => CanSwitchCharacterView(o));
            CommandSaveCharacter = new RelayCommand(o => SaveCharacter(o), o => CanSaveCharacter(o));

            DebugLogger.WriteLog("Finished initializing commands.", DebugLogger.LogLevel.INFO);
            #endregion initCommands

            #region VMs
            DebugLogger.WriteLog("Initializing view models...", DebugLogger.LogLevel.INFO);

            SubViewModels.Add(CharacterSheetVM = new CharacterSheetViewModel());
            SubViewModels.Add(ProfileVM = new ProfileViewModel());
            SubViewModels.Add(JournalVM = new JournalViewModel());
            SubViewModels.Add(NewCharacterVM = new NewCharacterViewModel());
            SubViewModels.Add(LoadCharacterVM = new LoadCharacterViewModel(new RelayCommand(o => SelectCharacter(o))));
            SubViewModels.Add(AbilityScoresVM = new AbilityScoresViewModel());

            DebugLogger.WriteLog("Finished initializing view models.", DebugLogger.LogLevel.INFO);
            #endregion VMs

            #region InitProperties
            DebugLogger.WriteLog("Initializing properties...", DebugLogger.LogLevel.INFO);
            CurrentWindowState = WindowState.Maximized;

            SwitchView(LoadCharacterVM);
            DebugLogger.WriteLog("Finished initializing properties.", DebugLogger.LogLevel.INFO);
            #endregion InitProperties

            DebugLogger.WriteLog("Finished initializing main view model.", DebugLogger.LogLevel.INFO);
        }

        private bool CanSaveCharacter(object o)
        {
            return Character?.HasChanges == true;
        }

        private void SaveCharacter(object o)
        {
            Character?.SaveCharacter();
        }

        private void SelectCharacter(object o)
        {
            if(Character.GetActiveCharacter() != null)
            {
                SwitchView(ProfileVM);
                OnPropertyChanged(nameof(Character));
            }
        }

        /// <summary>
        /// Switches the selected view to the view given as parameter
        /// </summary>
        /// <param name="o">The new active view</param>
        private void SwitchView(object o)
        {
            if(o is BaseViewModel baseView)
            {
                //Setting IsSelected of the previous view to false
                if (CurrentView != null)
                    CurrentView.DeselectViewModel();

                //Setting the new view
                CurrentView = baseView;

                //Setting IsSelected of the new view to true
                CurrentView.SelectViewModel();

                //Execute any action necessary when selecting a certain page
                HandlePageSelectionEvents(CurrentView);
            }
        }

        private bool CanSwitchCharacterView(object o)
        {
            if (!(o is BaseViewModel viewModel))
                return false;
            else if (o is NewCharacterViewModel || o is LoadCharacterViewModel)
                return true;
            else if (Character != null)
                return true;
            else
                return false;
        }

        private void HandlePageSelectionEvents(BaseViewModel currentView)
        {
            if(currentView == NewCharacterVM)
            {
                Character.SetActiveCharacter();
            }
        }

        private void CloseWindow(object o)
        {
            if (o != null && o is Window)
            {
                (o as Window).Close();
            }
        }

        private void MaximizeWindow(object o)
        {
            CurrentWindowState = CurrentWindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void MinimizeWindow(object o)
        {
            CurrentWindowState = WindowState.Minimized;
        }
    }
}
