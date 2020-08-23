using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Hubs;
using TestingSignalR.Models;

namespace TestingSignalR.ViewModels
{
	public class ForexChatViewModel:BaseViewModel
	{

		private string name;
		public string Name { get { return name; } set { SetProperty(ref name,value); } }


		private string bid;
		public string Bid { get { return bid; } set { SetProperty(ref bid,value); } }

		private string ask;
		public string Ask { get { return ask; } set { SetProperty(ref ask,value); } }
		private string high;
		public string High { get { return high; } set { SetProperty(ref high,value); } }
		private string low;
		public string Low { get { return low; } set { SetProperty(ref low,value); } }

		private string chg;
		public string Chg { get { return chg; } set { SetProperty(ref chg,value); } }



		private ObservableCollection<ForexSymbol> forexList;
		public ObservableCollection<ForexSymbol> ForexList { get { return forexList; } set { SetProperty(ref forexList,value); } }

		public HubBase ChatHub { get; set; }


		public ForexChatViewModel()
		{
			ForexList = new ObservableCollection<ForexSymbol>();

		}

		public async Task OnAppearing()
		{
			try
			{
				await ChatHub.Init();
				await ChatHub.hubConnection.StartAsync();
			} catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.Message);
			}

			Console.WriteLine("");


		}

		public void ReceiveForexSymbols(object sender, List<ForexSymbol> s)
		{
			ForexList = new ObservableCollection<ForexSymbol>(s);
			Name = s[0].Name;
			Ask = s[0].Ask;
			Bid = s[0].Bid;
			High = s[0].High;
			Low = s[0].Low;
			Chg = s[0].Chg;

		}




	}
}
