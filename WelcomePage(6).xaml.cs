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
    public partial class WelcomePage : ContentPage
    {

        public WelcomePage()
        {
            InitializeComponent();
        }

        private void LoginPgBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new LoginPage();
        }

        private void RegistrationPgBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new RegistrationPage();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new LoginPage();
            App.Current.MainPage = new RegistrationPage();
            return base.OnBackButtonPressed();
        }
    }
}