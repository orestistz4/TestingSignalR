using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class DeleteRoomPopupViewModel:BaseViewModel
	{

		private ChatServer server;

		public Command ClosePopup { get; set; }

		public Command DeleteCommand { get; set; }

		public Command CancelCommand { get; set; }

		private string roomName;
		public string RoomName { get { return roomName; } set { SetProperty(ref roomName,value); } }

		public DeleteRoomPopupViewModel(string room)
		{
			server = new ChatServer();
			RoomName = room;
			CancelCommand = new Command(async()=>await Shell.Current.Navigation.PopPopupAsync());
			DeleteCommand = new Command(async()=>await DeleteFunction());
		}

		private async Task DeleteFunction()
		{
			try
			{

				var response = await server.DeleteUserRoom(new UserRoom() {Email=App.CurrentUserEmail,Room=RoomName });
				await Shell.Current.Navigation.PopPopupAsync();
				await Shell.Current.Navigation.PopModalAsync();


			}catch(Exception ex)
			{

				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error",ex.Message));

			}
		}


	}
}
