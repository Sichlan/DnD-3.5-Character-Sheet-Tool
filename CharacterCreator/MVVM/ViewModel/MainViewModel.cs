using CharacterCreator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterCreator.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
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
        #endregion Commands

        #region ViewModels
        public CharacterSheetViewModel CharacterSheetVM { get; set; }
        public ProfileViewModel ProfileVM { get; set; }
        #endregion ViewModels

        public MainViewModel()
        {
            #region InitCommands
            CommandMinimize = new RelayCommand(o =>
            {
                CurrentWindowState = WindowState.Minimized;
            });
            CommandMaximize = new RelayCommand(o =>
            {
                CurrentWindowState = CurrentWindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
            });
            CommandClose = new RelayCommand(o =>
            {
                if(o != null && o is Window)
                {
                    (o as Window).Close();
                }
            });
            CommandSwitchView = new RelayCommand(o =>
            {
                CurrentView = o;
            });
            #endregion initCommands

            #region VMs
            CharacterSheetVM = new CharacterSheetViewModel();
            ProfileVM = new ProfileViewModel();
            #endregion VMs

            #region InitProperties
            CurrentWindowState = WindowState.Maximized;

            CurrentView = CharacterSheetVM;
            #endregion InitProperties
        }
    }
}
