using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace InfoFabApp
{
	public static class HandleCommonEvent
	{
		public static void FavoriteEvent(Label label, ref ObservableCollection<NotificationItem> list)
		{ 
			string title = (label.GestureRecognizers[0] as TapGestureRecognizer).CommandParameter.ToString();

			var CurrentItem = list.FirstOrDefault(f => f.Title == title);

			HandleNotificationData.UpdateItem(CurrentItem);

			label.Text = CurrentItem.IsFavorite ? "\uf004" : "\uf08a";
			//label.Text = CurrentItem.IsFavorite ? "True" : "False";
		}

		public static void FavoriteEvent(Label label)
		{
			string title = (label.GestureRecognizers[0] as TapGestureRecognizer).CommandParameter.ToString();

			var list = HandleNotificationData.GetNotificationData(0);

			var CurrentItem = list.FirstOrDefault(f => f.Title == title);

			HandleNotificationData.UpdateItem(CurrentItem);

			label.Text = CurrentItem.IsFavorite ? "\uf004" : "\uf08a";
			//label.Text = CurrentItem.IsFavorite ? "True" : "False";
		}
	}
}
