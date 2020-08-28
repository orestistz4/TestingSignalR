using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSignalR.Exceptions
{
	public class NoInternetException:Exception
	{

		

		public NoInternetException(string message) : base(message)
		{
			
		}

	}
}
