using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using InfoFabApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceAndroidAttrs))]
namespace InfoFabApp.Droid
{
	public class DeviceAndroidAttrs : IDeviceAttrs
	{
		public DeviceAndroidAttrs()
		{
		}

		DeviceAttrs IDeviceAttrs.GetDeviceAttrs()
		{
			var deviceAttrs = new DeviceAttrs();

			var windowManager = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
			var size = new Point();
			windowManager.DefaultDisplay.GetSize(size);
			deviceAttrs.Height = size.Y;
			deviceAttrs.Width = size.X;

			//using (var wm = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>())
			//using (var dm = new DisplayMetrics())
			//{
			//	var rotation = wm.DefaultDisplay.Rotation;
			//	wm.DefaultDisplay.GetMetrics(dm);

			//	deviceAttrs.Height = dm.HeightPixels;
			//	deviceAttrs.Width = dm.WidthPixels;
			//}

			return deviceAttrs;
		}
	}
}
