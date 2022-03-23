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
    public partial class VehicleInfo : ContentPage
    {
        CurrentUser loggedIn;
        Garage selectedCar;

        public VehicleInfo()
        {
            InitializeComponent();
        }
        public VehicleInfo(Garage selectedCar, CurrentUser loggedIn)
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

        void UpdateBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
        }

        void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
        }
    }
}