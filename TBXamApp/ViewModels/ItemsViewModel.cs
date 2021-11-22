using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using TBXamApp.Models;
using TBXamApp.Views;
using System.Collections;
using System.Collections.Generic;
using TBXamApp.Services;
using System.Windows.Input;

namespace TBXamApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private INavigation navigation;
        public INavigation Navigation {
            get
            {
                return navigation;
            }
            set
            {
                if(navigation != value)
                {
                    navigation = value;
                    OnPropertyChanged("Navigation");
                }
            }
        }
       
        public ItemsViewModel()
        {
            MockDataStore dataStore = new MockDataStore();
            SetPickerItems(dataStore);

            ViewDetails = new Command(async () => {
                var itemDetailPage = new ItemDetailPage();
                await Navigation.PushModalAsync(itemDetailPage);
            });
        }

        public async void SetPickerItems(MockDataStore store)
        {
            DetailList = (List<DeviceDetail>)await store.GetItemsAsync();
        }

        public List<DeviceDetail> DetailList { get; set; }

        private string selectedItem;
        public string SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                // SetProperty(ref selectedItem, value);
                // OnItemSelected(value);
            }
        }

        //async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (listView.SelectedItem != null)
        //    {
        //        var detailPage = new DetailPage();

        //        await Navigation.PushModalAsync(detailPage);
        //    }
        //}

        public ICommand ViewDetails { private set; get; }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        //public async void ViewDetails()
        //{
        //    var itemDetailPage = new ItemDetailPage();
        //    await Navigation.PushModalAsync(itemDetailPage);

        //}

        public void ItemSelected(string item)
        {
            if (item == null)
                return;

            SelectedItem = item;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}
