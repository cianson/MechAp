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
    public partial class ProfileUpdate : ContentPage
    {
        //Variables
        CurrentUser loggedIn;
        //User userLoggedIn;

        //Constructors
        public ProfileUpdate()
        {
            InitializeComponent();
        }
        public ProfileUpdate(CurrentUser loggedIn, User userLoggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;

            //SQL using statement to place query for the user so that we can get all the info

            usernameTitle.Text = loggedIn.Username;
            firstNamePlaceholder.Text = loggedIn.FirstName;
            lastNamePlaceholder.Text = userLoggedIn.LastName;
            emailPlaceholder.Text = userLoggedIn.Email;

        }

        //Navigation Buttons
        private void SubmitUpdateBtn_Clicked(object sender, EventArgs e)
        {
            /*I would pass in both the CurrentUser object and the User object. 
             * The Current user just so we dont have to query for it again later wehn we eventually 
             * make it back to the profile page only passing in the CurrentUser*/

            App.Current.MainPage = new ProfilePage(loggedIn);
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ProfilePage(loggedIn);
        }

        private void ChangePasswordBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new ChangePassword(loggedIn);
        }
    }
}
