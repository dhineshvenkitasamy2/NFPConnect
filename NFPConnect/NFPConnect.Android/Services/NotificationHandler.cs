using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NFPConnect.Droid.Services;
using NFPConnect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationHandler))]
namespace NFPConnect.Droid.Services
{
    public class NotificationHandler : INotificationManager
    {
        public void SendNotification(string title, string message, DateTime? notifyTime = null)
        {

        }
    }
}