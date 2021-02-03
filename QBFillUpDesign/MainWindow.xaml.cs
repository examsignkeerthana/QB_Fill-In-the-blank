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
        string ans1Type = "";
        string ans2Type = "";
        string ans = "";
        int pos = 1;

        string quesType = "Fill Up";
        string Ques = "";
        string Qimgpath = "";

        ObservableCollection<string> OCAltAns1 = new ObservableCollection<string>();
        ObservableCollection<string> OCAns1 = new ObservableCollection<string>();

        ObservableCollection<string> OCAltAns2 = new ObservableCollection<string>();
        ObservableCollection<string> OCAns2 = new ObservableCollection<string>();

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

        private void btnImgPathRemove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = path.IndexOf(p);

            path.RemoveAt(index);
        }

        private void btnAns1Remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = OCAns1.IndexOf(p);

            OCAns1.RemoveAt(index);
        }

        private void btnAltAns1Remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = OCAltAns1.IndexOf(p);

            OCAltAns1.RemoveAt(index);
        }

        private void btnAns2Remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = OCAns2.IndexOf(p);

            OCAns2.RemoveAt(index);
        }

        private void btnAltAns2Remove_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string p = button.DataContext as string;
            int index = OCAltAns2.IndexOf(p);

            OCAltAns2.RemoveAt(index);
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
            
            ans1Type = "Integer";
            stkpnlAns1Fraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";
            txtboxAns1.Focus();

            stkpnlAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;

            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1Float_Checked(object sender, RoutedEventArgs e)
        {
            ans1Type = "Float";
            stkpnlAns1Fraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";
            txtboxAns1.Focus();

            stkpnlAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;

            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1String_Checked(object sender, RoutedEventArgs e)
        {
            ans1Type = "String";
            stkpnlAns1Fraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";
            txtboxAns1.Focus();

            stkpnlAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;


            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1Fraction_Checked(object sender, RoutedEventArgs e)
        {
            ans1Type = "Fraction";
            txtboxAns1.Text = "";
            txtboxAns1.Focus();

            rdiobtnAns1FormatAB.IsChecked = false;
            rdiobtnAns1FormatABC.IsChecked = false;
            stkpnlAns1Fraction.Visibility = Visibility.Visible;

        }


        private void rdiobtnAns1FormatAB_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatABC.Visibility = Visibility.Collapsed;

            stkpnlAns1FractFormatAB.Visibility = Visibility.Visible;
            txtbxAns1AB_A.Focus();

            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Collapsed;

            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns1FormatABC_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatAB.Visibility = Visibility.Collapsed;

            stkpnlAns1FractFormatABC.Visibility = Visibility.Visible;
            txtbxAns1ABC_A.Focus();

            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Collapsed;

            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Visible;
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
                ans1Type = "Integer";
                newText = IntAnswer(ch);
            }
            else if (rdiobtnAns1Float.IsChecked == true)
            {
                ans1Type = "Float";
                newText = DecimalAnswer(ch);
            }
            else if (rdiobtnAns1String.IsChecked == true)
            {
                ans1Type = "String";
                foreach (char c in ch)
                {
                    newText += c;
                }
            }
            else if (rdiobtnAns1Fraction.IsChecked == true)
            {
                ans1Type = "Fraction";
                MessageBox.Show("Select SubType of Fraction");
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
                    txtblkAns1ErrMsg.Visibility = Visibility.Visible;
                    txtblkAns1ErrMsg.Text = "Enter only Digits";
                }
                if (count == 1)
                { pre += 1; }
            }
            return newText;
        }

        private void ReadIntegerValue(TextBox textBox)
        {
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            char[] ch = textBox.Text.ToCharArray();

            newText = IntAnswer(ch);

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

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
                    txtblkAns1ErrMsg.Visibility = Visibility.Visible;
                    txtblkAns1ErrMsg.Text = "Enter only Digits";
                }

            }
            return newText;
        }

        private void txtbxAns1AB_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns1AB_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns1ABC_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns1ABC_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns1ABC_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void btnAddAns1_Click(object sender, RoutedEventArgs e)
        {
            OCAns1.Add(txtboxAns1.Text);
            lstboxAns1.ItemsSource = OCAns1;
            txtboxAns1.Text = "";
            txtboxAns1.Focus();
        }

        private void txtboxAltAns1_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            //int count = 0;
            char[] ch = textBox.Text.ToCharArray();

            if (rdiobtnAns1Integer.IsChecked == true)
            {
                newText = IntAnswer(ch);
            }
            else if (rdiobtnAns1Float.IsChecked == true)
            {
                newText = DecimalAnswer(ch);
            }
            else if (rdiobtnAns1String.IsChecked == true)
            {
                foreach (char c in ch)
                {
                    newText += c;
                }
            }
            //else if (rdiobtnAns1Fraction.IsChecked == true)
            //{
            //    MessageBox.Show("Select Fraction Type");
            //}

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }

        private void btnAddAltAns1_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty( txtboxAltAns1.Text ))
            {
                OCAltAns1.Add(txtboxAltAns1.Text);
                lstboxAltAns1.ItemsSource = OCAltAns1;
            }
            
            txtboxAltAns1.Text = "";
            txtboxAltAns1.Focus();
        }

        private void txtbxAltAns1AB_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns1AB_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns1ABC_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns1ABC_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns1ABC_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void rdiobtnAns2Integer_Checked(object sender, RoutedEventArgs e)
        {
            ans2Type = "Integer";
            stkpnlAns2Fraction.Visibility = Visibility.Collapsed;
            txtboxAns2.Text = "";
            txtboxAns2.Focus();

            stkpnlAns2FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns2FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns2TxtbxBtn.Visibility = Visibility.Visible;

            stkpnlAltAns2FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns2FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns2TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns2Float_Checked(object sender, RoutedEventArgs e)
        {
            ans2Type = "Float";
            stkpnlAns2Fraction.Visibility = Visibility.Collapsed;
            txtboxAns2.Text = "";
            txtboxAns2.Focus();

            stkpnlAns2FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns2FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns2TxtbxBtn.Visibility = Visibility.Visible;

            stkpnlAltAns2FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns2FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns2TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns2String_Checked(object sender, RoutedEventArgs e)
        {
            ans1Type = "String";
            stkpnlAns1Fraction.Visibility = Visibility.Collapsed;
            txtboxAns1.Text = "";
            txtboxAns1.Focus();

            stkpnlAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAns1TxtbxBtn.Visibility = Visibility.Visible;


            stkpnlAltAns1FractFormatAB.Visibility = Visibility.Collapsed;
            stkpnlAltAns1FractFormatABC.Visibility = Visibility.Collapsed;
            stkpnlAltAns1TxtbxBtn.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns2Fraction_Checked(object sender, RoutedEventArgs e)
        {
            ans1Type = "Fraction";
            txtboxAns2.Text = "";
            txtboxAns2.Focus();

            rdiobtnAns2FormatAB.IsChecked = false;
            rdiobtnAns2FormatABC.IsChecked = false;
            stkpnlAns2Fraction.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns2FormatAB_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns2TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAns2FractFormatABC.Visibility = Visibility.Collapsed;

            stkpnlAns2FractFormatAB.Visibility = Visibility.Visible;
            txtbxAns2AB_A.Focus();

            stkpnlAltAns2TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAltAns2FractFormatABC.Visibility = Visibility.Collapsed;

            stkpnlAltAns2FractFormatAB.Visibility = Visibility.Visible;
        }

        private void rdiobtnAns2FormatABC_Checked(object sender, RoutedEventArgs e)
        {
            stkpnlAns2TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAns2FractFormatAB.Visibility = Visibility.Collapsed;

            stkpnlAns2FractFormatABC.Visibility = Visibility.Visible;
            txtbxAns2ABC_A.Focus();

            stkpnlAltAns2TxtbxBtn.Visibility = Visibility.Collapsed;
            stkpnlAltAns2FractFormatAB.Visibility = Visibility.Collapsed;

            stkpnlAltAns2FractFormatABC.Visibility = Visibility.Visible;
        }

        private void txtboxAns2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            //int count = 0;
            char[] ch = textBox.Text.ToCharArray();

            if (rdiobtnAns2Integer.IsChecked == true)
            {
                ans2Type = "Integer";
                newText = IntAnswer(ch);
            }
            else if (rdiobtnAns2Float.IsChecked == true)
            {
                ans2Type = "Float";
                newText = DecimalAnswer(ch);
            }
            else if (rdiobtnAns2String.IsChecked == true)
            {
                ans2Type = "String";
                foreach (char c in ch)
                {
                    newText += c;
                }
            }
            else if (rdiobtnAns2Fraction.IsChecked == true)
            {
                ans2Type = "Fraction";
                MessageBox.Show("Select SubType of Fraction");
            }


            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;

        }

        private void btnAddAns2_Click(object sender, RoutedEventArgs e)
        {
            OCAns2.Add(txtboxAns2.Text);
            lstboxAns2.ItemsSource = OCAns2;
            txtboxAns2.Text = "";
            txtboxAns2.Focus();
        }

        private void txtbxAns2AB_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns2AB_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns2ABC_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns2ABC_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAns2ABC_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtboxAltAns2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            //int count = 0;
            char[] ch = textBox.Text.ToCharArray();

            if (rdiobtnAns2Integer.IsChecked == true)
            {
                newText = IntAnswer(ch);
            }
            else if (rdiobtnAns2Float.IsChecked == true)
            {
                newText = DecimalAnswer(ch);
            }
            else if (rdiobtnAns2String.IsChecked == true)
            {
                foreach (char c in ch)
                {
                    newText += c;
                }
            }
            //else if (rdiobtnAns1Fraction.IsChecked == true)
            //{
            //    MessageBox.Show("Select Fraction Type");
            //}

            textBox.Text = newText;
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
        }

        private void btnAddAltAns2_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtboxAltAns2.Text))
            {
                OCAltAns2.Add(txtboxAltAns2.Text);
                lstboxAltAns2.ItemsSource = OCAltAns2;
            }

            txtboxAltAns2.Text = "";
            txtboxAltAns2.Focus();
        }

        private void txtbxAltAns2AB_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns2AB_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns2ABC_A_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns2ABC_B_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        private void txtbxAltAns2ABC_c_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ReadIntegerValue(textBox);
        }

        
    }
}
