using DnDCharacterSheetTool.Classes.DataModel;
using DnDCharacterSheetTool.GUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDCharacterSheetTool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string sProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(sProperty));
        }

        private ObservableCollection<Character> characters;
        public ObservableCollection<Character> Characters
        {
            get { return characters; }
            set { characters = value; OnPropertyChanged(nameof(Characters)); }
        }

        private Character activeCharacter;
        public Character ActiveCharacter
        {
            get { return activeCharacter; }
            set { activeCharacter = value; OnPropertyChanged(nameof(ActiveCharacter)); }
        }


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new pgCharacterSheet());
        }
    }
}
