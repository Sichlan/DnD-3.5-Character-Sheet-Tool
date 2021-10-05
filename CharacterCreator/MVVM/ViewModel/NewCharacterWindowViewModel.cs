using CharacterCreator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CharacterCreator.MVVM.ViewModel
{
    public class NewCharacterWindowViewModel : BaseViewModel
    {
        public RelayCommand CommandMinimize { get; set; }
        public RelayCommand CommandMaximize { get; set; }
        public RelayCommand CommandClose { get; set; }
        public NewCharacterViewModel NewCharacterViewModel { get; set; }

        public WindowState CurrentWindowState { get; set; }

        public NewCharacterWindowViewModel()
        {
            NewCharacterViewModel = new NewCharacterViewModel();

            CommandMinimize = new RelayCommand(o => MinimizeWindow(o));
            CommandMaximize = new RelayCommand(o => MaximizeWindow(o));
            CommandClose = new RelayCommand(o => CloseWindow(o));
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
