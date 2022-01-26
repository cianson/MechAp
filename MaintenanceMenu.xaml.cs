using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MechAp
{
    public partial class MaintenanceMenu : ContentPage
    {
        public MaintenanceMenu()
        {
            InitializeComponent();
        }

        private void OilChangeBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProcedureView();
        }

        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        private void TrackerViewBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage();
            return base.OnBackButtonPressed();
        }
    }
}