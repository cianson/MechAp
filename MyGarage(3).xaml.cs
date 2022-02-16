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
    public partial class MyGarage : ContentPage
    {
        public MyGarage()
        {
            InitializeComponent();
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
    }
}