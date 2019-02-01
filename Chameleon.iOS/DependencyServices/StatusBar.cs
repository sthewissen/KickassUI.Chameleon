using System;
using Chameleon.Interfaces;
using Chameleon.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBar))]
namespace Chameleon.iOS.DependencyServices
{
    public class StatusBar : IStatusBar
    {
        public float StatusBarHeight => (float)UIApplication.SharedApplication.StatusBarFrame.Size.Height;

        public Thickness ScreenInsets
        {
            get
            {
                var insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets;
                return new Thickness(insets.Left, insets.Top, insets.Right, insets.Bottom);
            }
        }

        public void SetStatusBarColor(StatusBarColor color)
        {
            if (color == StatusBarColor.Light)
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
            else
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.Default;
        }
    }
}
