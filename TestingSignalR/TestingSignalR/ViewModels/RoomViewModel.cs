using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Hubs;
using TestingSignalR.Models;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class RoomViewModel:BaseViewModel
	{


		private ChatServer server;

		public Command	 SendMessage { get; set; }
		private ObservableCollection<MessageModel> roomMessages;
		public ObservableCollection<MessageModel> RoomMessages { get { return roomMessages; } set { SetProperty(ref roomMessages,value); } }

		public HubBase ChatHub { get; set; }
		public int MyProperty { get; set; }

		private string currentGroup;
		public string CurrentGroup { get { return currentGroup; } set { SetProperty(ref currentGroup,value); } }
		public RoomViewModel(string roomName)
		{

			server = new ChatServer();

			CurrentGroup = roomName;
			RoomMessages = new ObservableCollection<MessageModel>();
			SendMessage = new Command(async()=>await server.SendMessage(new MessageModel() { Message="Hey there",Group=roomName,Date=DateTime.Now}) );

		}

		public async Task onAppearing()
		{
			//edw pera 8a koitaei thn vash kai 8a kanei load ta messages!!
			try
			{
				await ChatHub.Init(CurrentGroup);
				
				await ChatHub.hubConnection.StartAsync();
				await ChatHub.JoinGroup(CurrentGroup);
				await server.AddRoom(CurrentGroup);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.Message);
			}

		}

		public void ReceiveMessage(object sender,MessageModel message)
		{

			RoomMessages.Add(message);
			Console.WriteLine(message.Message);
			Console.WriteLine("sth");


		}

	}
}
