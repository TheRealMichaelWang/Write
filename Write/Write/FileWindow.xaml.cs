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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Write
{
    /// <summary>
    /// Interaction logic for FileWindow.xaml
    /// </summary>
    public partial class FileWindow : Window
    {
        public RichTextBoxPrintCtrl control;
        public FileInfo document;
        System.Windows.Controls.RichTextBox text;
        public FileWindow(FileInfo doc, System.Windows.Controls.RichTextBox text)
        {
            InitializeComponent();
            document = null;
            this.WindowState = WindowState.Maximized;
            this.Closing += FileWindow_Closing;
            GetInfo();
            OpenOutput.Text = "Open A File";
            document = doc;
            this.text = text;
            control = new RichTextBoxPrintCtrl();
            Save();
            DocumentViewer.Navigate(Environment.CurrentDirectory + "\\index.html");
        }

        private void FileWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel=true;
            this.Hide();
        }

        public void Resize()
        {
            tabControl.Height = this.ActualHeight;
            tabControl.Width = this.ActualWidth;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Resize();
        }
        public void GetInfo()
        {
            if(document==null)
            {
                Information.Text = "Open or SaveAs a document first";
            }
            else
            {
                Information.Text = "Information\r\nDocumentName: "+document.Name+"\r\nFilePath: "+document.FullName+
                    "\r\nLast Modified: "+document.LastWriteTime+"\r\nLastOpened: "+document.LastAccessTime+"\r\nSize: "
                    +document.Length+"\r\nCreationTime: "+document.CreationTime;
            }
            Information.Text += "\r\nClose this dialog to return";
        }
        public void Open()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open A file";
            dialog.DefaultExt = ".rtf";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenOutput.Text = "File Opened: " + dialog.FileName;
                document = new FileInfo(dialog.FileName);
                this.Close();
            }
            else
            {
                OpenOutput.Text = "Please open a file";
            }
        }
        public void Save()
        {
            if (document != null)
            {
                TextRange range = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                MemoryStream m = new MemoryStream();
                range.Save(m, System.Windows.DataFormats.Rtf);
                File.WriteAllBytes(document.FullName, m.ToArray());
                SaveOutput.Text = "Saved!";
                this.Close();
            }
        }
        public void SaveAs()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Create(dialog.FileName).Close();
                document = new FileInfo(dialog.FileName);
                Save();
            }
            else
            {
                SaveAsOutput.Text = "Select a file!";
            }
        }
        public void PrintDoc()
        {
            System.Windows.Forms.PrintDialog dialog = new System.Windows.Forms.PrintDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (dialog.PrinterSettings.PrintToFile == false)
                {
                    control.PrintDocument(dialog.PrinterSettings, text);
                    this.Close();
                }
                else
                {

                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Printing was canceled");
            }
        }
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                GetInfo();
            }
            if (tabControl.SelectedIndex == 2)
            {
                Open();
            }
            if(tabControl.SelectedIndex == 3)
            {
                Save();
            }
            if(tabControl.SelectedIndex == 4)
            {
                SaveAs();
            }
            if(tabControl.SelectedIndex == 5)
            {
                PrintDoc();
            }
        }
    }
}
