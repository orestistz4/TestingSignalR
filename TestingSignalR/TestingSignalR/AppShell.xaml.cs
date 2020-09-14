using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using TestingSignalR.Database;
using TestingSignalR.Hubs;
using TestingSignalR.Popups;
using TestingSignalR.Views;
using Xamarin.Forms;

namespace TestingSignalR
{
	public partial class AppShell : Xamarin.Forms.Shell
	{

		private MobileUserDB database;
		private HubBase hub;

		public AppShell()
		{
			InitializeComponent();
			database = new MobileUserDB();
			
			
		}


		

		public void onPageAppear(object sender,string message)
		{
			Console.WriteLine("trigger here!!");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			
		}



		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{


			try
			{
				await database.DropTable();
				App.CurrentUserEmail = null;
				App.Current.MainPage = new LoginPage();
			}catch(Exception ex)
			{
				await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error","Something went worng!"));
			}
			
			//await AppShell.Current.Navigation.PushModalAsync(new LoginPage());

		}
	}
}
