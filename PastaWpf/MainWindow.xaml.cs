using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PastaLib;
using Pasta.Properties;
using Pasta.WinApi;

namespace Pasta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HotKey _hotkey;
        private System.Media.SoundPlayer _player;

        private const string SOUND_CONFIRM = @"Sounds\confirm.wav";
        private const string SOUND_ERROR = @"Sounds\error.wav";

        public Pastebin Pastebin { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Pastebin = new Pastebin(Settings.Default.API_key, Settings.Default.User_key, Settings.Default.Format, Settings.Default.Expiration, (PasteMode)Settings.Default.Paste_mode);
            DataContext = Pastebin;

            // Register global hotkey Ctrl+ALt+C
            Loaded += (s, e) =>
            {
                _hotkey = new HotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.C, this);
                _hotkey.HotKeyPressed += (k) => Paste();
            };
        }

        private void Paste()
        {
            if (Pastebin.Paste(Clipboard.GetText(), string.Format("paste_{0}", DateTime.Now.ToString("ddMMyyyy_HHmmss"))))
            {
                Clipboard.SetText(Pastebin.LastResponse);

                _player.SoundLocation = SOUND_CONFIRM;
                _player.Play();
            }
            else
            {
                _player.SoundLocation = SOUND_ERROR;
                _player.Play();
            }
        }

        #region Event Handlers
        private void MainForm_Loaded(object sender, RoutedEventArgs e)
        {
            _player = new System.Media.SoundPlayer();
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {
            if (Pastebin.ApiKey != "")
            {
                Settings.Default.API_key = Pastebin.ApiKey;
                Settings.Default.User_key = Pastebin.UserKey;
                Settings.Default.Format = Pastebin.Format;
                Settings.Default.Expiration = Pastebin.Expiration;
                Settings.Default.Paste_mode = (int)Pastebin.PasteMode;
                Settings.Default.Save();
            }
        }

        private void btnToggleLock_Click(object sender, RoutedEventArgs e)
        {
            Pastebin.ApiKeyLocked = !Pastebin.ApiKeyLocked;
        }

        private void btnAuthenticate_Click(object sender, RoutedEventArgs e)
        {
            if (Pastebin.Login(Pastebin.UserName, txtPassword.Password))
            {
                txtPassword.Password = "";
                _player.SoundLocation = SOUND_CONFIRM;
                _player.Play();
            }
            else
            {
                _player.SoundLocation = SOUND_ERROR;
                _player.Play();
            }
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
            Paste();
        }

        private void linkAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/TomasBouda/Pasta");
        }
        #endregion  
    }
}
