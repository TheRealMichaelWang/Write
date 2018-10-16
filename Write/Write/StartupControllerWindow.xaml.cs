using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Write
{
    /// <summary>
    /// Interaction logic for StartupControllerWindow.xaml
    /// </summary>
    public partial class StartupControllerWindow : Window
    {
        MainWindow main;
        public StartupControllerWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.SizeChanged += StartupControllerWindow_SizeChanged;
            this.WindowStyle = WindowStyle.ThreeDBorderWindow;
            this.StartImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "/Images/start.bmp"));
            this.ResizeMode = ResizeMode.NoResize;
            this.KeyDown += StartupControllerWindow_KeyDown;
            this.Closing += StartupControllerWindow_Closing;
            main = new MainWindow();
            main.Closing += Main_Closing;
            main.Closed += End;
        }

        private void Main_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(main.document==null)
            {
                MessageBoxResult dr = MessageBox.Show("Do you want to save your document? Go to File> SaveAs", "Warning", MessageBoxButton.YesNo);
                if(dr == MessageBoxResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void End(object sender, EventArgs e)
        {
            MessageBoxResult dr = MessageBox.Show("Enter Bacground Mode?","",MessageBoxButton.YesNo);
            if (dr == MessageBoxResult.Yes)
            {
                EnterBackgroundMode();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        private void StartupControllerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void StartupControllerWindow_KeyDown(object sender, KeyEventArgs e)
        {
            Start();
            this.Hide();
            main.ShowDialog();
        }

        private void Start()
        {
            main.InitializeFont();
            main.InitializeSpell();
        }

        private void StartupControllerWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            StartImage.Width = e.NewSize.Width;
            StartImage.Height = e.NewSize.Height - 30;
        }
        public void EnterBackgroundMode()
        {
            main = new MainWindow();
            main.Closing += Main_Closing;
            main.Closed += End;
            Start();
            this.KeyDown += BackGroundModeKeyCheck;
        }

        private void BackGroundModeKeyCheck(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.O &&e.SystemKey == Key.LeftCtrl)
            {
                this.Show();
            }
        }
    }
}
