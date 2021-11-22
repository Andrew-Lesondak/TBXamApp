using System;
using System.ComponentModel;
using TBXamApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TBXamApp.Views
{
    public partial class SpinnerPage : ContentPage
    {
        public SpinnerPage()
        {
            InitializeComponent();
            BindingContext = new SpinnerViewModel();
        }
    }
}
