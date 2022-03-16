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
    public partial class TrackerView : ContentPage
    {
        //variables
        Garage selectedCar;
        CurrentUser loggedIn;
        string usernameLoggedIn = string.Empty;
        string carNameSelected = string.Empty;

        //Constructors
        public TrackerView()
        {
            InitializeComponent();
        }
        public TrackerView(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;

            vehicleTitle.Text = loggedIn.FirstName + "'s " + selectedCar.CarName;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameLoggedIn = loggedIn.Username;
            carNameSelected = selectedCar.CarName;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Tracker>();
                var logItems = conn.Query<Tracker>("SELECT * FROM [Tracker] WHERE Username = ? AND CarName = ?", usernameLoggedIn, carNameSelected).ToList();
                MaintenanceLog.ItemsSource = logItems;
            }
        }


        //Navigation Buttons
        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }

        private void MaintInputBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceInput(selectedCar, loggedIn);
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu(selectedCar, loggedIn);
        }


    }
}