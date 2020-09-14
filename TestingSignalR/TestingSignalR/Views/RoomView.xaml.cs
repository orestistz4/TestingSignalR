using Microsoft.AspNetCore.SignalR;
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
	public partial class RoomView : ContentPage
	{
		private HubBase hubBase;
		private RoomViewModel vm;

		public RoomView(string roomName)
		{
			
			InitializeComponent();
			hubBase = new HubBase();
			vm = new RoomViewModel(roomName);
			this.Title = roomName;
			vm.ChatHub = hubBase;
			vm.ChatHub.Messages += vm.ReceiveMessage;
			
			BindingContext = vm;

			

		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			Shell.SetTabBarIsVisible(this, false);
			await vm.onAppearing();

			
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Shell.SetTabBarIsVisible(this, true);
		}
	}
}