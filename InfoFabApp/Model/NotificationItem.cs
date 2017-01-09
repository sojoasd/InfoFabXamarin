using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace InfoFabApp
{
	public class NotificationItem: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public Guid ID { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public DateTime ReceiveTime { get; set; }

		public ImageSource ImageUri { get; set; }
		
		public bool IsReaded { get; set; }

		//public bool IsFavorite { get; set; }
		private bool _IsFavorite { get; set; }

		public bool IsFavorite
		{
			set
			{
				if (_IsFavorite != value)
				{
					_IsFavorite = value;
					OnPropertyChanged("IsFavorite");
				}
			}
			get
			{
				return _IsFavorite;
			}
		}

		public string FavoriteIcon { get; set; }

		public bool IsDeleted { get; set; }

		public string FromName { get; set; }

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
