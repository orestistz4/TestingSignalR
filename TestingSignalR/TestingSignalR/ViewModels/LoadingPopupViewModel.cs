using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestingSignalR.ViewModels
{
	public class LoadingPopupViewModel:BaseViewModel
	{


		public Command ClosePopup { get; set; }

		private int rotationAnimation;
		public int RotationAnimation { get { return rotationAnimation; } set { SetProperty(ref rotationAnimation,value); } }


		private bool firstDot;
		public bool FirstDot { get { return firstDot; } set { SetProperty(ref firstDot,value); } }
		private bool secondDot;
		public bool SecondDot { get { return secondDot; } set { SetProperty(ref secondDot,value); } }
		private bool thirdDot;
		public bool ThirdDot { get { return thirdDot; } set { SetProperty(ref thirdDot, value); } }




		public LoadingPopupViewModel()
		{


			ClosePopup = new Command(async () => await Shell.Current.Navigation.PopPopupAsync()); 

		}




		public async Task onAppearing()
		{



			while (true) { 
				
				FirstDot = true;
				SecondDot = false;
				ThirdDot = false;
				Thread.Sleep(500);
				FirstDot = false;
				SecondDot = true;
				ThirdDot = false;
				Thread.Sleep(500);
				FirstDot = false;
				SecondDot = false;
				ThirdDot = true;
				Thread.Sleep(500);
			}




		}


	}
}
