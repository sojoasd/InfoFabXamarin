using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;

namespace InfoFabApp
{
	public partial class MainPage : MasterDetailPage
	{
		readonly MenuPage menuPage = new MenuPage();

		public MainPage()
		{
			InitializeComponent();

			this.Master = menuPage;
			this.Detail = new NavigationPage(new MasterNotificationPage(0));

			menuPage.MenuListItems.ItemSelected += MenuListItems_ItemSelected;

		}

		void MenuListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterMenu;

			if (item != null)
			{
				this.Detail = new NavigationPage(new MasterNotificationPage(item.MenuNo));
				menuPage.MenuListItems.SelectedItem = null;
				this.IsPresented = false;
			}
		}

	}

}
