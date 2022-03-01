using System.ComponentModel;

namespace MechAp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string username = string.Empty;
        public string Username
        {
            get => username;
            set 
            {
                if (username == value)
                    return;
                username = value;
                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(DisplayUsername));
            }
        }

        public string DisplayUsername => $"{Username} 's Garage";

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string username)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(username));
        }
    }
}
