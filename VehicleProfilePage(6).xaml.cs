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
        public VehicleProfilePage()
        {
            InitializeComponent();
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu();
        }

        private void TrackerBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView();
        }
        private void GarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }
    }
}