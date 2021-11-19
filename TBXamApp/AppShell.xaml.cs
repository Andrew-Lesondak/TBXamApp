using System;
using System.Collections.Generic;
using TBXamApp.ViewModels;
using TBXamApp.Views;
using Xamarin.Forms;

namespace TBXamApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
