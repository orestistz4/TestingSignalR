using System;
using System.Collections.Generic;
using System.Text;
using TestingSignalR.Models;

namespace TestingSignalR.Exceptions
{
	public class ErrorModelException:Exception
	{

		public ErrorModelException(ErrorModel model):base(model.ErrorMessage)
		{

		}


	}
}
