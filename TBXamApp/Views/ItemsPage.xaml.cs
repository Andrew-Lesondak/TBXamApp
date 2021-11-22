using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using TBXamApp.Models;
using TBXamApp.Views;
using TBXamApp.ViewModels;

namespace TBXamApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            //viewModel.Navigation = Navigation;
            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //viewModel.OnAppearing();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
