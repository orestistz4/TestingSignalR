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
	public partial class InfoPopup : Rg.Plugins.Popup.Pages.PopupPage
	{

		private InfoPopupViewModel vm;
		public InfoPopup(string desc,string message)
		{
			InitializeComponent();
			vm = new InfoPopupViewModel(desc,message);
			BindingContext = vm;
		}
	}
}