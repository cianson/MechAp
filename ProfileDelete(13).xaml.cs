using System;
using SQLite;
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
        public ProfileDelete(CurrentUser loggedIn, User userLoggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;
            this.userLoggedIn = userLoggedIn;

            UsernameLabel.Text = loggedIn.Username;
        }
        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            //Display Alert to confirm this is what they want to do -> Check password -> Delete the account
            int rows = 0;
            string username = userLoggedIn.Username;
            string passwordEntered = passwordEntry.Text;
            string queryStatement = "SELECT * FROM [User] WHERE Username = '" + username + "' AND Password = '" + passwordEntered + "'";
            string deleteQuery1 = "DELETE FROM Garage WHERE Username = " + username;
            string deleteQuery2 = "DELETE FROM Tracker WHERE Username = " + username;

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

                            if (worked > 0)
                            {
                                DisplayAlert("Success", "Your profile has been deleted.", "OK");

                                int count = 0;
                                int success = 0;
                                int successCount = 0;
                                int success2 = 0;
                                int successCount2 = 0;

                                try
                                {
                                    var cars = conn.Query<Garage>("SELECT * FROM [Garage] WHERE Username = ?", username).ToList();
                                    count = cars.Count();

                                    var trackerItems = conn.Query<Tracker>("SELECT * FROM [Tracker] WHERE Username = ?", username).ToList();
                                    int trackerCount = trackerItems.Count();

                                    if (count > 0)
                                    {
                                      foreach(var car in cars)
                                        {
                                            try
                                            {
                                                success = conn.Delete<Garage>(car.CarName);
                                            }
                                            catch(Exception)
                                            {
                                            }
                                            if(success > 0)
                                            {
                                                successCount++;
                                            }
                                        }
                                      foreach(var log in trackerItems)
                                        {
                                            try
                                            {
                                                success2 = conn.Delete<Tracker>(log.record_id);
                                            }
                                            catch(Exception)
                                            { }
                                            if (success2 > 0)
                                                successCount2++;
                                        }
                                      if(successCount >= count && successCount2 >= trackerCount)
                                        {
                                            App.Current.MainPage = new WelcomePage();
                                        }
                                    }                                        
                                }
                                catch(Exception)
                                {
                                    DisplayAlert("Nope", "Garage not deleted", "OK");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your profile has NOT been deleted", "ok");
                            App.Current.MainPage = new ProfileDelete(loggedIn, userLoggedIn);
                        }                       
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password correctly to complete this task.", "Try Again");
                        App.Current.MainPage = new ProfileDelete(loggedIn, userLoggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This profile cannot be deleted because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new ProfileDelete(loggedIn, userLoggedIn);
                }
            }
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }
    }
}