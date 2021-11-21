using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TBXamApp.Services;
using TBXamApp.Views;

namespace TBXamApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await MainPage.DisplayAlert(
                "Welcome!",
                "Tube Buddy is your best friend on the road to YouTube success.",
                "Let's Go!");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
