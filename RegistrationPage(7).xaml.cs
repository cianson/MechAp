using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

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

            //check to see if all required entries are entered (Required: Username, password, password confirm, and email)
            if (string.IsNullOrEmpty(usernameEntry.Text)
                || string.IsNullOrEmpty(passwordEntry.Text)
                || string.IsNullOrEmpty(confirmPasswordEntry.Text)
                || string.IsNullOrEmpty(emailEntry.Text))
            {
                DisplayAlert("Please complete all required feilds", 
                             "Username, password, password confirmation, and email are all required.", 
                             "Try Again");
                App.Current.MainPage = new RegistrationPage();
            }
            else
            {

                //check if password entered matches confirmed password
                if (passwordEntry.Text != confirmPasswordEntry.Text)
                {
                    DisplayAlert("Password Error", "Your password and confirm password do NOT match.", "Try Again");
                    App.Current.MainPage = new RegistrationPage();
                }
                else
                {

                    //check if usernameEntry already exists so we don't have multiples of the same username
                    bool userExists = false;
                    List<User> userlist;

                    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                    {
                        conn.CreateTable<User>();
                         userlist = conn.Query<User>("select Username from [User]");
                    }
                    

                    //if username is false then we can add the new user 
                    if (userExists == false)
                    {
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
                                try
                                {
                                    conn2.CreateTable<User>();
                                    rows = conn2.Insert(user);
                                }
                                catch (Exception)
                                {
                                    DisplayAlert("Sorry", "That username has already been used please try another username.", "Try Again");
                                    App.Current.MainPage = new RegistrationPage();
                                }
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
                    }
                }
            }
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginPage();
            return base.OnBackButtonPressed();
        }


    }
}