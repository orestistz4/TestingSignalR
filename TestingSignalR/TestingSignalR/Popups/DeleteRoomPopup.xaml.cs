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
	public partial class DeleteRoomPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
		private DeleteRoomPopupViewModel vm;
		public DeleteRoomPopup(string room)
		{
			InitializeComponent();
			vm = new DeleteRoomPopupViewModel(room);
			BindingContext = vm;
		}
	}
}