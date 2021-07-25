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
using System.Windows.Shapes;

namespace DnDCharacterSheetTool.GUI
{
    /// <summary>
    /// Interaktionslogik für frmNewCharacter.xaml
    /// </summary>
    public partial class frmNewCharacter : Window
    {
        public frmNewCharacter()
        {
            InitializeComponent();
        }



        #region Test
        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(ellipse, ellipse.Fill.ToString(), DragDropEffects.Copy);
            }
        }

        private void ellipse_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //Leave Empty
        }

        private Brush _previousFill = null;
        private void ellipse_DragEnter(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
                _previousFill = ellipse.Fill;

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, convert it.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }

        private void ellipse_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, allow copying.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
                }
            }
        }

        private void ellipse_DragLeave(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                ellipse.Fill = _previousFill;
            }
        }

        private void ellipse_Drop(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush,
                    // convert it and apply it to the ellipse.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }
        #endregion

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(int.TryParse(textBox.Text, out int i))
            {
                int mod = (i - 10) / 2;
                switch (textBox.Tag)
                {
                    case "STR":
                        lblSTR.Content = mod.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ListViewItem_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem viewItem = sender as ListViewItem;
            if(viewItem != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(viewItem, viewItem.Content, DragDropEffects.Copy);
            }
        }

        string prevValue = null;
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if(textBox != null)
            {
                prevValue = textBox.Text;

                if(e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    textBox.Text = (string)e.Data.GetData(DataFormats.StringFormat);
                }
            }
        }

        private void TextBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
