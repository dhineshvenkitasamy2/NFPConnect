using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.Hardware.Fingerprint;
using Android.Support.V4.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NFPConnect.Droid.Services
{
    public class BiometricHandler : FingerprintManagerCompat.AuthenticationCallback
    {
        private Context mainActivity;

        public bool AuthResult;
        public BiometricHandler(Context mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        internal void StartAuthentication(FingerprintManagerCompat fingerprintManager, FingerprintManagerCompat.CryptoObject cryptoObject)
        {
            CancellationSignal cancellationSignal = new CancellationSignal();
            fingerprintManager.Authenticate(cryptoObject, 0, cancellationSignal, this, null);
        }
        public override void OnAuthenticationFailed()
        {
            BiometricAuthService.IsAutSucess = false;
            Toast.MakeText(mainActivity, "Fingerprint Authentication failed!", ToastLength.Long).Show();
            MessagingCenter.Send<string>("Auth", "Fail");
        }
        public override void OnAuthenticationSucceeded(FingerprintManagerCompat.AuthenticationResult result)
        {
            BiometricAuthService.IsAutSucess = true;
            Toast.MakeText(mainActivity, "Fingerprint Authentication Success", ToastLength.Long).Show();
            MessagingCenter.Send<string>("Auth", "Success");
        }
    }
}