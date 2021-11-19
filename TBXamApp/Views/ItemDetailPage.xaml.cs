using System.ComponentModel;
using Xamarin.Forms;
using TBXamApp.ViewModels;

namespace TBXamApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
