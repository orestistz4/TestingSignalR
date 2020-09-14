using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Hubs;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class RoomViewModel:BaseViewModel
	{

		public Command LeaveGroup { get; set; }

		private string textMessage;
		public string TextMessage { get { return textMessage; } set { SetProperty(ref textMessage,value); } }

		private ChatServer server;

		public Command	 SendMessage { get; set; }
		private ObservableCollection<GroupMessages> roomMessages;
		public ObservableCollection<GroupMessages> RoomMessages { get { return roomMessages; } set { SetProperty(ref roomMessages,value); } }

		public HubBase ChatHub { get; set; }
		public int MyProperty { get; set; }

		private string currentGroup;
		public string CurrentGroup { get { return currentGroup; } set { SetProperty(ref currentGroup,value); } }
		public RoomViewModel(string roomName)
		{

			server = new ChatServer();
			TextMessage = "";
			CurrentGroup = roomName;
			RoomMessages = new ObservableCollection<GroupMessages>();
			//SendMessage = new Command(async()=>await ChatHub.SendGroupMessage(CurrentGroup,(new MessageModel() { Message="Hey there",Group=roomName,Date=DateTime.Now})) );
			SendMessage = new Command(async()=> await SendFunction());
			LeaveGroup = new Command(async()=>await LeaveFunction());
		}


		private async Task LeaveFunction()
		{
			await Shell.Current.Navigation.PushPopupAsync(new DeleteRoomPopup(CurrentGroup));
		}

		private async Task SendFunction()
		{

			try {


				if(TextMessage!=null && !TextMessage.Equals(""))
				{
					var messageModel = new MessageModel()
					{
						Message =TextMessage,
						Group = CurrentGroup,
						Date = DateTime.Now,
						Username=App.CurrentUserEmail
						
					};
					await server.SendMessage(messageModel);
				}
				else
				{
					await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error","Message is emptry..."));
				}

				
			
			} catch (Exception ex) {

				Console.WriteLine(ex.Message);
				//await Shell.Current.Navigation.PushPopupAsync(new InfoPopup()) ;
			}

		}

		public async Task onAppearing()
		{
			//edw pera 8a koitaei thn vash kai 8a kanei load ta messages!!
			try
			{
				await Shell.Current.Navigation.PushPopupAsync(new LoadingPopup());
				await ChatHub.Init(CurrentGroup);
				
				await ChatHub.hubConnection.StartAsync();
				await ChatHub.JoinGroup(CurrentGroup);
				var list1 = await server.GetGroypMessages(CurrentGroup);
				RoomMessages = new ObservableCollection<GroupMessages>(list1);
				await Shell.Current.Navigation.PopPopupAsync();
				//await server.AddRoom(CurrentGroup);
			}
			catch (Exception ex)
			{
				await Shell.Current.Navigation.PopPopupAsync();
				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error",ex.Message));
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.Message);
			}

		}

		public void ReceiveMessage(object sender,MessageModel message)
		{
			if (message.Group == CurrentGroup) {

				RoomMessages.Add(new GroupMessages() { Message=message.Message,Username=message.Username,Date=DateTime.Now});
				Console.WriteLine(message.Message);
				Console.WriteLine("sth");

			}

	

		}

	}
}
