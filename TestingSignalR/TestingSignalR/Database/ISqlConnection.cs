using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSignalR.Database
{
	public interface ISqlConnection
	{


		SQLiteAsyncConnection Connection();


	}
}
