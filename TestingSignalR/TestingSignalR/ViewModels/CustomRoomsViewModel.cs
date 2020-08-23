using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSignalR.Popups;
using TestingSignalR.Views;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class CustomRoomsViewModel:BaseViewModel
	{

		public Command CreateRoomCommand { get; set; }
		public Command JoinCommand { get; set; }



		private Command createCommand;
		public Command CreateCommand { get { return createCommand; } set { SetProperty(ref createCommand,value); } }
		public Command YourRoomsCommand { get; set; }

		public CustomRoomsViewModel()
		{


			//CreateCommand = new Command(async()=>await Shell.Current.Navigation.PushPopupAsync(new CreateRoomPopup()));
			CreateCommand = new Command(async()=>await Shell.Current.Navigation.PushModalAsync(new LoginPage()));
			CreateRoomCommand = new Command(async()=>await Shell.Current.Navigation.PushAsync(new RoomView("chatroom1")));


		}


	}
}
