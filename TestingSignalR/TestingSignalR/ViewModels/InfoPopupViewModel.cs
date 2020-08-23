using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class InfoPopupViewModel:BaseViewModel
	{


		private string errorDescription;
		public string ErrorDescription { get { return errorDescription; } set { SetProperty(ref errorDescription, value); } }
		private string errorMessage;
		public string ErrorMessage { get { return errorMessage; } set { SetProperty(ref errorMessage,value); } }

		public Command ClosePopup { get; set; }

		/*public InfoPopupViewModel(string desc,string mesage)
		{
			ClosePopup = new Command(async()=>await Shell.Current.Navigation.PopPopupAsync());
			ErrorDescription = desc;
			ErrorMessage = mesage;
		}*/

	}
}
