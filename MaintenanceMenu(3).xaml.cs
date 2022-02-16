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
        public MaintenanceMenu()
        {
            InitializeComponent();
        }

        private void TirePressure_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void TireChange_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void WiperBlades_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void TaillightBulb_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void HeadlightBulb_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void CabinAirFilter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }
        private void IntakeAirFilter_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void FrontBrakePads_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }
        private void RearBrakePads_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }
        private void OilChange_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }
        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }
        private void MaintenanceLogBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView();
        }
        private void MoreMaintenanceBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sorry", "This part of MechAp has not been developed yet. Please check back later!", "OK");
            App.Current.MainPage = new MyGarage();
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage();
            return base.OnBackButtonPressed();
        }

    }
}



