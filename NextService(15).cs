using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MechAp
{
    public class NextService
    {
        public static int GetInterval(string mtnTitleSelected)
        {
            //interval is in days
            int interval = 0;

            //If title entry was not other evaluate the time interval for maintenance Item
            if(mtnTitleSelected == "Other")
            {
                //default to 365 days
                interval = 365;
            }
            else
            {
                switch(mtnTitleSelected)
                {
                    case "Tire Pressure Check":
                        interval = 30;
                        break;
                    case "New Tire(s)":
                        interval = 2100;
                        break;
                    case "Windshield Wipers":
                        interval = 270;
                        break;
                    case "Headlight Bulb(s)":
                        interval = 730;
                        break;
                    case "Taillight Bulb(s)":
                        interval = 730;
                        break;
                    case "Cabin Air Filter":
                        interval = 800;
                        break;
                    case "Intake Air Filter":
                        interval = 120;
                        break;
                    case "Front Brakes":
                        interval = 2000;
                        break;
                    case "Rear Brakes":
                        interval = 4000;
                        break;
                    case "Oil Change":
                        interval = 120;
                        break;
                }
            }
            return interval;
        }
        public static string GetReminderDate(string mtnTitleSelected, string dateCompleted)
        {
            int interval = GetInterval(mtnTitleSelected);
            string reminderDate = string.Empty;

            DateTime completeDate = Convert.ToDateTime(dateCompleted);
            reminderDate = completeDate.AddDays(interval).ToString();

            return reminderDate;
        }

        public static int GetMileInterval(string mtnTitleSelected)
        {
            //interval is in days
            int interval = 0;

            //If title entry was not other evaluate the time interval for maintenance Item
            if (mtnTitleSelected == "Other")
            {
                //default to 365 days
                interval = 6000;
            }
            else
            {
                switch (mtnTitleSelected)
                {
                    case "Tire Pressure Check":
                        interval = 750;
                        break;
                    case "New Tire(s)":
                        interval = 50000;
                        break;
                    case "Windshield Wipers":
                        interval = 6000;
                        break;
                    case "Headlight Bulb(s)":
                        interval = 90000;
                        break;
                    case "Taillight Bulb(s)":
                        interval = 90000;
                        break;
                    case "Cabin Air Filter":
                        interval = 20000;
                        break;
                    case "Intake Air Filter":
                        interval = 30000;
                        break;
                    case "Front Brakes":
                        interval = 50000;
                        break;
                    case "Rear Brakes":
                        interval = 50000;
                        break;
                    case "Oil Change":
                        interval = 6000;
                        break;
                }
            }
            return interval;
        }
        public static string GetNextServiceMileage(string mtnTitleSelected, string mileageCompleted)
        {
            string nextServiceMileage = string.Empty;

            int interval = GetMileInterval(mtnTitleSelected);
            mileageCompleted = mileageCompleted.Trim(',');
            nextServiceMileage = Convert.ToString(Convert.ToInt32(mileageCompleted) + interval);

            return nextServiceMileage;
        }
    }
}
