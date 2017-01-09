using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace InfoFabApp
{
	public partial class MenuPage : ContentPage
	{
		public ListView MenuListItems { get { return MenuItems; } }

		private ObservableCollection<MasterMenu> MenuList = null;

		public MenuPage()
		{
			InitializeComponent();

			MenuList = new ObservableCollection<MasterMenu>() {
				new MasterMenu(){
					MenuNo = 0,
					MenuName = "訊息首頁",
					MenuIcon = "\uf015",
					MenuFontSize = "20",
				},
				new MasterMenu(){
					MenuNo = 1,
					MenuName = "未讀訊息",
					MenuIcon = "\uf0e0",
					MenuFontSize = "15"
				},
				new MasterMenu(){
					MenuNo = 2,
					MenuName = "已讀訊息",
					MenuIcon = "\uf2b6",
					MenuFontSize = "15"
				},
				new MasterMenu(){
					MenuNo = 3,
					MenuName = "收藏訊息",
					MenuIcon = "\uf004",
					MenuFontSize = "15"
				},
			};

			//UpdateFooterHeight();

			this.MenuItems.ItemsSource = MenuList;

			//this.TestBtn.Clicked += TestBtn_Clicked;
		}

		//protected override void OnBindingContextChanged()
		//{
		//	base.OnBindingContextChanged();
		//	UpdateFooterHeight();
		//}

		//void TestBtn_Clicked(object sender, EventArgs e)
		//{
		//	var device = DependencyService.Get<IDeviceAttrs>().GetDeviceAttrs();

		//	DisplayAlert("Alert", "Height is " + device.Height, "OK");
		//}

		//void UpdateFooterHeight()
		//{
		//	var device = DependencyService.Get<IDeviceAttrs>().GetDeviceAttrs();

		//	double DeviceH = device.Height;

		//	int RowCount = MenuList.Count;

		//	this.FooterWrapper.HeightRequest = (DeviceH - (45 * RowCount) - 25);
		//}
	}
}
