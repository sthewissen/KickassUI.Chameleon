using System;
using Xamarin.Forms;

namespace Chameleon.Controls
{
	public enum StrokeType
	{
		Solid,
		Dotted,
		Dashed
	}

	public enum SeparatorOrientation
	{
		Vertical,
		Horizontal
	}

	public class Separator : View
	{
		public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(SeparatorOrientation), typeof(Separator), SeparatorOrientation.Horizontal, BindingMode.OneWay, null, null, null, null);
		public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(Separator), Color.Default, BindingMode.OneWay, null, null, null, null);
		public static readonly BindableProperty SpacingBeforeProperty = BindableProperty.Create(nameof(SpacingBefore), typeof(double), typeof(Separator), (double)1, BindingMode.OneWay, null, null, null, null);
		public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(double), typeof(Separator), (double)1, BindingMode.OneWay, null, null, null, null);
		public static readonly BindableProperty SpacingAfterProperty = BindableProperty.Create(nameof(SpacingAfter), typeof(double), typeof(Separator), (double)1, BindingMode.OneWay, null, null, null, null);
		public static readonly BindableProperty StrokeTypeProperty = BindableProperty.Create(nameof(StrokeType), typeof(StrokeType), typeof(Separator), StrokeType.Solid, BindingMode.OneWay, null, null, null, null);

		public SeparatorOrientation Orientation
		{
			get
			{
				return (SeparatorOrientation)base.GetValue(Separator.OrientationProperty);
			}

			private set
			{
				base.SetValue(Separator.OrientationProperty, value);
			}
		}

		public Color Color
		{
			get
			{
				return (Color)base.GetValue(Separator.ColorProperty);
			}
			set
			{
				base.SetValue(Separator.ColorProperty, value);
			}
		}

		public double SpacingBefore
		{
			get
			{
				return (double)base.GetValue(Separator.SpacingBeforeProperty);
			}
			set
			{
				base.SetValue(Separator.SpacingBeforeProperty, value);
			}
		}

		public double SpacingAfter
		{
			get
			{
				return (double)base.GetValue(Separator.SpacingAfterProperty);
			}
			set
			{
				base.SetValue(Separator.SpacingAfterProperty, value);
			}
		}
		public double Thickness
		{
			get
			{
				return (double)base.GetValue(Separator.ThicknessProperty);
			}
			set
			{
				base.SetValue(Separator.ThicknessProperty, value);
			}
		}

		public StrokeType StrokeType
		{
			get
			{
				return (StrokeType)base.GetValue(Separator.StrokeTypeProperty);
			}
			set
			{
				base.SetValue(Separator.StrokeTypeProperty, value);
			}
		}

		public Separator()
		{
			UpdateRequestedSize();
		}

		protected override void OnPropertyChanged(string propertyName)
		{
			base.OnPropertyChanged(propertyName);
			if (propertyName == ThicknessProperty.PropertyName ||
			   propertyName == ColorProperty.PropertyName ||
			   propertyName == SpacingBeforeProperty.PropertyName ||
			   propertyName == SpacingAfterProperty.PropertyName ||
			   propertyName == StrokeTypeProperty.PropertyName ||
			   propertyName == OrientationProperty.PropertyName)
			{
				UpdateRequestedSize();
			}
		}

		private void UpdateRequestedSize()
		{
			var minSize = Thickness;
			var optimalSize = SpacingBefore + Thickness + SpacingAfter;
			if (Orientation == SeparatorOrientation.Horizontal)
			{
				MinimumHeightRequest = minSize;
				HeightRequest = optimalSize;
				HorizontalOptions = LayoutOptions.FillAndExpand;
			}
			else
			{
				MinimumWidthRequest = minSize;
				WidthRequest = optimalSize;
				VerticalOptions = LayoutOptions.FillAndExpand;
			}
		}
	}
}