using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MechAp
{
    public partial class DeleteVehicle : ContentPage
    {
        CurrentUser loggedIn;
        Garage selectedCar;

        public DeleteVehicle()
        {
            InitializeComponent();

        }
        public DeleteVehicle(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;
        }

        void DeleteBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }

        void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);

        }
    }
}