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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void LoginPgBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginPage();
            return base.OnBackButtonPressed();
        }
    }
}