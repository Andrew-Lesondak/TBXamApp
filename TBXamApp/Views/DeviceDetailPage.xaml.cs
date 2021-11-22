using System.ComponentModel;
using Xamarin.Forms;
using TBXamApp.ViewModels;
using TBXamApp.Models;

namespace TBXamApp.Views
{
    public partial class DeviceDetailPage : ContentPage
    {
        public DeviceDetailPage(DeviceDetail selectedItem)
        {
            InitializeComponent();
            BindingContext = new DeviceDetailViewModel(Navigation, selectedItem);
        }
    }
}
