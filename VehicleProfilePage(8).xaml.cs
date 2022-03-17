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
    public partial class VehicleProfilePage : ContentPage
    {
        //Variables
        Garage selectedCar;
        CurrentUser loggedIn;

        //Constructors
        public VehicleProfilePage()
        {
            InitializeComponent();
        }

        public VehicleProfilePage(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;

            ProfileTitle.Text = selectedCar.CarName.ToString();
            yearDisplay.Text = selectedCar.Year.ToString();
            makeDisplay.Text = selectedCar.Make.ToString();
            modelDisplay.Text = selectedCar.Model.ToString();
            styleDisplay.Text = selectedCar.Style.ToString();
        }


        //Navigation buttons
        private void VehicleInfoUpdateBtn_Clicked(object sender, EventArgs e)
        {

        }
        private void DeleteVehicleBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new DeleteVehicle(selectedCar, loggedIn);
        }
        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu(selectedCar, loggedIn);
        }
        private void MaintInputBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceInput(selectedCar, loggedIn);
        }
        private void TrackerBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }
        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }
    }
}
