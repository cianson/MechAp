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
        static string makeSelection = string.Empty;
        static string modelSelection = string.Empty;
        static int yearGroupResult = 0;

        public VehicleRegistration()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }

        private int setYearGroup(int year, string make, string model)
        {
            //we will need to reference a database to figure out which year group or generation the car should be in for now I will seperate it based on the mazda miata generation years
            if (year >= 1990 && year <= 1997)
                yearGroupResult = 1;
            if (year >= 1998 && year <= 2005)
                yearGroupResult = 2;
            if (year >= 2006 && year <= 2015)
                yearGroupResult = 3;
            if (year >= 2016)
                yearGroupResult = 4;

            return yearGroupResult;
        }

        private void AddGarageBtn_Clicked(object sender, EventArgs e)
        {
            int vehicleEntryYear = Convert.ToInt32(VehicleYearEntry.Text);
            yearGroupResult = setYearGroup(vehicleEntryYear, makeSelection, modelSelection);

            //check if usernameEntry already exists so we don't have multiples of the same username


            //if username is false then we can add the new user 

            //check if password entered matches confirmed password

            //if username doesn't exist AND password and password confirmation matches then new user can be added

            Garage garage = new Garage()
            {
                Username = "{Binding Username}",
                CarName = VehicleNameEntry.Text,
                Year = vehicleEntryYear,
                Make = makeSelection,
                Model = modelSelection,
                Style = StyleEntry.Text,
                Milage = MilageEntry.Text,
                YearGroup = yearGroupResult
            };

            int rows = 0;

            using (SQLiteConnection conn2 = new SQLiteConnection(App.DatabaseLocation))
            {
                conn2.CreateTable<Garage>();
                rows = conn2.Insert(garage);
            }

            if (rows > 0)
            {
                DisplayAlert("Success!", "A new car was added to your garage.", "OK");
                App.Current.MainPage = new MyGarage();

            }
            else
            {
                DisplayAlert("Failed", "Your car was not added.", "Try Again");
                App.Current.MainPage = new VehicleRegistration();
            }

            //if username exists send message saying it is not available and then redirect to registration page
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MyGarage();
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
                modelPickerEntry.Items.Add("Sierra");
            };
        }

        private void modelPickerEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            modelSelection = modelPickerEntry.SelectedItem.ToString();
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage();
        }

    }
}