using System;
using System.Collections.Generic;
using System.IO;
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

namespace Write
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpellChecker checker;
        Vocabulary vocab;
        public FileInfo document;
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            FontSizeInput.LostFocus += FontSizeInput_LostFocus;
            FontNameInput.LostFocus += FontNameInput_LostFocus;
            LineHeightInput.LostFocus += LineHeightInput_LostFocus;
            DictionaryInput.LostFocus += DictionaryInput_LostFocus;
            Text.SelectionChanged += Text_SelectionChanged;
            Text.IsReadOnly = false;
            Text.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
            Text.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            this.Title = "Write -Untitled Document";
            this.SpellCheckOutput.TextWrapping = TextWrapping.NoWrap;
        }

        private void DictionaryInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if(checker.language != (string)DictionaryInput.SelectedValue)
            checker = new SpellChecker((string)DictionaryInput.SelectedValue);
        }

        public void InitializeSpell()
        {
            DictionaryInput.Items.Add("english");
            DictionaryInput.Items.Add("english(advanced)");
            DictionaryInput.Items.Add("english(extreme)");
            DictionaryInput.Items.Add("spanish");
            DictionaryInput.SelectedValue = "english";
            checker = new SpellChecker("english");
            SpellCheckOutput.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
        private void Text_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Update();   
        }

        private void LineHeightInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if(LineHeightInput.SelectedValue.ToString()=="Default Spacing")
            {
                Text.SetValue(Paragraph.LineHeightProperty, (double)2.0);
            }
            else
            {
                Text.SetValue(Paragraph.LineHeightProperty, (double)LineHeightInput.SelectedValue);
            }
        }

        private void FontNameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            string x = Text.Selection.Text;
            x.Replace("\r\n", "");
            x.Replace("\n", "");
            if (x!="")
            {
                Text.Selection.ApplyPropertyValue(RichTextBox.FontFamilyProperty, (string)FontNameInput.SelectedValue);
            }
            else
            {
                Text.FontFamily = new FontFamily((string)FontNameInput.SelectedValue);
            }
        }

        private void FontSizeInput_LostFocus(object sender, RoutedEventArgs e)
        {
            string x = Text.Selection.Text;
            x.Replace("\r\n", "");
            x.Replace("\n", "");
            if (x!="")
            {
                Text.Selection.ApplyPropertyValue(FontSizeProperty,FontSizeInput.SelectedValue.ToString());
            }
            else
            {
                Text.FontSize = (int)FontSizeInput.SelectedValue;
            }
        }
        private void AlignmentInput_LostFocus(object sender, RoutedEventArgs e)
        {
            string x = Text.Selection.Text;
            x.Replace("\r\n", "");
            x.Replace("\n", "");
            if(x!="")
            {
                Text.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, AlignmentInput.SelectedValue);
            }
            else
            {
                Text.SetValue(Paragraph.TextAlignmentProperty, AlignmentInput.SelectedValue);
            }
        }
        public void InitializeVocab()
        {
            vocab = new Vocabulary("bio7");
            VocabBookSelection.Items.Add("bio7");
            VocabBookSelection.Items.Add("CalloftheWild");
            VocabBookSelection.SelectedValue = "bio7";
        }
        public void InitializeFont()
        {
            int i = 8;
            double add = 0.1;
            while(i<200)
            {
                if (!FontSizeInput.Items.Contains(i))
                {
                    FontSizeInput.Items.Add(i);
                }
                i = i + (int)add;
                add = add + 0.1;
            }
            FontSizeInput.SelectedValue = 12;
            FontFamily[] fonts = Fonts.SystemFontFamilies.ToArray();
          
            for(int x = 0; x <fonts.Length;x++)
            {
                FontNameInput.Items.Add(fonts[x].Source);
            }
            FontNameInput.SelectedValue = "Times New Roman";
            LineHeightInput.Items.Add(1.0);
            LineHeightInput.Items.Add(1.5);
            LineHeightInput.Items.Add(2.0);
            LineHeightInput.Items.Add("Default Spacing");
            LineHeightInput.SelectedValue = "Default Spacing";
            AlignmentInput.Items.Add(TextAlignment.Center);
            AlignmentInput.Items.Add(TextAlignment.Left);
            AlignmentInput.Items.Add(TextAlignment.Right);
            AlignmentInput.SelectedValue = TextAlignment.Left;
            Text.FontFamily = new FontFamily("Times New Roman");
            Text.FontSize = 12;
            Text.SetValue(Paragraph.LineHeightProperty, 2.0);
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            tabControl.Width = e.NewSize.Width - 95;
            SpellCheckOutput.Width = tabControl.Width - 20;
            Text.Height = e.NewSize.Height-85;
            Text.Width = e.NewSize.Width;
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            string s = Text.Selection.Text;
            s.Replace("\r\n", "");
            s.Replace("\r\n", "");
            if (s != "")
            {
                if (Text.Selection.GetPropertyValue(RichTextBox.FontWeightProperty).Equals(FontWeights.Bold) == false)
                {
                    BoldButton.Background = Brushes.Orange;
                    Text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Bold);
                }
                else
                {
                    BoldButton.Background = Brushes.LightGray;
                    Text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, FontWeights.Normal);
                }
            }
            else
            {
                if(Text.FontWeight == FontWeights.Bold)
                {
                    BoldButton.Background = Brushes.LightGray;
                    Text.FontWeight = FontWeights.Normal;
                }
                else
                {
                    BoldButton.Background = Brushes.Orange;
                    Text.FontWeight = FontWeights.Bold;
                }
            }
        }

        private void ItialicsButton_Click(object sender, RoutedEventArgs e)
        {
            string s = Text.Selection.Text;
            s.Replace("\r\n", "");
            s.Replace("\r\n", "");
            if (s != "")
            {
                if (Text.Selection.GetPropertyValue(RichTextBox.FontStyleProperty).Equals(FontStyles.Italic) == false)
                {
                    ItalicsButton.Background = Brushes.Orange;
                    Text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Italic);
                }
                else
                {
                    ItalicsButton.Background = Brushes.LightGray;
                    Text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, FontStyles.Normal);
                }
            }
            else
            {
                if (Text.FontStyle == FontStyles.Italic)
                {
                    ItalicsButton.Background = Brushes.LightGray;
                    Text.FontStyle = FontStyles.Normal;
                }
                else
                {
                    ItalicsButton.Background = Brushes.Orange;
                    Text.FontStyle = FontStyles.Italic;
                }
            }
        }

        private void UnderLineButton_Click(object sender, RoutedEventArgs e)
        {
            string s = Text.Selection.Text;
            s.Replace("\r\n", "");
            s.Replace("\r\n", "");
            if (s != "")
            {
                if (Text.Selection.GetPropertyValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline) == false)
                {
                    UnderLineButton.Background = Brushes.Orange;
                    Text.Selection.ApplyPropertyValue(Underline.TextDecorationsProperty,TextDecorations.Underline);

                }
                else
                {
                    UnderLineButton.Background = Brushes.LightGray;
                    Text.Selection.ApplyPropertyValue(Underline.TextDecorationsProperty,null);
                }
            }
            else
            {
                if (Text.GetValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline))
                {
                    UnderLineButton.Background = Brushes.LightGray;
                    Text.SetValue(Underline.TextDecorationsProperty, null);
                }
                else
                {
                    UnderLineButton.Background = Brushes.Orange;
                    Text.SetValue(Underline.TextDecorationsProperty, TextDecorations.Underline);
                }
            }
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        public void Update()
        {
            try
            {
                string x = Text.Selection.Text;
                x.Replace("\r\n", "");
                x.Replace("\n", "");
                if (x != "")
                {
                    if (Text.Selection.GetPropertyValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline))
                    {
                        UnderLineButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        UnderLineButton.Background = Brushes.LightGray;
                    }
                    if (Text.Selection.GetPropertyValue(RichTextBox.FontWeightProperty).Equals(FontWeights.Bold))
                    {
                        BoldButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        BoldButton.Background = Brushes.LightGray;
                    }
                    if (Text.Selection.GetPropertyValue(RichTextBox.FontStyleProperty).Equals(FontStyles.Italic))
                    {
                        ItalicsButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        ItalicsButton.Background = Brushes.LightGray;
                    }
                    var a = Text.Selection.GetPropertyValue(RichTextBox.FontSizeProperty);
                    FontFamily b = (FontFamily)Text.Selection.GetPropertyValue(RichTextBox.FontFamilyProperty);
                    FontSizeInput.SelectedValue = int.Parse(a.ToString());
                    FontNameInput.SelectedValue = b.Source;
                    AlignmentInput.SelectedValue = Text.Selection.GetPropertyValue(Paragraph.TextAlignmentProperty);
                }
                else
                {
                    if (Text.FontWeight == FontWeights.Bold)
                    {
                        BoldButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        BoldButton.Background = Brushes.LightGray;
                    }
                    if (Text.FontStyle == FontStyles.Italic)
                    {
                        ItalicsButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        ItalicsButton.Background = Brushes.LightGray;
                    }
                    if (Text.GetValue(Underline.TextDecorationsProperty).Equals(TextDecorations.Underline))
                    {
                        UnderLineButton.Background = Brushes.Orange;
                    }
                    else
                    {
                        UnderLineButton.Background = Brushes.LightGray;
                    }
                    LineHeightInput.SelectedValue = Text.GetValue(Paragraph.LineHeightProperty);
                    var a = Text.FontSize;
                    var b = Text.FontFamily.Source;
                    FontSizeInput.SelectedValue = (int)a;
                    FontNameInput.SelectedValue = b;
                    AlignmentInput.SelectedValue = Text.GetValue(Paragraph.TextAlignmentProperty);
                }
            }
            catch (Exception)
            {

            }

            }

        private void SpellCheckButton_Click(object sender, RoutedEventArgs e)
        {
            string s = Text.Selection.Text;
            s.Replace("\r\n", "");
            s.Replace("\n", "");
            if(s!="")
            {
                SpellCheckOutput.Text = checker.Correct(s);
            }
            else
            {
                Text.SelectAll();
                SpellCheckOutput.Text = checker.Correct(Text.Selection.Text);
            }
        }

        private void AddToDictionary_Click(object sender, RoutedEventArgs e)
        {
            string s = Text.Selection.Text;
            s.Replace("\r\n", "");
            s.Replace("\n", "");
            if (s != "")
            {
                checker.Add(checker.ProcessWord(s));
            }
            else
            {
                MessageBox.Show("Select some word");
            }
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            FileWindow file;
            this.Hide();
            file = new FileWindow(document,Text);
            file.ShowDialog();
            this.Show();
            document = file.document;
            Text.SelectAll();
            if (file.document != null)
            {
                try
                {
                    string loaded = File.ReadAllText(document.FullName);
                    MemoryStream stream = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(loaded));
                    Text.Selection.Load(stream, DataFormats.Rtf);
                    this.Title = "Write -" + file.document.Name;
                }
                catch
                {
                    MessageBox.Show("Make sure to open an ASCII rich text box data formated file");
                    Text.Selection.Text = File.ReadAllText(document.FullName);
                }
            }
        }

        private void DoVocab(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(Text.Document.ContentStart, Text.Document.ContentEnd);
            string[] lines = range.Text.Split("\n".ToCharArray());
            range.Text = vocab.DefineAll(lines);
        }
        
        private void VocabBookSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vocab = new Vocabulary((string)VocabBookSelection.SelectedItem);
        }
    }
    }

