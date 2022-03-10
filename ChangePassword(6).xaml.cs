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
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePasswordBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage();
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage();
        }
    }
}