using NFPConnect.Interfaces;
using NFPConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFPConnect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebView : ContentPage
    {
        string userId = "";
        public WebView()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            userId = Preferences.Get("userId", string.Empty);
            webView.Source = AppConstants.WebUrl+"?userId="+ userId;
        }
        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform == Device.Android)
                DependencyService.Get<IAndroidMethods>().CloseApp();

            return base.OnBackButtonPressed();
        }
    }
}