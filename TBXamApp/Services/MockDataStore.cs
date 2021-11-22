using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBXamApp.Models;

namespace TBXamApp.Services
{
    public class MockDataStore : IDataStore<DeviceDetail>
    {
        readonly List<DeviceDetail> items;

        public MockDataStore()
        {
            items = new List<DeviceDetail>()
            {
                new DeviceDetail { Id = Guid.NewGuid().ToString(), Text = "Connectivity", Description="Info about the device's internet connectivity." },
                new DeviceDetail { Id = Guid.NewGuid().ToString(), Text = "Device Info", Description="Info about the user's device." },
                new DeviceDetail { Id = Guid.NewGuid().ToString(), Text = "Display Info", Description="Info about the device's display." },
            };
        }

        public async Task<bool> AddItemAsync(DeviceDetail item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(DeviceDetail item)
        {
            var oldItem = items.Where((DeviceDetail arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((DeviceDetail arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<DeviceDetail> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<DeviceDetail>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
