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
        public MyGarage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MainViewModel();

            string queryString = "SELECT * FROM [Garage]";

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Garage>();
                var cars = conn.Query<Garage>(queryString).ToList();
                GarageInventoryList.ItemsSource = cars;
            }
        }

        private void VehicleRegBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new VehicleRegistration();
        }

        private void TrackerViewBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView();
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu();
        }

        private void LogOutBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new WelcomePage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new VehicleRegistration();
            //App.Current.MainPage = new MaintenanceInput();
            return base.OnBackButtonPressed();
        }

        private void GarageInventoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCar = GarageInventoryList.SelectedItem as Garage;

            if (selectedCar != null)
            {
                App.Current.MainPage = new VehicleProfilePage();
            }
        }
    }
}