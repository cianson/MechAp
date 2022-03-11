using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MechAp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new WelcomePage();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new WelcomePage();
            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
