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
    public partial class DeleteVehicle : ContentPage
    {
        CurrentUser loggedIn;
        Garage selectedCar;
        public DeleteVehicle()
        {
            InitializeComponent();
        }
        public DeleteVehicle(Garage selectedCar, CurrentUser loggedIn)
        {
            InitializeComponent();

            this.selectedCar = selectedCar;
            this.loggedIn = loggedIn;

            VehicleName.Text = selectedCar.CarName;
        }

        void DeleteBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            //Display Alert to confirm this is what they want to do -> Check password -> Delete the log item
            int rows = 0;
            string username = loggedIn.Username;
            string passwordEntered = passwordEntry.Text;
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

                        Garage deleteLog = new Garage()
                        {
                            Username = selectedCar.Username,
                            CarName = selectedCar.CarName,
                            Make = selectedCar.Make,
                            Model = selectedCar.Model,
                            Year = selectedCar.Year,
                            Milage = selectedCar.Milage,
                            Style = selectedCar.Style,
                            VehicleCode = selectedCar.VehicleCode
                        };

                        try
                        {
                            worked = conn.Delete(deleteLog);
                            if (worked > 0)
                            {
                                DisplayAlert("Success", "Your vehicle has been deleted.", "OK");

                                int count = 0;
                                int success = 0;
                                int successCount = 0;
                                try
                                {
                                    var trackerItems = conn.Query<Tracker>("SELECT * FROM [Tracker] WHERE CarName = ?", deleteLog.CarName).ToList();
                                    int trackerCount = trackerItems.Count();

                                        foreach (var log in trackerItems)
                                        {
                                            try
                                            {
                                                success = conn.Delete<Tracker>(log.record_id);
                                            }
                                            catch (Exception)
                                            { }
                                            if (success > 0)
                                                successCount++;
                                        }
                                        if (successCount >= count && successCount >= trackerCount)
                                        {
                                            App.Current.MainPage = new MyGarage(loggedIn);
                                        }
                                }
                                catch (Exception)
                                {
                                    DisplayAlert("Nope", "Garage not deleted", "OK");
                                }
                                App.Current.MainPage = new MyGarage(loggedIn);
                            }
                        }
                        catch (Exception)
                        {
                            DisplayAlert("Oh No", "Your vehicle has NOT been deleted", "ok");
                            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);
                        }                       
                    }
                    else
                    {
                        DisplayAlert("Oops!", "You need to enter your password Correctly to complete this task.", "Try Again");
                        App.Current.MainPage = new DeleteVehicle(selectedCar, loggedIn);
                    }
                }
                catch (Exception)
                {
                    DisplayAlert("Sorry", "This vehicle cannot be deleted because the password you entered was incorrect.", "ok");
                    App.Current.MainPage = new DeleteVehicle(selectedCar, loggedIn);
                }
            }
        }

        void CancelBtn_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.MainPage = new VehicleProfilePage(selectedCar, loggedIn);

        }
    }
}