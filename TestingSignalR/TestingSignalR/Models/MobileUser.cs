using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSignalR.Models
{
	public class MobileUser
	{
		[PrimaryKeyAttribute,AutoIncrement]
		public int Id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

	}
}
