using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new WelcomePage();
        }

        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        private void UpdateProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileUpdate();
        }

        private void DeleteProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileDelete();
        }

        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}