using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Windows.Input;
using SQLite;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {

        public WelcomePage()
        {
            InitializeComponent();
        }

        private void LoginPgBtn_Clicked(object sender, EventArgs e)
        {
            int rows = 0;

            CurrentUser loggedIn = new CurrentUser()
            {
                Number = 0,
                Username = "",
                FirstName = ""
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<CurrentUser>();
                    rows = conn.Insert(loggedIn);
                }
                catch (Exception)
                {
                    try
                    {
                        rows = conn.Update(loggedIn);
                    }
                    catch (Exception)
                    {
                        DisplayAlert("Oops!", "Something went wrong", "Try Again");
                        App.Current.MainPage = new WelcomePage();
                    }
                }
            }
            if (rows > 0)
            {
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                DisplayAlert("Failed", "NO!", "OK");
                App.Current.MainPage = new WelcomePage();
            }
        }

        private void RegistrationPgBtn_Clicked(object sender, EventArgs e)
        {
            int rows = 0;

            CurrentUser loggedIn = new CurrentUser()
            {
                Number = 0,
                Username = "",
                FirstName = ""
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<CurrentUser>();
                    rows = conn.Update(loggedIn);
                }
                catch (Exception)
                {
                    try
                    {
                        rows = conn.Update(loggedIn);
                    }
                    catch (Exception)
                    {
                        DisplayAlert("Oops!", "Something went wrong", "Try Again");
                        App.Current.MainPage = new WelcomePage();
                    }
                }
            }
            if (rows > 0)
            {
                App.Current.MainPage = new RegistrationPage();
            }
            else
            {
                DisplayAlert("Failed", "NO!", "OK");
                App.Current.MainPage = new WelcomePage();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginPage();
            App.Current.MainPage = new RegistrationPage();
            return base.OnBackButtonPressed();
        }
    }
}