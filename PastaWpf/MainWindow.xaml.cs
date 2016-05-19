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
using PastaLib;
using PastaWpf.Properties;

namespace PastaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Media.SoundPlayer _player;

        public Pastebin Pastebin { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Pastebin = new Pastebin(Settings.Default.API_key, Settings.Default.User_key, Settings.Default.Format, Settings.Default.Expiration);
            DataContext = Pastebin;
            _player = new System.Media.SoundPlayer();
        }

        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            if (Pastebin.ApiKey != "")
            {
                Settings.Default.API_key = Pastebin.ApiKey;
                Settings.Default.User_key = Pastebin.UserKey;
                Settings.Default.Format = Pastebin.Format;
                Settings.Default.Expiration = Pastebin.Expiration;
                Settings.Default.Save();
            }
        }

        private void btnToggleLock_Click(object sender, RoutedEventArgs e)
        {
            Pastebin.ApiKeyLocked = !Pastebin.ApiKeyLocked;
        }

        private void btnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            if (Pastebin.Login(Pastebin.UserName, Pastebin.Password))
            {
                _player.SoundLocation = @"Sounds\confirm.wav";
                _player.Play();
            }
            else
            {
                _player.SoundLocation = @"Sounds\error.wav";
                _player.Play();
            }
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            if(Pastebin.Paste(Clipboard.GetText(), string.Format("paste_{0}", DateTime.Now.ToString("ddMMyyyy_HHmmss"))))
            {
                Clipboard.SetText(Pastebin.LastResponse);

                _player.SoundLocation = @"Sounds\confirm.wav";
                _player.Play();
            }
            else
            {
                _player.SoundLocation = @"Sounds\error.wav";
                _player.Play();
            }
        }
    }
}
