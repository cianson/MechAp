using SQLite;
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
        User userLoggedIn;
        public string usernameLoggedIn = string.Empty;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameLoggedIn = loggedIn.Username;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<User>();
                userLoggedIn = conn.FindWithQuery<User>("SELECT * FROM [User] WHERE Username = ?", usernameLoggedIn);
            }

            usernameDisplay.Text = userLoggedIn.Username;
            firstNameDisplay.Text = userLoggedIn.FirstName;
            lastNameDisplay.Text = userLoggedIn.LastName;
            emailDisplay.Text = userLoggedIn.Email;

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
            App.Current.MainPage = new ProfileUpdate(loggedIn, userLoggedIn);
        }

        private void DeleteProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfileDelete(loggedIn);
        }

        //public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
    }
}
