using SQLite;
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
            if (selectedCar.Style != null)
                styleDisplay.Text = selectedCar.Style.ToString();
            if (selectedCar.Milage != null)
                milageDisplay.Text = selectedCar.Milage.ToString();
            vehicleCode.Text = "Vehicle Code: " + selectedCar.VehicleCode.ToString();
        }

        void UpdateBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //Check Password and then execute update
            int rows = 0;
            string username = loggedIn.Username;
            string passwordEntered = PasswordEntry.Text;
            string queryStatement = "SELECT * FROM [User] WHERE Username = '" + username + "' AND Password = '" + passwordEntered + "'";

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<User>();
                    rows = conn.Query<User>(queryStatement).Count();
                    if (rows > 0)
                    {
                        int worked = 0;

                        Garage updateInfo = new Garage()
                        {
                            Username = selectedCar.Username,
                            CarName = selectedCar.CarName,
                            Make = selectedCar.Make,
                            Model = selectedCar.Model,
                            Year = selectedCar.Year,
                            Milage = milageDisplay.Text,
                            Style = styleDisplay.Text,
                            VehicleCode = selectedCar.VehicleCode

                        };

                        try
                        {
                            worked = conn.Update(updateInfo);
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your vehicle info has NOT been updated", "ok");
                            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
                        }
                        if (worked > 0)
                        {
                            DisplayAlert("Success", "Your vehicle info has been updated", "ok");
                            App.Current.MainPage = new VehicleProfilePage(updateInfo, loggedIn);
                        }
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password Correctly to update your log", "Try Again");
                        App.Current.MainPage = new VehicleInfo(selectedCar, loggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This info cannot be updated because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new VehicleInfo(selectedCar, loggedIn);
                }
            }
        }

        void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
        }
    }
}
