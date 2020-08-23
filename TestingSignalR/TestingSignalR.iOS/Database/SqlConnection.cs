using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using TestingSignalR.Database;
using TestingSignalR.iOS.Database;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlConnection))]
namespace TestingSignalR.iOS.Database
{
	public class SqlConnection:ISqlConnection
	{
        public SQLiteAsyncConnection Connection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.sqldb");

            return new SQLiteAsyncConnection(path);
        }
    }
}