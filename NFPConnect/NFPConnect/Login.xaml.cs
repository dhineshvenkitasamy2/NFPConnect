using Newtonsoft.Json;
using NFPConnect.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NFPConnect
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private readonly HttpClient httpClient=new HttpClient();
        private ObservableCollection<string> userCode;
        public Login()
        {
            InitializeComponent();
        }
        private async void loginButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool isUserNameEmpty = string.IsNullOrEmpty(userNameEntry.Text);

            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isUserNameEmpty || isPasswordEmpty)
            {
                Console.WriteLine("Enter valid value");
            }
            else
            {
                User user = new User();
                user.emailId = userNameEntry.Text.Trim();
                user.password = passwordEntry.Text.Trim();
                var content = new StringContent(JsonConvert.SerializeObject(user),Encoding.UTF8, "application/json");
                
                var result=await httpClient.PostAsync(AppConstants.postLoginAPI, content).ConfigureAwait(true);
                if (result.IsSuccessStatusCode)
                {
                    var tokenJson = await result.Content.ReadAsStringAsync();
                    if(String.Equals(tokenJson, "Invalid User")){
                        await DisplayAlert("Authentication", "Invalid User", "OK");
                    }
                    else
                    {
                        Preferences.Set("userId", tokenJson);
                        await Navigation.PushAsync(new WebView());
                    }
                }
            }
        }
    }
}