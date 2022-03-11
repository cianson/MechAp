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
    public partial class ProfileDelete : ContentPage
    {
        //Variables
        CurrentUser loggedIn;
        //User userLoggedIn;

        //Constructors
        public ProfileDelete()
        {
            InitializeComponent();
        }
        public ProfileDelete(CurrentUser loggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;

            UsernameLabel.Text = loggedIn.Username;
        }
        private void DeleteBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new WelcomePage();
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }
    }
}