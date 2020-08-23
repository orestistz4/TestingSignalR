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
	public partial class ChatPageView : ContentPage
	{
		private HubBase hubBase;
		private ChatPageViewModel vm;
		public ChatPageView()
		{
			InitializeComponent();
			vm = new ChatPageViewModel();
			hubBase = new HubBase();
			vm.ChatHub = hubBase;
			hubBase.Subscribers += vm.ReceiveMessagew;
			BindingContext = vm;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			
			await vm.OnAppearing();
		}
	}
}