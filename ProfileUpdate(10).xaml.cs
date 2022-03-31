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
    public partial class ProfileUpdate : ContentPage
    {
        //Variables
        CurrentUser loggedIn;
        User userLoggedIn;

        //Constructors
        public ProfileUpdate()
        {
            InitializeComponent();
        }
        public ProfileUpdate(CurrentUser loggedIn, User userLoggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;
            this.userLoggedIn = userLoggedIn;

            //SQL using statement to place query for the user so that we can get all the info

            usernameTitle.Text = loggedIn.Username;
            firstNamePlaceholder.Text = loggedIn.FirstName;
            lastNamePlaceholder.Text = userLoggedIn.LastName;
            emailPlaceholder.Text = userLoggedIn.Email;
        }

        //Navigation Buttons
        private void SubmitUpdateBtn_Clicked(System.Object sender, System.EventArgs e)
        {

            //Check Password and then execute update
            int rows = 0;
            string username = loggedIn.Username;
            string passwordEntered = passwordEntry.Text;
            string queryStatement = "SELECT * FROM [User] WHERE Username = '" + username + "' AND Password = '" + passwordEntered + "'";

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<User>();
                    rows = conn.Query<User>(queryStatement).Count();
                    if (rows > 0)
                    {
                        int worked = 0;

                        User updateInfo = new User()
                        {
                            Username = loggedIn.Username,
                            FirstName = firstNamePlaceholder.Text,
                            LastName = lastNamePlaceholder.Text,
                            Email = emailPlaceholder.Text,
                            Password = userLoggedIn.Password
                        };

                        try
                        {
                            worked = conn.Update(updateInfo);
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your profile has NOT been updated", "ok");
                            App.Current.MainPage = new ProfilePage(loggedIn);
                        }
                        if (worked > 0)
                        {
                            DisplayAlert("Success", "Your profile has been updated", "ok");
                            App.Current.MainPage = new ProfilePage(loggedIn);
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password correctly to update your profile", "Try Again");
                        App.Current.MainPage = new ProfilePage(loggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This profile cannot be updated because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new ProfilePage(loggedIn);
                }
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }

        private void ChangePasswordBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ChangePassword(loggedIn, userLoggedIn);
        }
    }
}
