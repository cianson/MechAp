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
        //variables
        CurrentUser loggedIn;

        //Constructors
        public ProfilePage()
        {
            InitializeComponent();
           // BindingContext = this;
        }
        public ProfilePage(CurrentUser loggedIn)
        {
            InitializeComponent();

            // BindingContext = this;
            this.loggedIn = loggedIn;

            ProfileTitle.Text = loggedIn.Username;
        }

        //Navigation buttons
        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new WelcomePage();
        }

        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }

        private void UpdateProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileUpdate(loggedIn);
        }

        private void DeleteProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileDelete(loggedIn);
        }

        //public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}