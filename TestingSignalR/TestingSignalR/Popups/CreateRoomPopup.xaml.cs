using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingSignalR.Popups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateRoomPopup : Rg.Plugins.Popup.Pages.PopupPage
	{

		private CreateRoomViewModel vm;

		public CreateRoomPopup()
		{
			InitializeComponent();
			vm = new CreateRoomViewModel();
			BindingContext = vm;
		}
	}
}