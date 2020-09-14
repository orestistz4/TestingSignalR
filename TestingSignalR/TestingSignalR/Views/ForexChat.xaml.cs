using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Hubs;
using TestingSignalR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingSignalR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForexChat : ContentPage
	{
		private HubBase hubBase;
		private ForexChatViewModel vm;

		public ForexChat()
		{
			InitializeComponent();
			vm = new ForexChatViewModel();
			hubBase = new HubBase();
			vm.ChatHub = hubBase;
			hubBase.ForexSubscribers += vm.ReceiveForexSymbols;
			hubBase.PageAppear += vm.AppearPage;

			BindingContext = vm;
		}
		protected override async void OnAppearing()
		{
			base.OnAppearing();

			await vm.OnAppearing();
		}

		
	}
}