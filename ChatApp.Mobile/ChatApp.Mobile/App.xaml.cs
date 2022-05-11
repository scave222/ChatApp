using ChatApp.Mobile.Services;
using ChatApp.Mobile.Services.Core;
using ChatApp.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ChatService>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
