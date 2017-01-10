using System;
using Android.App;
using Android.Content;
using Gcm.Client;
using WindowsAzure.Messaging;

[assembly: Permission(Name = "com.infofabapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.infofabapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace InfoFabApp.Droid
{
	[BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "com.infofabapp" })]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "com.infofabapp" })]
	[IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "com.infofabapp" })]
	public class Constans : GcmBroadcastReceiverBase<GcmService>
	{ 
		public static string[] SENDER_IDS = { "" };
		public const string HUB_NAME = "";
		public const string HUB_LISTEN_CONN = "";
	}

	[Service]
	public class GcmService: GcmServiceBase
	{
		public GcmService()
		{
		}

		protected override void OnError(Context context, string errorId)
		{
			throw new NotImplementedException();
		}

		protected override void OnMessage(Context context, Intent intent)
		{
			throw new NotImplementedException();
		}

		protected override void OnRegistered(Context context, string registrationId)
		{
			throw new NotImplementedException();
		}

		protected override void OnUnRegistered(Context context, string registrationId)
		{
			throw new NotImplementedException();
		}
	}
}
