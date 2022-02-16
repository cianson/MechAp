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
        public ProcedureView()
        {
            InitializeComponent();
        }

        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu();
        }

        private void TrackerViewBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new TrackerView();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MaintenanceMenu();
            return base.OnBackButtonPressed();
        }
    }
}