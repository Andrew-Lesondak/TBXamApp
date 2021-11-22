using Xamarin.Forms;
using TBXamApp.Models;
using TBXamApp.Views;
using System.Collections.Generic;
using TBXamApp.Services;
using System.Windows.Input;

namespace TBXamApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public List<DeviceDetail> DetailList { get; set; }
        public ICommand ViewDetails { private set; get; }

        private DeviceDetail selectedItem;
        public DeviceDetail SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
                IsDetailsBtnEnabled = true;
            }
        }

        private bool isDetailsBtnEnabled = false;
        public bool IsDetailsBtnEnabled
        {
            get
            {
                return isDetailsBtnEnabled;
            }
            set
            {
                isDetailsBtnEnabled = value;
                OnPropertyChanged("IsDetailsBtnEnabled");
            }
        }

        // Not ideal solution. Seems to be how Xamarin works by design.
        // Should switch to a framework that handles this better.
        public ItemsViewModel(INavigation navigation)
        {
            MockDataStore dataStore = new MockDataStore();
            SetPickerItems(dataStore);

            Navigation = navigation;
            
            ViewDetails = new Command(async () => {
                
                await Navigation.PushModalAsync(new ItemDetailPage(SelectedItem));
            });
        }

        public async void SetPickerItems(MockDataStore store)
        {
            DetailList = (List<DeviceDetail>)await store.GetItemsAsync();
        }
    }
}
