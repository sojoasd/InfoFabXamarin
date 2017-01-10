using System;
using System.Net;
using InfoFabApp.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceAndroidPNS))]
namespace InfoFabApp.Droid
{
	public class DeviceAndroidPNS: IDeviceNotification
	{
		public DeviceAndroidPNS()
		{
		}

		public HttpStatusCode GetToken(string Account, string password)
		{
			HttpStatusCode ret = HttpStatusCode.InternalServerError;



			return ret;
		}

		public void RegisterAzureNotification()
		{
			throw new NotImplementedException();
		}
	}
}
