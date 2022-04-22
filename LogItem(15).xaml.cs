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
    public partial class LogItem : ContentPage
    {
        //Variables
        Garage selectedCar;
        CurrentUser loggedIn;
        Tracker selectedLogItem;

        //Constructors
        public LogItem()
        {
            InitializeComponent();
        }

        public LogItem(Garage selectedCar, CurrentUser loggedIn, Tracker selectedLogItem)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;
            this.selectedLogItem = selectedLogItem;

            vehicleTitle.Text = selectedCar.CarName + " Log Item";
            DateCompletedDisplay.Text = "Date Completed: " + selectedLogItem.DateCompleted;
            MilageCompletedDisplay.Text = selectedLogItem.AtMilage;
            MtnTitleDisplay.Text = selectedLogItem.MaintenanceTitle;
            DueDateDisplay.Text = "Next Service Date: " + selectedLogItem.DateOfNextSErvice;
            DueMilageDisplay.Text = "Milage for next Service: " + selectedLogItem.MilageOfNextService;
            reminderSetting.IsToggled = selectedLogItem.ReminderSet;
        }

        //Navigation Buttons
        void UpdateBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //Check Password and then execute update
            int rows = 0;
            string username = loggedIn.Username;
            string passwordEntered = passwordEntry.Text;
            string queryStatement = "SELECT * FROM [User] WHERE Username = '" + username + "' AND Password = '" + passwordEntered + "'";

            if(reminderSetting.IsToggled == true)
            {
                string reminderTitle = "Reminder due for " + selectedCar.CarName + "!";
                string reminderMessage = selectedCar.CarName + " is due for " + selectedLogItem.MaintenanceTitle + " on " + selectedLogItem.DateOfNextSErvice + " or when you reach a mileage of " + selectedLogItem.MilageOfNextService;
                DependencyService.Get<INotification>().CreateNotification(reminderTitle, reminderMessage);
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<User>();
                    rows = conn.Query<User>(queryStatement).Count();
                    if (rows > 0)
                    {
                        int worked = 0;

                        Tracker updateInfo = new Tracker()
                        {
                            record_id = selectedLogItem.record_id,
                            DateCompleted = selectedLogItem.DateCompleted,
                            Username = loggedIn.Username,
                            CarName = selectedCar.CarName,
                            AtMilage = MilageCompletedDisplay.Text,
                            MaintenanceTitle = MtnTitleDisplay.Text,
                            ReminderSet = reminderSetting.IsToggled,
                            DateOfNextSErvice = selectedLogItem.DateOfNextSErvice,
                            MilageOfNextService = selectedLogItem.MilageOfNextService
                        };

                        try
                        {
                            worked = conn.Update(updateInfo);
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your log has NOT been updated", "ok");
                            App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                        }
                        if (worked > 0)
                        {
                            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password Correctly to update your log", "Try Again");
                        App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This maintenance log cannot be updated because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                }
            }
        }
        void DeleteBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //Display Alert to confirm this is what they want to do -> Check password -> Delete the log item
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

                        Tracker deleteLog = new Tracker()
                        {
                            record_id = selectedLogItem.record_id,
                            Username = loggedIn.Username,
                            CarName = selectedCar.CarName,
                            AtMilage = MilageCompletedDisplay.Text,
                            MaintenanceTitle = MtnTitleDisplay.Text,
                            ReminderSet = reminderSetting.IsToggled
                        };

                        try
                        {
                            worked = conn.Delete(deleteLog);
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your log has NOT been updated", "ok");
                            App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                        }
                        if (worked > 0)
                        {
                            DisplayAlert("Success", "Your log has been updated", "ok");
                            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password Correctly to complete this task.", "Try Again");
                        App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This maintenance log cannot be updated because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
                }
            }
        }
        void BackToLogBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }
    }
}