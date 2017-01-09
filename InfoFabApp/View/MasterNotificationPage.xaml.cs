using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.ComponentModel;

namespace InfoFabApp
{
	public partial class MasterNotificationPage : ContentPage
	{
		public ListView NotificationListItems { get { return NotificationItems; } }

		private ObservableCollection<NotificationItem> _notifList = null;

		private int _typeNum { get; set; }

		private string _srhTitle { get; set; }

		private bool _isLoading = true;

		public MasterNotificationPage(int TypeNum)
		{
			InitializeComponent();

			_typeNum = TypeNum;

			_notifList = HandleNotificationData.GetNotificationData(_typeNum);

			switch (_typeNum)
			{
				case 0:
					_srhTitle = "全部訊息";
					break;

				case 1:
					_srhTitle = "未讀訊息";
					break;

				case 2:
					_srhTitle = "已讀訊息";
					break;

				case 3:
					_srhTitle = "收藏訊息";
					break;

				default:
					break;
			}

			this.NotificationItems.ItemsSource = _notifList;

			this.NotificationItems.ItemSelected += NotificationItems_ItemSelected;

			//this.NotificationItems.ItemAppearing += NotificationItems_ItemAppearing;

		}

		void Tgr_Tapped(object sender, EventArgs e)
		{
			var mi = ((Label)sender);

			HandleCommonEvent.FavoriteEvent(mi, ref _notifList);

			//string title = (mi.GestureRecognizers[0] as TapGestureRecognizer).CommandParameter.ToString();

			//var CurrentItem = _notifList.FirstOrDefault(f => f.Title == title);

			//HandleNotificationData.UpdateItem(CurrentItem);

			//mi.Text = CurrentItem.IsFavorite ? "\uf004" : "\uf08a";
		}

		//void NotificationItems_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		//{
		//	var CurrentItem = e.Item as NotificationItem;

		//	if (_notifList.Count == 0)
		//		return;

		//	var LastItem = _notifList[_notifList.Count - 1];
		//	if (CurrentItem == LastItem)
		//	{
		//		if (_isLoading)
		//		{
		//			_isLoading = false;
		//		}
		//		else 
		//		{ 
		//			DisplayAlert("Test", "Scroll", "OK");
		//		}
		//		//PullMoreAroundYouData(); // Make the rest api call to get more data to list
		//	}
		//}

		void NotificationItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as NotificationItem;

			if (item != null) 
			{
				Navigation.PushAsync(new DetailNotificationPage(item));

				((ListView)sender).SelectedItem = null;
			}

		}

		protected override void OnAppearing()
		{
			Title = _srhTitle;

			//_notifList = HandleNotificationData.GetNotificationData(_typeNum);
			//this.NotificationItems.ItemsSource = _notifList;
		}

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			NotificationItem item = mi.CommandParameter as NotificationItem;
			HandleNotificationData.DeleteItem(item);

			//_notifList = HandleNotificationData.GetNotificationData(_typeNum);
			//this.NotificationItems.ItemsSource = _notifList;
		}

		private void OnShowSearch(object sender, EventArgs e)
		{
			//this.NotificationItems.ItemsSource = null;
			//_notifList = HandleNotificationData.GetNotificationData(_typeNum);
			//this.NotificationItems.ItemsSource = _notifList;

			Navigation.PushAsync(new SearchNotificationPage(_typeNum));
		}
	}

}
