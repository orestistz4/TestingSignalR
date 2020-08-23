using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestingSignalR.Database;
using TestingSignalR.Droid.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnection))]
namespace TestingSignalR.Droid.Database
{
	public class SqlConnection : ISqlConnection
	{
		public SQLiteAsyncConnection Connection()
		{
			//auto to path einai gia to Android!!!
			var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath,"MySQLite.sqldb");
			return new SQLiteAsyncConnection(path);
		}
	}
}