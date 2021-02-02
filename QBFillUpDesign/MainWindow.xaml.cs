using Microsoft.Win32;
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

using System.Collections.ObjectModel;

namespace QBFillUpDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hasMedia = 0;
        string ansType = "";
        string ans = "";
        int pos = 1;

        string quesType = "Fill Up";
        string Ques = "";
        string Qimgpath = "";

        ObservableCollection<string> Ans1 = new ObservableCollection<string>();
        ObservableCollection<string> path = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsertBlank_Click(object sender, RoutedEventArgs e)
        {
            txtboxQuestion.Text+= "\\rule{1cm}{0.15mm}";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtboxQuestion.Text = "";
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = path.IndexOf(p);

            path.RemoveAt(index);
            
        }

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            foreach (string s in BrowseMultipleImage())
            {
                path.Add(s);
            }
            
            lstboxImgPath.ItemsSource = path;
            
        }

        private List<string> BrowseMultipleImage()
        {
            List<string> fileName = new List<string>();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select one or more files";
            openFileDialog.ShowReadOnly = true;
            openFileDialog.Multiselect = true;
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                foreach (string s in openFileDialog.FileNames)
                    fileName.Add(s);
            }

            return fileName;
        }

        private string BrowseImagePath()
        {
            string fileName = "";
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                fileName = openFileDialog.FileName;
            }

            return fileName;
        }
        private void rdiobtnAns1Integer_Checked(object sender, RoutedEventArgs e)
        {
            ansType = "Integer";
            stkpnlFraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";

            stkpnlFractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlFractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1Float_Checked(object sender, RoutedEventArgs e)
        {
            ansType = "Float";
            stkpnlFraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";

            stkpnlFractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlFractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1String_Checked(object sender, RoutedEventArgs e)
        {
            ansType = "String";
            stkpnlFraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";

            stkpnlFractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlFractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1Fraction_Checked(object sender, RoutedEventArgs e)
        {
            ansType = "Fraction";
            txtboxAns1.Text = "";

            rdiobtnAns1FormatAB.IsChecked = false;
            rdiobtnAns1FormatABC.IsChecked = false;
            stkpnlFraction.Visibility = Visibility.Visible;
        }


        private void rdiobtnAns1FormatAB_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlFractFormatABC.Visibility = Visibility.Collapsed;

            stkpnlFractFormatAB.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1FormatABC_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlFractFormatAB.Visibility = Visibility.Collapsed;

            stkpnlFractFormatABC.Visibility = Visibility.Visible;
        }

        private void txtboxAns1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            //int count = 0;
            char[] ch = textBox.Text.ToCharArray();

            if (rdiobtnAns1Integer.IsChecked == true)
            {
                ansType = "Integer";
                newText = IntAnswer(ch);
            }
            else if (rdiobtnAns1Float.IsChecked == true)
            {
                ansType = "Float";
                newText = DecimalAnswer(ch);
            }
            else if (rdiobtnAns1String.IsChecked == true)
            {
                ansType = "String";
                foreach (char c in ch)
                {
                    newText += c;
                }
            }
            else if (rdiobtnAns1Fraction.IsChecked == true)
            {
                ansType = "Fraction";
            }


            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private string DecimalAnswer(char[] ch)
        {
            string newText = string.Empty;
            int count = 0;
            int pre = 0;

            //For Decimal value
            foreach (Char c in ch)
            {
                if ((Char.IsDigit(c) && pre <= 2) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;

                }
                else if (!char.IsDigit(c))
                {
                    txtblkErrMsg.Visibility = Visibility.Visible;
                    txtblkErrMsg.Text = "Enter only Digits";
                }
                if (count == 1)
                { pre += 1; }
            }
            return newText;
        }

        private string IntAnswer(char[] ch)
        {
            String newText = String.Empty;
            //Allow only digits

            foreach (Char c in ch)
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {
                    newText += c;

                }
                else
                {
                    txtblkErrMsg.Visibility = Visibility.Visible;
                    txtblkErrMsg.Text = "Enter only Digits";
                }

            }
            return newText;
        }

        private void txtbxAB_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void txtbxAB_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void txtbxABC_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void txtbxABC_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void txtbxABC_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void btnAddAns1_Click(object sender, RoutedEventArgs e)
        {
            Ans1.Add(txtboxAns1.Text);
            lstboxAns1.ItemsSource = Ans1;
        }
    }
}
