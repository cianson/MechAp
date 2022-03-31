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
        //variables
        Garage selectedCar;
        CurrentUser loggedIn;
        MtnProcedure procedureSelected;
        string selectedProcedureTitle = string.Empty;

        //Constructors
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

        //Navigation
        private void TirePressure_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Check Tire Pressure";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }

        private void TireChange_Clicked(object sender, EventArgs e)
        {

            selectedProcedureTitle = "Tire Change";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }

        private void WiperBlades_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Wiper Blades";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected); ;
        }

        private void TaillightBulb_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Taillight Bulb";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }

        private void HeadlightBulb_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Headlight Bulb";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }

        private void CabinAirFilter_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Cabin Air Filter";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }
        private void IntakeAirFilter_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Intake Air Filter";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }

        private void FrontBrakePads_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Front Brake Pads";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }
        private void RearBrakePads_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Change Rear Brake Pads/Drums";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
        }
        private void OilChange_Clicked(object sender, EventArgs e)
        {
            selectedProcedureTitle = "Engine Oil Change";

            procedureSelected = VehicleService.GetprocedureSelected(selectedCar.VehicleCode, selectedProcedureTitle);

            App.Current.MainPage = new ProcedureView(selectedCar, loggedIn, procedureSelected);
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