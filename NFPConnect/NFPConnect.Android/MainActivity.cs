using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using NFPConnect.Models;
using Microsoft.Azure.NotificationHubs.Client;
using Android.Support.V4.App;
using Android.Content;
using NFPConnect.Droid.Services;
using Xamarin.Forms;

namespace NFPConnect.Droid
{
    [Activity(Label = "NFPConnect", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Activity FormsContext { get; set; }
        public static readonly int ConfirmRequestId = 1;
        internal static readonly string CHANNEL_ID = "my_notification_channel";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            FormsContext = this;
            base.OnCreate(savedInstanceState);
            NotificationHub.Start(AppConstants.ListenConnectionString, AppConstants.NotificationHubName);
            NotificationHub.NotificationMessageReceived += OnNotificationMessageReceived;
            CreateNotificationChannel();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
        private void OnNotificationMessageReceived(object sender, NotificationMessageReceivedEventArgs e)
        {
            createNotification(e.Title, e.Body);
            // Do something with the message
            Console.WriteLine($"Title: {e.Title}");
            Console.WriteLine($"Body: {e.Body}");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == ConfirmRequestId)
            {
                // Credentials entered successfully!
                if (resultCode == Result.Ok)
                {
                    BiometricHandler handler = new BiometricHandler(this);
                    MessagingCenter.Send<object>("keyguard", "Success");
                }
                else
                {
                    // The user canceled or didn’t complete the lock screen
                    // operation. Go to error/cancellation flow.
                }
            }
        }
        public void createNotification(string title, string desc)
        {
            // Set up an intent so that tapping the notifications returns to this app:
            Intent intent = new Intent(this, typeof(MainActivity));

            // Create a PendingIntent; we're only using one PendingIntent (ID = 0):
            const int pendingIntentId = 0;
            PendingIntent pendingIntent =
                PendingIntent.GetActivity(this, pendingIntentId, intent, PendingIntentFlags.OneShot);

            // Instantiate the builder and set notification elements, including pending intent:
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, CHANNEL_ID)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(desc)
                .SetSmallIcon(Resource.Drawable.abc_ratingbar_small_material);

            // Build the notification:
            Notification notification = builder.Build();

            // Get the notification manager:
            NotificationManager notificationManager =
                GetSystemService(Context.NotificationService) as NotificationManager;

            // Publish the notification:
            const int notificationId = 0;
            notificationManager.Notify(notificationId, notification);
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }

            var channelName = "test";
            var channelDescription = "test";
            var channel = new NotificationChannel(CHANNEL_ID, channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
}