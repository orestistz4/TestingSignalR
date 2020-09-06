using Newtonsoft.Json;
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
	public class CreateRoomViewModel:BaseViewModel
	{
		private Command createCommand;
		public Command	 CreateCommand { get { return createCommand; } set { SetProperty(ref createCommand,value); } }
		private ChatServer server;



		private string roomName;
		public string RoomName { get { return roomName; } set { SetProperty(ref roomName,value); } }


		public CreateRoomViewModel()
		{
			server = new ChatServer();
			CreateCommand = new Command(async()=>await CreateRoom());
		}




		public async Task CreateRoom()
		{

			try
			{

				var result = await server.JoinRoom(RoomName);
				if (result == false)
				{

					var addUserRoom = await server.CreateUserRoom(new UserRoom() { Room = RoomName, Email = App.CurrentUserEmail });
					//var stringContent = JsonConvert.SerializeObject(addUserRoom) as ResponseModel;
					await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Info",addUserRoom.response));

				}
			}
			catch (Exception ex) {

				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error",ex.Message));
			
			}
			
		}

	}
}
