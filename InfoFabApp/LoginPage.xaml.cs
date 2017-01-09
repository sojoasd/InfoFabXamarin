using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InfoFabApp
{
	public partial class LoginPage : ContentPage
	{
		public bool IsLoading { get; set; }

		public LoginPage()
		{
			InitializeComponent();

			IsLoading = false;

			loginBtn.Clicked += LoginBtn_Clicked;
		}

		async void LoginBtn_Clicked(object sender, EventArgs e)
		{
			sl1.IsVisible = true;
			sl2.IsRunning = true;

			await HandleNotificationData.RefreshNotificationData();

			Application.Current.MainPage = new MainPage();

			//Application.Current.MainPage = new NavigationPage(new MainPage());


		}
	}
}
