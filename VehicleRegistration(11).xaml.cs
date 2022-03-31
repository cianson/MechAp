using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleRegistration : ContentPage
    {
        CurrentUser loggedIn;
        static string makeSelection = string.Empty;
        static string modelSelection = string.Empty;
       

        public VehicleRegistration()
        {
            InitializeComponent();

        }

        public VehicleRegistration(CurrentUser loggedIn)
        {
            InitializeComponent();
            this.loggedIn = loggedIn;
        }
        private void AddGarageBtn_Clicked(object sender, EventArgs e)
        {
            int vehicleEntryYear = Convert.ToInt32(VehicleYearEntry.Text);

            if (VehicleNameEntry != null && makeSelection != "" && modelSelection != "" && vehicleEntryYear > 1950)
            {
                Garage garage = new Garage()
                {
                    Username = loggedIn.Username,
                    CarName = VehicleNameEntry.Text,
                    Year = vehicleEntryYear,
                    Make = makeSelection,
                    Model = modelSelection,
                    Style = StyleEntry.Text,
                    Milage = MilageEntry.Text,
                    VehicleCode = MechAp.VehicleService.GetVehicleCode(makeSelection, modelSelection, vehicleEntryYear)
                };

                int rows = 0;

                using (SQLiteConnection conn2 = new SQLiteConnection(App.DatabaseLocation))
                {
                    try
                    {
                        conn2.CreateTable<Garage>();
                        rows = conn2.Insert(garage);
                    }
                    catch (Exception)
                    {
                        DisplayAlert("Sorry", "This Car name has already been used. Please try a different Car Name.", "Try Agian");
                        App.Current.MainPage = new VehicleRegistration(loggedIn);
                    }
                }

                if (rows > 0)
                {
                    DisplayAlert("Success!", "A new car was added to your garage.", "OK");
                    App.Current.MainPage = new MyGarage(loggedIn);

                }
                else
                {
                    DisplayAlert("Failed", "Your car was not added.", "Try Again");
                    App.Current.MainPage = new VehicleRegistration(loggedIn);
                }
            }
            else
            {
                if(vehicleEntryYear <= 1950)
                {
                    DisplayAlert("Sorry", "Your car cannot be that old.", "try again");
                    App.Current.MainPage = new VehicleRegistration(loggedIn);
                }
                else { 
                    DisplayAlert("Oops", "Please enter all required feilds.", "OK");
                    App.Current.MainPage = new VehicleRegistration(loggedIn);
                }
            }
            

            //if username exists send message saying it is not available and then redirect to registration page
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage(loggedIn);
            return base.OnBackButtonPressed();
        }

        private void makePickerEntry_SelectedIndexChanged(object sender, EventArgs e)
        {

            makeSelection = makePickerEntry.SelectedItem.ToString();

            if (makePickerEntry.SelectedIndex == 0)
            {
                modelPickerEntry.Items.Add("Camero");
                modelPickerEntry.Items.Add("Sonic");
            };

            if (makePickerEntry.SelectedIndex == 1)
            {
                modelPickerEntry.Items.Add("Pacifica");
                modelPickerEntry.Items.Add("Town & Country");
                modelPickerEntry.Items.Add("300");

            };

            if (makePickerEntry.SelectedIndex == 2)
            {
                modelPickerEntry.Items.Add("Ram");
                modelPickerEntry.Items.Add("Challenger");
                modelPickerEntry.Items.Add("Durango");
            };

            if (makePickerEntry.SelectedIndex == 3)
            {
                modelPickerEntry.Items.Add("F-150");
                modelPickerEntry.Items.Add("Escape");
                modelPickerEntry.Items.Add("Mustang");
            };

            if (makePickerEntry.SelectedIndex == 4)
            {
                modelPickerEntry.Items.Add("Acadia");
                modelPickerEntry.Items.Add("Canyon");
                modelPickerEntry.Items.Add("Sierra");
            };

            if (makePickerEntry.SelectedIndex == 5)
            {
                modelPickerEntry.Items.Add("Accord");
                modelPickerEntry.Items.Add("Odyssey");
                modelPickerEntry.Items.Add("Civic");
            };

            if (makePickerEntry.SelectedIndex == 6)
            {
                modelPickerEntry.Items.Add("Mazda3");
                modelPickerEntry.Items.Add("MX-5 Miata");
                modelPickerEntry.Items.Add("Mazda6");
            };

            if (makePickerEntry.SelectedIndex == 7)
            {
                modelPickerEntry.Items.Add("Ascent");
                modelPickerEntry.Items.Add("Impreza");
                modelPickerEntry.Items.Add("Legacy");
            };

            if (makePickerEntry.SelectedIndex == 8)
            {
                modelPickerEntry.Items.Add("Avalon");
                modelPickerEntry.Items.Add("Carolla");
                modelPickerEntry.Items.Add("Sienna");
            };
        }

        private void modelPickerEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelSelection = modelPickerEntry.SelectedItem.ToString();
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }
    }

}
