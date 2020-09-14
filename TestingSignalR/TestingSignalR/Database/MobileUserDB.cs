using Rg.Plugins.Popup.Extensions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;
using TestingSignalR.Popups;
using Xamarin.Forms;

namespace TestingSignalR.Database
{
	public class MobileUserDB
	{


		private SQLiteAsyncConnection _sqlconnection;

		public MobileUserDB()
		{
			//Getting connection and Creating table
			_sqlconnection = DependencyService.Get<ISqlConnection>().Connection();
			//ftiaxnw to table!!!
			_sqlconnection.CreateTableAsync<MobileUser>();
		}


		//add a user if it is not exist in the database

		public async Task<MobileUser> checkUser(string email)
		{

			var user =  await _sqlconnection.Table<MobileUser>().FirstOrDefaultAsync(c=>c.Email==email);
			if (user != null)
			{
				//pairnw to pass edw pera kai to stelnw sto  server mou na kanei signin!!!
				return user;
			}
			else
			{
				return null;
			}


		}

		public async Task<bool> createUser(MobileUser currentUser)
		{

			var user = await _sqlconnection.Table<MobileUser>().FirstOrDefaultAsync(c => c.Email == currentUser.Email);
			if (user != null)
			{
				//pairnw to pass edw pera kai to stelnw sto  server mou na kanei signin!!!
				return false;
			}
			else
			{
				await _sqlconnection.InsertAsync(currentUser);
				var list1=await _sqlconnection.Table<MobileUser>().ToListAsync();
				return true;
			}


		}

		//tsekare ama yparxei o user!!!
		public async Task<MobileUser> checkIfUserExists()
		{
			try { 

			var user = await _sqlconnection.Table<MobileUser>().ToListAsync();
			if (user != null || user.Count!=0)
			{
				var savedUser = user.Last();
				return savedUser;
			}
			else
			{
				return default(MobileUser);
			}
		}
			catch(Exception ex)
			{
				Console.WriteLine("sth happend");
				//dn 8a tou lew tsekare to connection apla kane to mainpage na einai 3ana to loginpage!!!
				return default(MobileUser);
			}
		}

		public async Task DropTable()
		{
			try
			{

				var result = await _sqlconnection.DropTableAsync<MobileUser>();


			}catch(Exception ex)
			{
				try
				{
					await Shell.Current.Navigation.PushPopupAsync(new InfoPopup("Info","Logout successfully."));
				}
				catch (NullReferenceException exx)
				{
					await App.Current.MainPage.Navigation.PushPopupAsync(new InfoPopup("Info", "Logout successfully."));
				}
			}
		}



	}
}
