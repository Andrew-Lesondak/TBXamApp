using System.ComponentModel;
using Xamarin.Forms;
using TBXamApp.ViewModels;
using TBXamApp.Models;

namespace TBXamApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(DeviceDetail selectedItem)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(Navigation, selectedItem);
        }
    }
}
