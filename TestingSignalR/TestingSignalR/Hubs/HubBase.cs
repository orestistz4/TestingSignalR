




using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;
using Xamarin.Essentials;

namespace TestingSignalR.Hubs
{
	public class HubBase
	{
		public  HubConnection hubConnection;
		//kanw 2 function
		//ena pou 8a kanei 

		public event EventHandler<string> Subscribers;
		public event EventHandler<List<ForexSymbol>> ForexSubscribers;
		public event EventHandler<MessageModel> Messages;

		public  async Task Init()
		{

			hubConnection = new HubConnectionBuilder().WithUrl("http://www.sasgamawre.online/messages").Build();
			
			hubConnection.On<string>("ReceiveMessage", (s) =>
			{


				Console.WriteLine(s);
				Subscribers?.Invoke(this,s);

			});


			hubConnection.On<List<ForexSymbol>>("ReceiveObject", (s) =>
			{


				Console.WriteLine(s);
				ForexSubscribers?.Invoke(this, s);

			});



		}

		//init for a chat room!!!
		public async Task Init(string roomName)
		{
			hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.1.174:45455/messages").Build();
			hubConnection.On<MessageModel>(roomName, (s) => {

				Console.WriteLine(s);

				Messages?.Invoke(this,s);
			
			});
		}

		//Join group!!!
		public async Task JoinGroup(string roomName)
		{
			try
			{
				await hubConnection.InvokeAsync("Join",roomName);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

	

	}
}
