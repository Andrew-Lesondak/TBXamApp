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
        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = new ItemsViewModel(Navigation);
        }
    }
}
