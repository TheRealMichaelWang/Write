using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigureWrite
{
    public partial class Main : Form
    {
        public bool Installed=false;
        public string[] settings;
        public bool IsRunning=false;
        Process write=null;

        public Main()
        {
            InitializeComponent();
            GetState();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            InformationDisplay.ReadOnly = true;
            NameInput.Text = settings[1];
            PasswordInput.Text = settings[0];
        }

        public void GetState()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Write"))
            {
                Installed = false;
            }
            else
            {
                Installed = true;
                settings = File.ReadAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Write\\settings.dat");
            }
            try
            {
                write = Process.GetProcessesByName("Write")[0];
                IsRunning = true;
            }
            catch
            {
                IsRunning = false;
                write = null;
            }

            InformationDisplay.Text = "Running: "+IsRunning+"   Installed: "+Installed+"\r\n"
                +"Licensed to: "+settings[1]+"  Password: "+settings[0];
            if(Installed)
            {
                Update.Text = "Update";
            }
            else
            {
                Update.Text = "Install";
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetState();
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to apply these changes?","Warning",MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                try
                {
                    settings[0] = PasswordInput.Text;
                    settings[1] = NameInput.Text;
                    File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Write\\settings.dat", settings);
                }
                catch
                {
                    MessageBox.Show("Please run me as an administrator to apply these changes");
                }
           }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            byte[] data;
            
            try
            {
                InformationDisplay.Text = "Creating Temporary Dump..";
                File.Create(Environment.CurrentDirectory + "\\Update.exe").Close();
                InformationDisplay.Text = "Downloading...";
                data = client.DownloadData("https://raw.githubusercontent.com/TheRealMichaelWang/Write/master/WriteSetup.exe");
                File.WriteAllBytes(Environment.CurrentDirectory+"\\Update.exe",data);
                Process.Start(Environment.CurrentDirectory + "\\Update.exe");
                File.Delete(Environment.CurrentDirectory + "\\Update.exe");
                InformationDisplay.Text = "Finished";
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Website_Click(object sender, EventArgs e)
        {
            Process.Start("https://michaelwangssite/files/write");
        }
    }
}
