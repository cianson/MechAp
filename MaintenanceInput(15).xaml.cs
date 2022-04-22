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
        string mtnTitleSelected = string.Empty;

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
            dateEntry.Text = DateTime.Now.ToString("d");
        }

        private void InputMtnBtn_Clicked(object sender, EventArgs e)
        {
            string date = dateEntry.Text;
            string title = string.Empty;
            string nextServiceDate = string.Empty;
            string mileageAtNextService = string.Empty;


            if(mtnTitleSelected == "Other")
            {
                title = OtherEntry.Text;
            }
            else
            {
                title = mtnTitleSelected;
            }
            //Use date to calculate date this item is due.
            nextServiceDate = NextService.GetReminderDate(mtnTitleSelected, date);

            //User milage entry to calculate at what milage this item should be conducted.
            mileageAtNextService = NextService.GetNextServiceMileage(mtnTitleSelected, milageEntry.Text);

            //if ReminderSet is true set reminder
            if (reminderSetting.IsToggled == true)
            {
                string reminderTitle = "Reminder due for " + selectedCar.CarName + "!";
                string reminderMessage = selectedCar.CarName + " is due for " + mtnTitleSelected + " on " + nextServiceDate + " or when you reach a mileage of " + mileageAtNextService;
                DependencyService.Get<INotification>().CreateNotification(reminderTitle, reminderMessage);
            }

            //Fill in new Tracker object content
            Tracker log = new Tracker()
            {
                Username = loggedIn.Username,
                CarName = selectedCar.CarName,
                DateCompleted = date,
                MaintenanceTitle = title,
                AtMilage = milageEntry.Text,
                DateOfNextSErvice = nextServiceDate,
                MilageOfNextService = mileageAtNextService,
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
                App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
            }
            else
            {
                DisplayAlert("Failed", "Your maintenance was not input for some reason.", "Try Again");
                App.Current.MainPage = new MaintenanceInput(selectedCar, loggedIn);
            }
        }
        private void mtnTitlePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtnTitleSelected = mtnTitlePicker.SelectedItem.ToString();

            if(mtnTitleSelected == "Other")
            {
                OtherEntry.IsVisible = true;
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