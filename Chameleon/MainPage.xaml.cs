using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chameleon.Interfaces;
using Lottie.Forms;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Chameleon
{
    public partial class MainPage : ContentPage
    {
        public bool _isLiked;

        public MainPage()
        {
            InitializeComponent();

            CoverWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
            DataWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
            //ScrollWrapper.HeightRequest = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var status = DependencyService.Get<IStatusBar>();

            if (status != null)
            {
                status.SetStatusBarColor(StatusBarColor.Light);
            }

            DataWrapper.TranslateTo(0, DataWrapper.HeightRequest, length: 0);
        }

        public void Handle_OnClick(object sender, EventArgs e)
        {
            var animation = ((AnimationView)sender);

                if (_isLiked)
                {
                    _isLiked = false;
                    animation.PlayFrameSegment(0, 1);
                }
                else
                {
                    _isLiked = true;
                    animation.Play();
                }
        }

        public async void Handle_Swiped(object sender, SwipedEventArgs e)
        {
            CoverWrapper.TranslateTo(0, (CoverWrapper.Y - CoverWrapper.HeightRequest), length: 300, easing: Easing.CubicInOut);
            DataWrapper.TranslateTo(0, 0, length: 300, easing: Easing.CubicInOut);
            ScrollWrapper.ScrollToAsync(0, 0, false);

            var status = DependencyService.Get<IStatusBar>();

            if (status != null)
            {
                status.SetStatusBarColor(StatusBarColor.Dark);
            }
        }
    }
}
