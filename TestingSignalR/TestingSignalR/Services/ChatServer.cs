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
		public static string HostName = "http://www.sasgamawre.online/";
		//public static string HostName = "http://192.168.42.234:51040/";
		//public static string HostName = "http://192.168.1.174:45456/";
		
		


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

		public async Task<bool?> JoinRoom(string roomName)
		{


			var payload = JsonConvert.SerializeObject(roomName);
			return await Post<bool?>("api/home/joinroom", payload);




		}
		

			public async Task<ResponseModel> CreateUserRoom(UserRoom room)
		{


			var payload = JsonConvert.SerializeObject(room);
			return await Post<ResponseModel>("api/home/createuserroom", payload);




		}

		
				public async Task<List<UserRoom>> GetUserRooms(string email)
				{
			var payload = JsonConvert.SerializeObject(email);
			return await Post<List<UserRoom>>("api/home/getuserrooms", payload);
		}

		public async Task<ResponseModel> DeleteUserRoom(UserRoom room)
		{
			var payload = JsonConvert.SerializeObject(room);
			return await Post<ResponseModel>("api/home/deleteuserroom", payload);
		}

		public async Task<List<GroupMessages>> GetGroypMessages(string room)
		{
			var payload = JsonConvert.SerializeObject(room);
			return await Post<List<GroupMessages>>("api/home/getgroupmessages", payload);
		}


		public async Task<ResponseModel> SendGroupMessage(MessageModel messageModel)
		{
			var payload = JsonConvert.SerializeObject(messageModel);
			return await Post<ResponseModel>("api/home/sendmessage", payload);
		}

	}
}
