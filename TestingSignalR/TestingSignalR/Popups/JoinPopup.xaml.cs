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
	public partial class JoinPopup : Rg.Plugins.Popup.Pages.PopupPage
	{

		private JoinPopupViewModel vm;
		public JoinPopup()
		{
			InitializeComponent();
			vm = new JoinPopupViewModel();
			BindingContext = vm;
		}
	}
}