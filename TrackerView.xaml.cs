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
    public partial class TrackerView : ContentPage
    {
        public TrackerView()
        {
            InitializeComponent();
        }

        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

        private void MaintInputBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceInput();
        }

    }
}