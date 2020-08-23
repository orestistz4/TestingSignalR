using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSignalR.Popups;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class CreateRoomViewModel:BaseViewModel
	{
		private Command createCommand;
		public Command	 CreateCommand { get { return createCommand; } set { SetProperty(ref createCommand,value); } }




		public CreateRoomViewModel()
		{
			CreateCommand = new Command(async()=>await Shell.Current.Navigation.PushPopupAsync(new CreateRoomPopup()));
		}

	}
}
