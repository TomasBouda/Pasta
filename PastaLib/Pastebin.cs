using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastaLib
{
    public enum PasteMode
    {
        Public,
        Unlisted,
        Private
    }

    public class Pastebin : INotifyPropertyChanged
    {
        public const string API_ENDPOINT = "http://pastebin.com/api/api_post.php";
        public const string PASTE_LOG_PATH = "pasta_history.txt";

        private string _apiKey;
        private bool _apiKeyLocked = true;
        private string _userKey;
        private string _expiration;
        private string _format;
        private string _lastResponse;
        private PasteMode _pasteMode = PasteMode.Unlisted;

        private string _userName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ApiKey
        {
            get { return _apiKey; }
            set
            {
                _apiKey = value;
                NotifyPropertyChanged(nameof(ApiKey));
                if (!string.IsNullOrEmpty(_apiKey))
                    ApiKeyLocked = true;
            }
        }

        public bool ApiKeyLocked
        {
            get { return _apiKeyLocked; }
            set
            {
                _apiKeyLocked = value;
                NotifyPropertyChanged(nameof(ApiKeyLocked));
            }
        }

        public string UserKey
        {
            get { return _userKey; }
            set
            {
                _userKey = value;
                NotifyPropertyChanged(nameof(UserKey));
            }
        }

        public string Expiration
        {
            get { return _expiration; }
            set
            {
                _expiration = value;
                NotifyPropertyChanged(nameof(Expiration));
            }
        }

        public string Format
        {
            get { return _format; }
            set
            {
                _format = value;
                NotifyPropertyChanged(nameof(Format));
            }
        }

        public string LastResponse
        {
            get { return _lastResponse; }
            set
            {
                _lastResponse = value;
                NotifyPropertyChanged(nameof(LastResponse));
            }
        }

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyPropertyChanged(nameof(UserName));
            }
        }

        public PasteMode PasteMode
        {
            get { return _pasteMode; }
            set
            {
                _pasteMode = value;
                NotifyPropertyChanged(nameof(PasteMode));
            }
        }

        public IEnumerable<PasteMode> PasteModes
        {
            get
            {
                return Enum.GetValues(typeof(PasteMode)).Cast<PasteMode>();
            }
        }

        public Pastebin(string apiKey, string userKey, string format, string expiration, PasteMode pasteMode)
        {
            ApiKey = apiKey;
            UserKey = userKey;
            Format = format;
            Expiration = expiration;
            PasteMode = pasteMode;
        }

        public Pastebin(string apiKey, string userKey = null)
        {
            ApiKey = apiKey;
            UserKey = userKey;
        }

        public Pastebin() { }

        public bool Paste(string text, string pasteName)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(API_ENDPOINT);
            
            RestRequest request = new RestRequest();
            request.Method = Method.POST;

            request.AddParameter("api_option", "paste");
            request.AddParameter("api_dev_key", ApiKey);
            request.AddParameter("api_user_key", UserKey);
            request.AddParameter("api_paste_code", text);
            request.AddParameter("api_paste_private", (int)PasteMode);
            request.AddParameter("api_paste_name", pasteName);
            request.AddParameter("api_paste_expire_date", Expiration);
            request.AddParameter("api_paste_format", Format);

            var response = client.Execute(request);
            bool result = !response.Content.Contains("Bad");

            LastResponse = response.Content;

            // Save paste url to file
            if (result)
                File.AppendAllText(PASTE_LOG_PATH, LastResponse + Environment.NewLine);

            return !response.Content.Contains("Bad");
        }

        public bool Login(string username, string password)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("http://pastebin.com/api/api_login.php");

            RestRequest request = new RestRequest();
            request.Method = Method.POST;

            request.AddParameter("api_dev_key", ApiKey);
            request.AddParameter("api_user_name", username);
            request.AddParameter("api_user_password", password);

            var response = client.Execute(request);

            bool result = !response.Content.Contains("Bad");
            if(result)
                UserKey = response.Content;

            return result;
        }

        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
