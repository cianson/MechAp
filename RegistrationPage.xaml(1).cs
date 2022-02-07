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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void LoginPgBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        private void CreateActBtn_Clicked(object sender, EventArgs e)
        {
            //check if usernameEntry already exists so we don't have multiples of the same username


            //if username is false then we can add the new user 

            //check if password entered matches confirmed password

            //if username doesn't exist AND password and password confirmation matches then new user can be added

                User user = new User()
                {
                    FirstName = firstNameEntry.Text,
                    LastName = lastNameEntry.Text,
                    Username = usernameEntry.Text,
                    Password = passwordEntry.Text,
                    Email = emailEntry.Text
                };

            int rows = 0;

            using (SQLiteConnection conn2 = new SQLiteConnection(App.DatabaseLocation))
            {
                conn2.CreateTable<User>();
                rows = conn2.Insert(user);
            }

                if (rows > 0)
                {
                    DisplayAlert("Welcome!", "Your user was added.", "OK");
                    App.Current.MainPage = new LoginPage();

                }
                else
                {
                    DisplayAlert("Failed", "Your user was not added.", "OK");
                    App.Current.MainPage = new RegistrationPage();
                }

            //if username exists send message saying it is not available and then redirect to registration page
 
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginPage();
            return base.OnBackButtonPressed();
        }


    }
}