using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Threading.Tasks;

namespace InfoFabApp
{
	public partial class SearchNotificationPage : ContentPage
	{
		public int srch { get; set; }

		private ObservableCollection<NotificationItem> _listView { get; set; }

		private string _srhTitle { get; set; }

		private int _typeNum { get; set;}

		private bool _isVisible { get; set; }

		private string _filterStr { get; set; }

		public SearchNotificationPage(int TypeNum)
		{
			InitializeComponent();

			_typeNum = TypeNum;

			_listView = HandleNotificationData.GetNotificationData(_typeNum);

			_isVisible = true;

			switch (_typeNum)
			{
				case 0:
					_srhTitle = "全部搜尋";
					break;

				case 1:
					_srhTitle = "未讀搜尋";
					break;

				case 2:
					_srhTitle = "已讀搜尋";
					break;

				case 3:
					_srhTitle = "收藏搜尋";
					_isVisible = false;
					break;

				default:
					break;
			}

			this.NotificationItems.ItemsSource = null;
			this.NotificationItems.ItemSelected += NotificationItems_ItemSelected;
		}

		void NotificationItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as NotificationItem;

			if (item != null)
			{
				Navigation.PushAsync(new DetailNotificationPage(item));

				((ListView)sender).SelectedItem = null;
			}
		}

		void Tgr_Tapped(object sender, EventArgs e)
		{
			Label mi = ((Label)sender);

			var list = _listView;

			HandleCommonEvent.FavoriteEvent(mi, ref list);

			_listView = list;
		}

		protected override void OnAppearing()
		{
			Title = _srhTitle;
			FilterSearchOutput();
		}

		public void OnDelete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			NotificationItem item = mi.CommandParameter as NotificationItem;
			HandleNotificationData.DeleteItem(item);

			_listView.Remove(item);

			FilterSearchOutput();
		}

		private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			_filterStr = e.NewTextValue;

			FilterSearchOutput();
		}

		private void FilterSearchOutput()
		{ 
			if (string.IsNullOrWhiteSpace(_filterStr))
			{
				this.NotificationItems.ItemsSource = null;
			}
			else
			{
				this.NotificationItems.ItemsSource = _listView.Where(w => w.Title.ToLower().Contains(_filterStr.ToLower())).ToList();
			}
		}
	}
}
