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
    public partial class VehicleRegistration : ContentPage
    {
        public VehicleRegistration()
        {
            InitializeComponent();
        }

        private void AddGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage();
            return base.OnBackButtonPressed();
        }
    }
}