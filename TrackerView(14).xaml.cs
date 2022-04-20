using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Drawing;
using System.IO;

namespace MechAp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackerView : ContentPage
    {
        private const int X = 0;

        //variables
        Garage selectedCar;
        CurrentUser loggedIn;
        string usernameLoggedIn = string.Empty;
        string carNameSelected = string.Empty;

        //Constructors
        public TrackerView()
        {
            InitializeComponent();
        }
        public TrackerView(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;

            vehicleTitle.Text = selectedCar.CarName + "'s Maintenance Log";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            usernameLoggedIn = loggedIn.Username;
            carNameSelected = selectedCar.CarName;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Tracker>();
                var logItems = conn.Query<Tracker>("SELECT * FROM [Tracker] WHERE Username = ? AND CarName = ?", usernameLoggedIn, carNameSelected).ToList();
                MaintenanceLog.ItemsSource = logItems;
            }
        }


        //Navigation Buttons
        private void MyGarageBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MyGarage(loggedIn);
        }

        private void MaintInputBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceInput(selectedCar, loggedIn);
        }

        private void MaintMenuBtn_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MaintenanceMenu(selectedCar, loggedIn);
        }

        private void MaintenanceLog_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedLogItem = MaintenanceLog.SelectedItem as Tracker;

            if (selectedLogItem != null)
            {
                App.Current.MainPage = new LogItem(selectedCar, loggedIn, selectedLogItem);
            }
        }

        private async void ShareBtn_Clicked(object sender, EventArgs e)
        {
            string logItemString = string.Empty;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Tracker>();
                    var logItems = conn.Query<Tracker>("SELECT * FROM [Tracker] WHERE Username = ? AND CarName = ?", usernameLoggedIn, carNameSelected).ToList();

                    foreach (var log in logItems)
                    {
                        logItemString = logItemString + log.CarName.ToString() + ", " + log.DateCompleted.ToString() + ", " + log.MaintenanceTitle.ToString() + ", " + log.AtMilage.ToString() +  Environment.NewLine;
                    }
                }
                catch (Exception) { logItemString = "unable to generate log at this time try again later"; }
            }

            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "Maintenance Log for " + selectedCar.Year + selectedCar.Make + selectedCar.Model + selectedCar.CarName,
                Text = logItemString
            });
        }
    }
}