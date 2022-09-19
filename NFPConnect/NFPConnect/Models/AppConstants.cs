using System;
using System.Collections.Generic;
using System.Text;

namespace NFPConnect.Models
{
    public static class AppConstants
    {
        public static string NotificationChannelName { get; set; } = "XamarinNotifyChannel";
        public static string NotificationHubName { get; set; } = "NFPConnect";
        public static string ListenConnectionString { get; set; } = "Endpoint=sb://NFPConnect.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=8O02aWLYFwou93gdRbpwBihEnSGp+W2t+a4hXasaWkc=";
        public static string DebugTag { get; set; } = "XamarinNotify";
        public static string[] SubscriptionTags { get; set; } = { "default" };
        public static string FCMTemplateBody { get; set; } = "{\"data\":{\"message\":\"$(messageParam)\"}}";
        public static string APNTemplateBody { get; set; } = "{\"aps\":{\"alert\":\"$(messageParam)\"}}";
        public static string WebUrl { get; set; } = "https://www.nfp.com?";
        public static string postLoginAPI { get; set; } = "https://connect-individual.azurewebsites.net/Authentication";//"https://localhost:7239/Authentication";//
    }
}
