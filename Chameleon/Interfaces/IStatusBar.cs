using System;
using Xamarin.Forms;

namespace Chameleon.Interfaces
{
    public interface IStatusBar
    {
        float StatusBarHeight { get; }
        Thickness ScreenInsets { get; }

        void SetStatusBarColor(StatusBarColor color);
    }

    public enum StatusBarColor
    {
        Light,
        Dark
    }
}
