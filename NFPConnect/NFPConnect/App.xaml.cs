using NFPConnect.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFPConnect
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NFPConnect.MainPage());
        }

        protected override async void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        public void NavToLogin()
        {
            MainPage = new Login();
        }
    }
}
