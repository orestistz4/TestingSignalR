using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
			var result = await server.JoinRoom(RoomName);
			Console.WriteLine("asdf");


		}

	}
}
