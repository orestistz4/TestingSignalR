using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TestingSignalR.Database;
using TestingSignalR.Modals;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class LoginPageViewModel:BaseViewModel
	{

		private bool isChecked;
		public bool IsChecked { get { return isChecked; } set { SetProperty(ref isChecked,value); } }


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
			//CreateCommand = new Command(CreateFunction);
			CreateCommand = new Command(async()=>await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("The description","The message")));
			database = new MobileUserDB();
			CheckUserCommand = new Command(CheckUser);
			CreateAccount = new Command(async()=> {

				try
				{
					await Shell.Current.Navigation.PushModalAsync(new RegisterPageView());
				}catch(Exception ex)
				{
					await App.Current.MainPage.Navigation.PushModalAsync(new RegisterPageView());
					Console.WriteLine("");
					Console.WriteLine(ex.Message);
				}


			});

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
				//edw to login einai unsuccesfull
				try
				{
					await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Error", "Something went wrong please enter valid credentials!"));
				}
				catch(NullReferenceException ex)
				{
					await App.Current.MainPage.Navigation.PushPopupAsync(new InfoPopup("Error", "Something went wrong please enter valid credentials!"));
				}
			}
			else
			{
				//successful login!!! kane kati
				if (IsChecked)
				{
					var user_temp = new MobileUser() { Email=user.Email,Password=user.Password};
					try
					{

					
					await database.createUser(user_temp);
						App.CurrentUserEmail = user_temp.Email;
					}
					catch(Exception ex)
					{
						await App.Current.MainPage.Navigation.PushPopupAsync(new InfoPopup("Error","Couldnt save user in the localdb!"));
					}
				}
				App.CurrentUserEmail = user.Email;
				App.Current.MainPage = new AppShell();

			}
			Console.WriteLine("");
			Console.WriteLine("");

		}

	}
}
