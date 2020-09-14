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
	public class JoinPopupViewModel:BaseViewModel
	{

		private ChatServer server;


		private string roomName;
		public string RoomName { get { return roomName; } set { SetProperty(ref roomName,value); } }
		
		public Command JoinCommand { get; set; }
		public Command CancelCommand { get; set; }
		public Command ClosePopup { get; set; }



		public JoinPopupViewModel()
		{
			server = new ChatServer();
			RoomName = "";
			ClosePopup = new Command(async()=>await Shell.Current.Navigation.PopPopupAsync());
			JoinCommand = new Command(async()=>await JoinFunction());


		}


		private async Task JoinFunction()
		{


			try {

				var result = await server.JoinRoom(RoomName);
				if (result==true) {

					var addUserRoom = await server.CreateUserRoom(new UserRoom() { Room = RoomName, Email = App.CurrentUserEmail });
					await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Info",addUserRoom.response));

				}
				else
				{
					throw new Exception("Room does not exist!!");
				}

			}
			catch(Exception ex)
			{

				Console.WriteLine("STH HAPPEND");
				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Erro",ex.Message));

			}
			
			


		}

	}
}
