using System;
using System.Collections.Generic;
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

namespace CharacterCreator.Classes.CharacterSheet
{
    /// <summary>
    /// Interaktionslogik für CharacterSheet.xaml
    /// </summary>
    public partial class CharacterSheetView : Page
    {
        public CharacterSheetView()
        {
            InitializeComponent();
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            (this.DataContext as CharacterSheetViewModel)?.LoadCharacterPicture();
        }
    }
}
