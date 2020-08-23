using System;
using System.Collections.Generic;
using System.Text;
using TestingSignalR.Database;
using TestingSignalR.Modals;
using TestingSignalR.Models;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class LoginPageViewModel:BaseViewModel
	{



		private ChatServer server;

		private MobileUserDB database;
		private string email;
		public string Email { get { return email; } set { SetProperty(ref email,value); } }
		private string password;
		public string Password { get { return password; } set { SetProperty(ref password,value); } }
		private string confirmPassword;
		public string ConfirmPassword { get { return confirmPassword; } set { SetProperty(ref confirmPassword,value); } }
		private string username;
		public string Username { get { return username; } set { SetProperty(ref username,value); } }

		public Command	 CreateCommand { get; set; }
		public Command CheckUserCommand { get; set; }

		
		public Command CreateAccount { get; set; }
		public LoginPageViewModel()
		{
			server = new ChatServer();
			CreateCommand = new Command(CreateFunction);
			database = new MobileUserDB();
			CheckUserCommand = new Command(CheckUser);
			CreateAccount = new Command(async()=>await Shell.Current.Navigation.PushModalAsync(new RegisterPageView()));

		}

		private async void CreateFunction()
		{

			Console.WriteLine(Email);
			Console.WriteLine(Username);
			Console.WriteLine(Password);
			Console.WriteLine(ConfirmPassword);
			var user = new MobileUser() { Email=Email,Username=Username,Password=Password};
			var userr = new RegisterUserModel() { Email=Email,UserName=Username,Password=Password};
			await database.createUser(user);
			await server.RegisterUser(userr);
			Console.WriteLine("adadsf");


		}

		private async void CheckUser()
		{

			var user = new LoginUserModel() { Email=Email,Password=Password,RememberMe=true};
			var result = await server.LoginUser(user);
			if (result == default(MobileUserServer))
			{
				//peta tou popup oti kanei egine alani
			}
			Console.WriteLine("");
			Console.WriteLine("");

		}

	}
}
