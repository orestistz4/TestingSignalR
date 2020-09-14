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
	public partial class LoadingPopup : Rg.Plugins.Popup.Pages.PopupPage
	{
		private LoadingPopupViewModel vm;
		public LoadingPopup()
		{
			InitializeComponent();
			vm = new LoadingPopupViewModel();
			BindingContext = vm;
		}


		protected override async void OnAppearing()
		{
			base.OnAppearing();



			
				Task.Run(vm.onAppearing);
			
		}
	}
}