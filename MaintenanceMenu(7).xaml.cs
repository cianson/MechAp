using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaintenanceMenu : ContentPage
    {
        Garage selectedCar;
        CurrentUser loggedIn;
        public MaintenanceMenu()
        {
            InitializeComponent();
        }

        public MaintenanceMenu(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();
            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;
        }

        private void TirePressure_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void TireChange_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void WiperBlades_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void TaillightBulb_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void HeadlightBulb_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void CabinAirFilter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }
        private void IntakeAirFilter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }

        private void FrontBrakePads_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }
        private void RearBrakePads_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }
        private void OilChange_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn);
        }
        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }
        private void MaintenanceLogBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }
        private void MoreMaintenanceBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sorry", "This part of MechAp has not been developed yet. Please check back later!", "OK");
            App.Current.MainPage = new MyGarage(loggedIn);
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage(loggedIn);
            return base.OnBackButtonPressed();
        }

    }
}