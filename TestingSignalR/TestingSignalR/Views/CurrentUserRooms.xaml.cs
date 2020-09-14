using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;
using TestingSignalR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingSignalR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentUserRooms : ContentPage
	{

		private CurrentUserRoomsViewModel vm;
		public CurrentUserRooms()
		{
			InitializeComponent();
			vm = new CurrentUserRoomsViewModel();
			BindingContext = vm;
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();
			try {


				await vm.onAppearing();
			
			}
			catch(Exception ex)
			{

			}
		}

		private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var listView = sender as ListView;
			if (listView == null || !listView.IsEnabled) return;
			try
			{
				listView.IsEnabled = false;
				listView.SelectedItem = null;
				var item = e.SelectedItem as UserRoom;

				if (item != null)
				{
					try
					{




						await Shell.Current.Navigation.PushAsync(new RoomView(item.Room));


					}
					catch (Exception ex)
					{





					}
				}
			}
			catch (Exception ex)
			{

			}
			finally
			{
				listView.IsEnabled = true;
			}





		}
	}
}