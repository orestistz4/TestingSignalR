using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Models;

namespace TestingSignalR.Services
{
	public class ChatServer:HttpClientBase
	{
		public static string HostName = "http://192.168.1.174:45455/";





		public ChatServer():base(HostName)
		{

		}




		//edw kanw ta requests!!!
		//to ena einai otan kanw register ton user!!
		public async Task<string> RegisterUser(RegisterUserModel user)
		{


			var payload = JsonConvert.SerializeObject(user);
			return await PostRegister<string>(RequestMode.POST,"api/useraccount/registeruser",payload);




		}


		//loginUser
		public async Task<MobileUserServer> LoginUser(LoginUserModel user)
		{


			var payload = JsonConvert.SerializeObject(user);
			return await Post<MobileUserServer>("api/useraccount/loginuser", payload);




		}

		public async Task<MessageModel> SendMessage(MessageModel message)
		{


			var payload = JsonConvert.SerializeObject(message);
			return await Post<MessageModel>("api/home/sendmessage", payload);




		}
		public async Task<string> AddRoom(string roomName)
		{


			var payload = JsonConvert.SerializeObject(roomName);
			return await Post<string>("api/home/createroom", payload);




		}






	}
}
