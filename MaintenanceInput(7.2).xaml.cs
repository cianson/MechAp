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
    public partial class MaintenanceInput : ContentPage
    {
        //variables
        Garage selectedCar;
        CurrentUser loggedIn;

        public MaintenanceInput()
        {
            InitializeComponent();
        }
        public MaintenanceInput(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;

            CarName.Text = "For " + selectedCar.CarName;
        }

        private void InputMtnBtn_Clicked(object sender, EventArgs e)
        {
            string date = dateEntry.Text;
            //Use date to calculate date this item is due.
            //User milage entry to calculate at what milage this item should be conducted.

            Tracker log = new Tracker()
            {
                Username = loggedIn.Username,
                CarName = selectedCar.CarName,
                DateCompleted = date,
                MaintenanceTitle = mtnTitleEntry.Text,
                AtMilage = milageEntry.Text,
                DateOfNextSErvice = "",
                MilageOfNextService = "",
                ReminderSet = reminderSetting.IsToggled
            };

            int rows = 0;

            using (SQLiteConnection conn2 = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn2.CreateTable<Tracker>();
                    rows = conn2.Insert(log);
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "Something went wrong.", "Try Agian");
                    App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
                }
            }

            if (rows > 0)
            {
                DisplayAlert("Success!", "Great Work! We logged it.", "OK");
                App.Current.MainPage = new TrackerView(selectedCar, loggedIn);

            }
            else
            {
                DisplayAlert("Failed", "Your maintenance was not input for some reason.", "Try Again");
                App.Current.MainPage = new MaintenanceInput(selectedCar, loggedIn);
            }
        }

        //Navigation Buttons
        private void TrackerViewBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
            return base.OnBackButtonPressed();
        }
    }
}