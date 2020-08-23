using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Hubs;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class ChatPageViewModel:BaseViewModel
	{


		public Command ClearCommand { get; set; }

		private ObservableCollection<string> listItems;
		public ObservableCollection<string> ListItems { get { return listItems; } set { SetProperty(ref listItems,value); } }

		public HubBase ChatHub { get; set; }

		public Command SendCommand { get; set; }

		public ChatPageViewModel()
		{
			ListItems = new ObservableCollection<string>();
			
			SendCommand = new Command(async()=>await SendFunction());
			ClearCommand = new Command(()=>ListItems.Clear());
		}

		public async Task OnAppearing()
		{
			
			await ChatHub.Init();
			Console.WriteLine("");
			

		}

		public void ReceiveMessagew(object sender,string s)
		{
			ListItems.Add(s);

		}


		private	async	Task SendFunction()
		{
			if (ChatHub.hubConnection.State == HubConnectionState.Disconnected)
			{
				try
				{
					await ChatHub.hubConnection.StartAsync();
					await ChatHub.hubConnection.SendAsync("SendMessageToAll","hey stranger");
				}
				catch (Exception ex)
				{
					Console.WriteLine("sth happend");
				}

			}
			else
			{
				await ChatHub.hubConnection.SendAsync("SendMessageToAll", "hey stranger2");
			Console.WriteLine("");
			}
		}




	}
}
