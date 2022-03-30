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
    public partial class ProfileDelete : ContentPage
    {
        //Variables

        CurrentUser loggedIn;
        User userLoggedIn;

        //Constructors
        public ProfileDelete()
        {
            InitializeComponent();
        }
        public ProfileDelete(CurrentUser loggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;

            UsernameLabel.Text = loggedIn.Username;
        }
        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            //Display Alert to confirm this is what they want to do -> Check password -> Delete the account
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

                        User deleteUser = new User()
                        {
                            Username = loggedIn.Username
                        };

                        try
                        {
                            worked = conn.Delete(deleteUser);
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your profile has NOT been deleted", "ok");
                            App.Current.MainPage = new ProfileDelete(loggedIn);
                        }
                        if (worked > 0)
                        {
                            DisplayAlert("Success", "Your profile has been deleted", "ok");
                            App.Current.MainPage = new WelcomePage();
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password correctly to complete this task.", "Try Again");
                        App.Current.MainPage = new ProfileDelete(loggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This profile cannot be deleted because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new ProfileDelete(loggedIn);
                }
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }
    }
}