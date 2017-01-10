using System;
using System.Net;

namespace InfoFabApp
{
	public interface IDeviceNotification
	{
		HttpStatusCode GetToken(string Account, string password);

		void RegisterAzureNotification();
	}
}
