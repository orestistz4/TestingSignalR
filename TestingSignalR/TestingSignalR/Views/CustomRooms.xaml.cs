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
	public partial class CustomRooms : ContentPage
	{
		private CustomRoomsViewModel vm;
		public CustomRooms()
		{
			InitializeComponent();
			vm = new CustomRoomsViewModel();
			BindingContext = vm;
		}
	}
}