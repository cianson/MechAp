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
    public partial class ProcedureView : ContentPage
    {
        Garage selectedCar;
        CurrentUser loggedIn;
        MtnProcedure procedureSelected;

        public ProcedureView()
        {
            InitializeComponent();

        }

        public ProcedureView(Garage selectedCar, CurrentUser loggedIn, MtnProcedure procedureSelected)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;
            this.procedureSelected = procedureSelected;

            TitleDisplay.Text = procedureSelected.ProcedureTitle + " on " + selectedCar.CarName;
            procedureDisplay.Text = procedureSelected.FileName;

        }


        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu(selectedCar, loggedIn);
        }

        private void TrackerViewBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView(selectedCar, loggedIn);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MaintenanceMenu(selectedCar, loggedIn);
            return base.OnBackButtonPressed();
        }
    }
}
