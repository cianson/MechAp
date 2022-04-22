using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using UserNotifications;

namespace MechAp.iOS
{
    class NotificationDelegate : UNUserNotificationCenterDelegate
    {
        public NotificationDelegate()
        {

        }

        public void RegisterNotification(string title, string message)
        {
            UNUserNotificationCenter center = UNUserNotificationCenter.Current;

            //Create UNMutable notification content that is your notification content
            UNMutableNotificationContent notificationContent = new UNMutableNotificationContent();

            notificationContent.Title = title;
            notificationContent.Body = message;

            notificationContent.Sound = UNNotificationSound.Default;

            UNTimeIntervalNotificationTrigger trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(1, false);

            UNNotificationRequest request = UNNotificationRequest.FromIdentifier("five second", notificationContent, trigger);

            center.AddNotificationRequest(request, (NSError obj) =>
            {

            });
        }
    }
}