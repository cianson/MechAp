using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using MechAp.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly:Dependency(typeof(NotificationHelper))]
namespace MechAp.Droid
{
    class NotificationHelper : INotification
    {
        private Context mContext;
        private NotificationManager mnotificationManager;
        private NotificationCompat.Builder mBuilder;
        public static string NOTIFICATION_CHANNEL_ID = "10023";

        public NotificationHelper()
        {
            mContext = global::Android.App.Application.Context;
        }

        public void CreateNotification(string title, string message)
        {
            try
            {
                var sound = global::Android.Net.Uri.Parse(ContentResolver.SchemeAndroidResource + "://" + mContext.PackageName + "/" + Resource.Drawable.notification);

                //Create Audion Attribute
                var alarmAttributes = new AudioAttributes.Builder()
                    .SetContentType(AudioContentType.Sonification)
                    .SetUsage(AudioUsageKind.Notification).Build();

                mBuilder = new NotificationCompat.Builder(mContext);
                mBuilder.SetSmallIcon(Resource.Drawable.mechapIcon);
                mBuilder.SetContentTitle(title)
                    .SetSound(sound)
                    .SetContentText(message)
                    .SetChannelId(NOTIFICATION_CHANNEL_ID)
                    .SetVisibility((int)NotificationVisibility.Public)
                    .SetSmallIcon(Resource.Drawable.mechapIcon)
                    .SetPriority((int)NotificationPriority.High);

                NotificationManager notificationManager = mContext.GetSystemService(Context.NotificationService) as NotificationManager;

                if(global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.O)
                {
                    NotificationImportance importance = global::Android.App.NotificationImportance.High;

                    NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, title, importance);
                    notificationChannel.SetSound(sound, alarmAttributes);
                    notificationChannel.SetShowBadge(true);
                    notificationChannel.Importance = NotificationImportance.High;

                    if(notificationManager != null)
                    {
                        mBuilder.SetChannelId(NOTIFICATION_CHANNEL_ID);
                        notificationManager.CreateNotificationChannel(notificationChannel);
                    }
                }

                notificationManager.Notify(0, mBuilder.Build());
            }
            catch(Exception ex)
            {
                //
            }
        }
    }
}