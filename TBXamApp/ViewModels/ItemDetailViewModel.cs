using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TBXamApp.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using TBXamApp.Services;
using System.Collections.Generic;

namespace TBXamApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ICommand DismissModal { private set; get; }
        public string SelectedText { get; set; }

        private bool deviceInfoEnabled = false;
        public bool DeviceInfoEnabled
        {
            get { return deviceInfoEnabled; }
            set { deviceInfoEnabled = value; }
        }
        private bool displayInfoEnabled = false;
        public bool DisplayInfoEnabled
        {
            get { return displayInfoEnabled; }
            set { displayInfoEnabled = value; }
        }
        private bool connectivityInfoEnabled = false;
        public bool ConnectivityInfoEnabled
        {
            get { return connectivityInfoEnabled; }
            set { connectivityInfoEnabled = value; }
        }
        
        string orientation = "";
        public string Orientation
        {
            get { return "Orientation: " + orientation; }
            set { orientation = value; }
        }
        string rotation = "";
        public string Rotation
        {
            get { return "Rotation: " + rotation;  }
            set { rotation = value; }
        }
        string width = "";
        public string Width
        {
            get { return "Width: " + width; }
            set { width = value; }
        }
        string height = "";
        public string Height
        {
            get { return "Height: " + height; }
            set { height = value; }
        }
        string density = "";
        public string Density
        {
            get { return "Density: " + density; }
            set { density = value; }
        }
        string device = "";
        public string Device
        {
            get { return "Device: " + device; }
            set { device = value; }
        }
        string manufacturer = "";
        public string Manufacturer
        {
            get { return "Manufacturer: " + manufacturer; }
            set { manufacturer = value; }
        }
        string deviceName = "";
        public string DeviceName
        {
            get { return "Device Name: " + deviceName; }
            set { deviceName = value; }
        }
        string version = "";
        public string Version
        {
            get { return "Version: " + version; }
            set { version = value; }
        }
        string platform = "";
        public string Platform
        {
            get { return "Platform: " + platform; }
            set { platform = value; }
        }
        string idiom = "";
        public string Idiom
        {
            get { return "Idiom: " + idiom; }
            set { idiom = value; }
        }
        string deviceType = "";
        public string DeviceType
        {
            get { return "Device Type: " + deviceType; }
            set { deviceType = value; }
        }
        string connectionType = "";
        public string ConnectionType
        {
            get { return "Connection Type: " + connectionType; }
            set { connectionType = value; }
        }

        public ItemDetailViewModel(INavigation navigation, DeviceDetail selectedItem)
        {
            MockDataStore dataStore = new MockDataStore();
            DismissModal = new Command(async () => await navigation.PopModalAsync());

            SelectedText = selectedItem.Text;
            SelectDisplayContent(selectedItem.Text);
        }

        public void SelectDisplayContent(string selected)
        {
            switch (selected)
            {
                case "Connectivity":
                    HandleConnectivityDetails();
                    break;
                case "Device Info":
                    HandleDeviceInfoDetails();
                    break;
                case "Display Info":
                    HandleDisplayDetails();
                    break;
                default:
                    break;
            }
        }

        public void HandleDisplayDetails()
        {
            DisplayInfoEnabled = true;

            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Orientation (Landscape, Portrait, Square, Unknown)
            Orientation = mainDisplayInfo.Orientation.ToString();

            // Rotation (0, 90, 180, 270)
            Rotation = mainDisplayInfo.Rotation.ToString();

            // Width (in pixels)
            Width = mainDisplayInfo.Width.ToString();

            // Height (in pixels)
            Height = mainDisplayInfo.Height.ToString();

            // Screen density
            Density = mainDisplayInfo.Density.ToString();
        }

        public void HandleDeviceInfoDetails()
        {
            DeviceInfoEnabled = true;

            // Device Model (SMG-950U, iPhone10,6)
            Device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            Manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            DeviceName = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            Version = DeviceInfo.VersionString;

            // Platform (Android)
            Platform = DeviceInfo.Platform.ToString();

            // Idiom (Phone)
            Idiom = DeviceInfo.Idiom.ToString();

            // Device Type (Physical)
            DeviceType = DeviceInfo.DeviceType.ToString();
        }

        public void HandleConnectivityDetails()
        {
            ConnectivityInfoEnabled = true;

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                ConnectionType = "Internet";
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {
                ConnectionType = "Constrained Internet";
            }
            else if (current == NetworkAccess.Local)
            {
                ConnectionType = "Local Network";
            }
            else if (current == NetworkAccess.Unknown)
            {
                ConnectionType = "Unknown";
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {
                ConnectionType = "None";
            }
        }
    }
}
