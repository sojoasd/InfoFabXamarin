using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace InfoFabApp
{
	public partial class DetailNotificationPage : ContentPage
	{
		private NotificationItem _item { get; set; }

		public DetailNotificationPage(NotificationItem item)
		{
			InitializeComponent();

			_item = item;
			_item.FromName = "Zeal";
			_item.IsFavorite = item.IsFavorite;

			BindingContext = _item;
		}

		void Tgr_Tapped(object sender, EventArgs e)
		{
			var mi = ((Label)sender);
			HandleCommonEvent.FavoriteEvent(mi);
		}

		void OnDeleteItem(object sender, EventArgs e)
		{ 
			var mi = ((ToolbarItem)sender);
			var CurrentItem = mi.CommandParameter as NotificationItem;

			HandleNotificationData.DeleteItem(CurrentItem);

			Navigation.PopAsync();

			//var stack = Navigation.NavigationStack.First();
			//if (stack != null)
			//{
			//	Navigation.RemovePage(stack);
			//}
		}
	}
}
