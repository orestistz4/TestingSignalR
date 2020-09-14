




using Microsoft.AspNetCore.SignalR;
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
		public event EventHandler<string> PageAppear;
		public event EventHandler<string> Subscribers;
		public event EventHandler<List<ForexSymbol>> ForexSubscribers;
		public event EventHandler<MessageModel> Messages;

		public  async Task Init()
		{

			hubConnection = new HubConnectionBuilder().WithUrl("http://www.sasgamawre.online/messages").Build();
			//hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.42.234:51040/messages").Build();
			
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
		public async Task CustomePageAppear()
		{
			hubConnection.On<string>("AppearPage", (s) => {



				PageAppear?.Invoke(this, s);

			});

		}
		//init for a chat room!!!
		public async Task Init(string roomName)
		{
			hubConnection = new HubConnectionBuilder().WithUrl("http://www.sasgamawre.online/messages").Build();
			//hubConnection = new HubConnectionBuilder().WithUrl("http://192.168.42.234:51040/messages").Build();
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

		public async Task SendGroupMessage(string roomName,MessageModel message)
		{
			try
			{
				await hubConnection.InvokeAsync("SendToGroup", roomName,message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public async Task Disconnect()
		{
			if (hubConnection?.State == HubConnectionState.Disconnected) return;
			
			await hubConnection?.StopAsync();
		}



	}
}
