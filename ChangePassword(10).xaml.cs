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
    public partial class ChangePassword : ContentPage
    {
        //Variables
        CurrentUser loggedIn;
        User userLoggedIn;

        //Constructors
        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePassword(CurrentUser loggedIn, User userLoggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;
            this.userLoggedIn = userLoggedIn;

            UsernameLabel.Text = loggedIn.Username;
        }
        private void ChangePasswordBtn_Clicked(object sender, EventArgs e)
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
                        string newPassword = newPasswordEntry.Text;
                        string confirmNewPassword = confirmNewPasswordEntry.Text;

                        //Check if new password matches the confirm new password 
                        if (newPassword == confirmNewPassword)
                        {
                            User updatePassword = new User()
                            {
                                Username = loggedIn.Username,
                                Password = newPassword,
                                FirstName = userLoggedIn.FirstName,
                                LastName = userLoggedIn.LastName,
                                Email = userLoggedIn.Email
                            };

                            try
                            {
                                worked = conn.Update(updatePassword);
                            }
                            catch (Exception)
                            {
                                DisplayAlert("Oh No", "Your password has NOT been updated", "OK");
                                App.Current.MainPage = new ProfilePage(loggedIn);
                            }
                            if (worked > 0)
                            {
                                DisplayAlert("Success", "Your password has been updated", "ok");
                                App.Current.MainPage = new ProfilePage(loggedIn);
                            }
                        }
                        else
                        {
                            DisplayAlert("Sorry", "Your new password and confirm new password entries do NOt match. So we cannot update your password", "Try Again");
                            App.Current.MainPage = new ProfilePage(loggedIn);
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your current password correctly to change your password", "Try Again");
                        App.Current.MainPage = new ProfilePage(loggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "Your password cannot be updated because your current password is incorrect.", "ok");
                    App.Current.MainPage = new ProfilePage(loggedIn);
                }
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }
    }
}