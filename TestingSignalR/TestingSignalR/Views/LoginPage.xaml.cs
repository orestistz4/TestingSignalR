using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingSignalR.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{


		private LoginPageViewModel vm;
		public LoginPage()
		{
			InitializeComponent();
			vm = new LoginPageViewModel();
			BindingContext = vm;
		}

	
	}
}