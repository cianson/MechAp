using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Windows.Input;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyGarage : ContentPage
    {
        //Variables 
        CurrentUser loggedIn;
        public string usernameLoggedIn = string.Empty;
        public string userFirstName = string.Empty;

        //Constructors
        public MyGarage()
        {
            InitializeComponent();

        }

        public MyGarage(CurrentUser loggedIn)
        {
            InitializeComponent();

            this.loggedIn = loggedIn;
            GarageTitle.Text = loggedIn.FirstName + "'s Garage";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameLoggedIn = loggedIn.Username;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Garage>();
                var cars = conn.Query<Garage>("SELECT * FROM [Garage] WHERE Username = ?", usernameLoggedIn).ToList();
                GarageInventoryList.ItemsSource = cars;
            }
        }

        //If a car item from list is selected
        private void GarageInventoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCar = GarageInventoryList.SelectedItem as Garage;

            if (selectedCar != null)
            {
                App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
            }
        }

        //Navigation buttons
        private void VehicleRegBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new VehicleRegistration(loggedIn);
        }

        private void ProfileBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new VehicleRegistration(loggedIn);
            //App.Current.MainPage = new MyGarage(loggedIn);
            return base.OnBackButtonPressed();
        }
    }
}
