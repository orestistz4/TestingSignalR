using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestingSignalR.Services;
using TestingSignalR.Views;
using TestingSignalR.Database;
using System.Threading.Tasks;
using TestingSignalR.Models;

namespace TestingSignalR
{
	public partial class App : Application
	{


		public static string CurrentUserEmail;

		private MobileUserDB database;

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			database = new MobileUserDB();
			//MainPage = new AppShell();
		}

		protected async override void OnStart()
		{
			try
			{
				MainPage = new LoginPage();
				//MainPage = new AppShell();			
				var user = await database.checkIfUserExists();
				App.CurrentUserEmail = user.Email;
				if (user != default(MobileUser))
				{
					MainPage = new AppShell();
				}
				else
				{
					MainPage = new LoginPage();
				}

				
			}
			catch (Exception ex)
			{

			}
			
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
