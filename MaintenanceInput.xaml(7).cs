using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Windows.Input;

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
            Tracker log = new Tracker()
            {
                Username = loggedIn.Username,
                CarName = selectedCar.CarName,
                DateCompleted = date,
                MaintenanceTitle = mtnTitleEntry.Text,
                AtMilage = milageEntry.Text,

            };
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }

        private void reminderSettingRadioBtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {

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