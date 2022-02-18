using System.ComponentModel;

namespace MechAp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string username = string.Empty;
        public string carName = string.Empty;

        public string Username
        {
            get { return Username; }
            set
            {
                username = value;

                OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(DisplayUsernameInGarage));
            }
        }

        public string DisplayUsernameInGarage
        {
            get { return "{Username}'s Garage"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string username)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(username));
        }

        public string CarName
        {
            get => carName;
            set
            {
                if (carName == value)
                    return;
                carName = value;
                OnPropertyChanged(nameof(CarName));
                OnPropertyChanged(nameof(DisplayCarName));
            }
        }

        public string DisplayCarName => $"{CarName}";
    }
}
