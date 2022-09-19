using Microsoft.Azure.NotificationHubs.Client;
using NFPConnect.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Azure.NotificationHubs.Client;
using NFPConnect.Models;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific.AppCompat;
using Xamarin.Essentials;

namespace NFPConnect
{
    public partial class MainPage : ContentPage
    {
        string userId = String.Empty;
        public MainPage()
        {
            InitializeComponent();
            subscribeAuthFail();
            userId = Preferences.Get("userId", string.Empty);
            triggerLoginMethod();

            ListenNotification();
        }
        private void OnNotificationMessageReceived(object sender, NotificationMessageReceivedEventArgs e)
        {
            DependencyService.Get<INotificationManager>().SendNotification("title", "body");
            // Do something with the message
            Console.WriteLine($"Title: {e.Title}");
            Console.WriteLine($"Body: {e.Body}");
        }
        private void OnInstallatedSaved(object sender, InstallationSavedEventArgs e)
        {
            Console.WriteLine($"Installation ID: {e.Installation.InstallationId} saved successfully");
        }

        private void OnInstallationSaveFailed(object sender, InstallationSaveFailedEventArgs e)
        {
            Console.WriteLine($"Failed to save installation: {e.Exception.Message}");
        }
        public void fingerPrintConfiguration()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (DependencyService.Get<IBiometricPieAuthenticate>().CheckSDKGreater29())
                {
                    bool res = DependencyService.Get<IBiometricAuthenticateService>().fingerprintEnabled();
                    bool isKeyguardEnabled = DependencyService.Get<IBiometricAuthenticateService>().isKeyguardEnabled();
                    if (res)
                    {
                        //subscribe for biometricpromt response from Android
                        MessagingCenter.Subscribe<object>("BiometricPrompt", "Success", async (sender) =>
                        {
                            await NavToWebView();
                            MessagingCenter.Unsubscribe<object>("BiometricPrompt", "Success");
                            //TODO:onSuccess
                        });
                        MessagingCenter.Subscribe<object>("BiometricPrompt", "Fail", async (sender) =>
                        {
                            //login
                            await NavToLogin();
                            MessagingCenter.Unsubscribe<object>("BiometricPrompt", "Fail");
                            //TODO:onFailure
                        });

                        //call biomtricprompt dependency service
                        DependencyService.Get<IBiometricPieAuthenticate>().RegisterOrAuthenticate();
                    }
                    else if (isKeyguardEnabled)
                    {
                        DependencyService.Get<IBiometricAuthenticateService>().triggerKeyGuardPage();
                        MessagingCenter.Subscribe<object>("keyguard", "Success", async (sender) =>
                        {
                            await NavToWebView();
                            MessagingCenter.Unsubscribe<object>("keyguard", "Success");
                            //TODO:onSuccess
                        });
                    }
                    else
                    {
                        //biometric enrolled in device
                        //TODO:No biometric
                        //login
                        MessagingCenter.Send<string>("Auth", "Fail");
                    }
                }
                else
                {
                    //lower device than pie sdk
                    //this also support biometric prompt by android yet we lack by XamarinForms
                    bool res = DependencyService.Get<IBiometricAuthenticateService>().fingerprintEnabled();
                    bool isKeyguardEnabled = DependencyService.Get<IBiometricAuthenticateService>().isKeyguardEnabled();
                    if (res)
                    {
                        //check for user have gives access to finger print for this app
                        //app permision stored locally
                        DependencyService.Get<IBiometricAuthenticateService>().AuthenticateUserIDWithTouchID();

                        MessagingCenter.Subscribe<string>("Auth", "Success", async (sender) =>
                        {
                            await NavToWebView();
                            MessagingCenter.Unsubscribe<object>("Auth", "Success");
                        });
                        MessagingCenter.Subscribe<string>("Auth", "Fail", async (sender) =>
                        {
                            //login
                            await NavToLogin();
                            MessagingCenter.Unsubscribe<object>("Auth", "Fail");
                            //TODO Failure
                        });

                    }
                    else if (isKeyguardEnabled)
                    {
                        DependencyService.Get<IBiometricAuthenticateService>().triggerKeyGuardPage();
                        MessagingCenter.Subscribe<object>("keyguard", "Success", async (sender) =>
                        {
                            MessagingCenter.Unsubscribe<object>("keyguard", "Success");
                            await NavToWebView();
                            //MainPage = new NavigationPage(new Login());
                            //TODO:onSuccess
                        });
                    }
                    else
                    {
                        //login
                        MessagingCenter.Send<string>("Auth", "Fail");
                    }
                }

            }

        }
        public async Task<int> NavToWebView()
        {
            await Navigation.PushAsync(new WebView());
            //await Navigation.PushAsync(new NFPConnect.WebView());
            return 1;
        }
        public async Task<int> NavToLogin()
        {
            await Navigation.PushAsync(new NFPConnect.Login());
            return 1;
        }
        public void ListenNotification()
        {
            NotificationHub.Start(AppConstants.ListenConnectionString, AppConstants.NotificationHubName);
            NotificationHub.NotificationMessageReceived += OnNotificationMessageReceived;
            NotificationHub.InstallationSaved += OnInstallatedSaved;
            NotificationHub.InstallationSaveFailed += OnInstallationSaveFailed;
        }
        public void subscribeAuthFail()
        {
            MessagingCenter.Subscribe<string>("Auth", "Fail", async (sender) =>
            {
                //login
                await NavToLogin();
                MessagingCenter.Unsubscribe<object>("Auth", "Fail");
                //TODO Failure
            });
        }
        private async void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            triggerLoginMethod();
        }
        private void triggerLoginMethod()
        {
            if (!String.IsNullOrEmpty(userId))
            {
                fingerPrintConfiguration();
            }
            else
            {
                MessagingCenter.Send<string>("Auth", "Fail");
            }
        }
    }
}
