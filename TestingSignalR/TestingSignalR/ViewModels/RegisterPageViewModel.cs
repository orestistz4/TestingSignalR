using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestingSignalR.Database;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using TestingSignalR.Services;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class RegisterPageViewModel:BaseViewModel
	{

		private ObservableCollection<string> errorList;
		public ObservableCollection<string> ErrorList { get { return errorList; } set { SetProperty(ref errorList,value); } }

		private ChatServer server;

		private bool emailError;
		public bool EmailError { get { return emailError; } set { SetProperty(ref emailError,value); } }

		private bool usernameError;
		public bool UsernameError { get { return usernameError; } set { SetProperty(ref usernameError, value); } }
		private bool passwordError;
		public bool PasswordError { get { return passwordError; } set { SetProperty(ref passwordError, value); } }
		private bool confirmPasswordError;
		public bool ConfirmPasswordError { get { return confirmPasswordError; } set { SetProperty(ref confirmPasswordError, value); } }

		private MobileUserDB database;


		private string email;
		public string Email { get { return email; } set { SetProperty(ref email,value); } }
		private string username;
		public string Username { get { return username; } set { SetProperty(ref username, value); } }
		private string password;
		public string Password { get { return password; } set { SetProperty(ref password,value); } }
		private string confirmPassword;
		public string ConfirmPassword { get { return confirmPassword; } set { SetProperty(ref confirmPassword,value); } }
		public Command	 BackCommand { get; set; }

		public Command RegisterCommand { get; set; }
		public RegisterPageViewModel()
		{
			BackCommand = new Command(async()=> {

				try {
					await Shell.Current.Navigation.PopModalAsync();
				}catch(Exception ex)
				{
					await App.Current.MainPage.Navigation.PopModalAsync();
				}


				});
			RegisterCommand = new Command(RegisterFunction);
			//RegisterCommand = new Command(async()=>await Shell.Current.Navigation.PushPopupAsync(new InfoPopup()));
			EmailError = false;
			UsernameError = false;
			PasswordError = false;
			ConfirmPasswordError = false;
			server = new ChatServer();
			ErrorList = new ObservableCollection<string>();
			database = new MobileUserDB();
			
		}


		private async void RegisterFunction()
		{
			//ErrorList = default(ObservableCollection<string>);

			if (validations())
			{

				var user = new RegisterUserModel() {UserName=Username,Password=Password,Email=Email };
				var error = await server.RegisterUser(user);
				if (error == null)
				{
					//registration is complete!!!!
					//ErrorList.Add("Register Succesfully");
					var temp_user = new MobileUser() { Email=user.Email,Username=user.UserName,Password=user.Password};
					//await database.createUser(temp_user);
					try {
						await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Info", "Account successfully created!!"));

					}
					catch (Exception ex) {

						await App.Current.MainPage.Navigation.PushPopupAsync(new InfoPopup("Info", "Account successfully created!!"));
					
					}
					
					
					
					
					return;
				}

				try {

					List<string> errorss = JsonConvert.DeserializeObject<List<string>>(error);

					var obsErrorss = new ObservableCollection<string>(errorss);
					ErrorList = obsErrorss;
				}
				catch (JsonException ex)
				{

					await App.Current.MainPage.Navigation.PushPopupAsync(new InfoPopup("Error", error));

				}
				
				

			}
			Console.WriteLine(Email);
			Console.WriteLine(Username);
			Console.WriteLine(Password);
			Console.WriteLine(ConfirmPassword);
			
		}

		private bool validations()
		{

			ErrorList.Clear();
			PasswordError = false;
			EmailError = false;
			UsernameError = false;
			if (Email==null|| !(Email.Contains("@")))
			{
				//den einai egkyro to email peta kapoio error
				EmailError = true;
				ErrorList.Add("Please input a valid email.");
				
				
			}
			if (Username==null|| Username.Length <= 2)
			{
				UsernameError = true;
				ErrorList.Add("Please input a username length greater than 2.");
				

			}

			if ((Password != ConfirmPassword)||(Password==null||ConfirmPassword==null))
			{
				PasswordError = true;
				ErrorList.Add("Password doesn't match.");
				
			}
			if (PasswordError || EmailError || UsernameError)
			{

				return false;
			}
			return true;
		}
	}
}
