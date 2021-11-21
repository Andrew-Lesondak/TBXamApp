using System;
using System.ComponentModel;
using TBXamApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBXamApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }
    }
}
