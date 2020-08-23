using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestingSignalR.Modals
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPageView : ContentPage
	{

		private RegisterPageViewModel vm;
		public RegisterPageView()
		{
			InitializeComponent();
			vm = new RegisterPageViewModel();
			BindingContext = vm;
		}
	}
}