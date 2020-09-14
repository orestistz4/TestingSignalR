using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class CurrentUserRoomsViewModel:BaseViewModel
	{


		private ChatServer server;

		private ObservableCollection<UserRoom> rooms;

		public ObservableCollection<UserRoom> Rooms { get { return rooms; } set { SetProperty(ref rooms, value); } }


		public CurrentUserRoomsViewModel()
		{
			Rooms = new ObservableCollection<UserRoom>();
			server = new ChatServer();
		}


		public async Task onAppearing() {


			try
			{
				await Shell.Current.Navigation.PushPopupAsync(new LoadingPopup());
				var list1 = await server.GetUserRooms(App.CurrentUserEmail);
				Rooms = new ObservableCollection<UserRoom>(list1);
				await Shell.Current.Navigation.PopPopupAsync();

			}
			catch (Exception ex) {
				await Shell.Current.Navigation.PopPopupAsync();
				Console.WriteLine(ex.Message);
				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error",ex.Message));
			}
		
		}

	}
}
