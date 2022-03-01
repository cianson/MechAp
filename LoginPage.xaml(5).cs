using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {
            //(1)Check that both a username and password were entered
            if (string.IsNullOrEmpty(usernameEntry.Text)
                || string.IsNullOrEmpty(passwordEntry.Text))
            {
                DisplayAlert("Required", "Please enter in a Username and a Password.", "Try Again");
                App.Current.MainPage = new LoginPage();
            }
            else
            {
                

                //establish checking variables
                string enteredPassword = passwordEntry.Text;
                string enteredUsername = usernameEntry.Text;
                string queryStatement = "SELECT * FROM User WHERE Username = '" + enteredUsername + "' AND Password = '" + enteredPassword + "'";
                int rows = 0;

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    try
                    {
                        conn.CreateTable<User>();
                        rows = conn.Query<User>(queryStatement).Count();


                        if (rows > 0)
                        {
                            App.Current.MainPage = new MyGarage();
                        }
                        else
                        {
                            DisplayAlert("Sorry", "The Username and Password entered to not match our records.", "Try Again");
                        }
                    }
                    catch (Exception)
                    {
                        DisplayAlert("Oops", "Your username and password do not match our records. Please try again", "OK");
                    }
                }

            }
        }

        private void WelcomePgBtn_Clicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new WelcomePage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new WelcomePage();
            return base.OnBackButtonPressed();
        }

        private void usernameEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}