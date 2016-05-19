using Pasta.Properties;
using PastaLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pasta
{
    public partial class MainForm : Form
    {
        private System.Media.SoundPlayer _player;
        private bool api_locked = true;

        private Pastebin Pastebin { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Pastebin = new Pastebin(Settings.Default.API_key);
            _player = new System.Media.SoundPlayer(@"Sounds\confirm.wav");
        }
        
        private async void Paste()
        {
            string code = Clipboard.GetText();
            string response = "";

            await Task.Run(() =>
            {
                Pastebin.Paste(code, string.Format("paste_{0}", DateTime.Now.ToString("ddMMyyyy_HHmmss")), PasteMode.Unlisted);
                response = Pastebin.LastResponse;
            });

            Clipboard.SetText(response);
            txtLastResponse.Text = response;
            _player.Play();
        }

        #region Event Handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtApiKey.Text = Settings.Default.API_key;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (txtApiKey.Text != "")
            {
                Settings.Default.API_key = txtApiKey.Text;
                Settings.Default.Save();
            }
        }

        private void txtApiKey_TextChanged(object sender, EventArgs e)
        {
            Pastebin.ApiKey = txtApiKey.Text;
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void btnToggleLock_Click(object sender, EventArgs e)
        {
            if (api_locked)
            {
                txtApiKey.Enabled = true;
                api_locked = false;
                btnToggleLock.BackgroundImage = Resources.unlocked;
            }
            else
            {
                txtApiKey.Enabled = false;
                api_locked = true;
                btnToggleLock.BackgroundImage = Resources.locked;
            }
        }

        private void btnPaste_MouseEnter(object sender, EventArgs e)
        {
            toolTip.Show("Clipboard content:\n" + Clipboard.GetText(), btnPaste);
        }
        #endregion
        
    }
}
