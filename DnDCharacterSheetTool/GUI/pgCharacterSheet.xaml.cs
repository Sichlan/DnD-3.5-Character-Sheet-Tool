using DnDCharacterSheetTool.Classes.DataModel;
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

namespace DnDCharacterSheetTool.GUI
{
    /// <summary>
    /// Interaktionslogik für CharacterSheet.xaml
    /// </summary>
    public partial class pgCharacterSheet : Page, INotifyPropertyChanged
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

        public pgCharacterSheet()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Characters = new ObservableCollection<Character>(DataLoader.Load<Character>("Character.json"));
        }

        private void btnNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            Character character = new Character();
            Characters.Add(character);
            ActiveCharacter = character;
            tbxName.Focus();
        }

        private void btnDeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.DeleteCharacterQuestion, Properties.Resources.Warning, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Character character = ActiveCharacter;
                Characters.Remove(character);
                ActiveCharacter = null;
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            frmNewCharacter frmNewCharacter = new frmNewCharacter();
            frmNewCharacter.ShowDialog();
        }
    }
}
