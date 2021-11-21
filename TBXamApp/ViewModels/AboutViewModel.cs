using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TBXamApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Text Spinner";
        }

        string entryText = "";
        public string EntryText
        {
            set
            {
                if (entryText != value)
                {
                    entryText = value;
                    OnPropertyChanged("EntryText");
                    LabelText = value;

                    HandleSliderState(value);
                }
            }
            get
            {
                return entryText;
            }
        }

        string labelText = "";
        public string LabelText
        {
            set
            {
                if(labelText != value)
                {
                    labelText = value;
                    OnPropertyChanged("LabelText");
                }
            }
            get
            {
                return labelText;
            }
        }

        bool enableSlider = false;
        public bool EnableSlider
        {
            set
            {
                if(enableSlider != value)
                {
                    enableSlider = value;
                    OnPropertyChanged("EnableSlider");
                }
            }
            get
            {
                return enableSlider;
            }
        }

        double sliderRotation = 0;
        public double SliderRotation
        {
            set
            {
                if(sliderRotation != value)
                {
                    sliderRotation = value;
                    OnPropertyChanged("SliderRotation");
                }
            }
            get
            {
                return sliderRotation;
            }
        }

        public void HandleSliderState(string entryText)
        {
            if (entryText == "")
            {
                EnableSlider = false;
                SliderRotation = 0;
            }
            else
            {
                EnableSlider = true;
            }
        }
    }
}
