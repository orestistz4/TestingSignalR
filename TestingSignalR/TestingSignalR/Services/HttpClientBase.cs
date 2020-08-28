using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestingSignalR.Exceptions;
using TestingSignalR.Models;

namespace TestingSignalR.Services
{
	public class HttpClientBase
	{

		public enum RequestMode
		{
			GET,
			POST
		}

		public string HostName { get; set; }

		public HttpClient Client { get; set; }

		public HttpClientBase(string host)
		{

			HostName = host;
			Client = new HttpClient();

		}


		//ftia3e diaforous functions gia get kai post requests!!!


		//exw ws default to payload na einai empty string giati sto get dn xreiazetai payload kapoies fores!!
		public async Task<T> Request<T>(RequestMode mode,string urlPar,string payload="")
		{

			
				

			try
			{
				if (!CrossConnectivity.Current.IsConnected)
				{
					throw new NoInternetException("Please check your Internet Connection...");
				}
				string url = HostName + urlPar;

				using (var result=(mode==RequestMode.GET)?await Client.GetAsync(url):await Client.PostAsync(url,new StringContent(payload, Encoding.UTF8, "application/json")))
				{

					string resultsContent = await result.Content.ReadAsStringAsync();
					if (result.IsSuccessStatusCode)
					{
						var resultObj = JsonConvert.DeserializeObject<T>(resultsContent);
						return resultObj;
					}
					else
					{
						Console.WriteLine("sth happend");
						return default(T);
					}

				}
			}
			catch(NoInternetException ex)
			{
				return default(T);

			}
			catch(Exception ex)
			{
				
				Console.WriteLine("sth happend");
				return default(T);


			}

		}
		protected async Task<T> Get<T>(string urlPar)
		{
			return await Request<T>(RequestMode.GET, urlPar);
		}

		protected async Task<T> Post<T>(string urlPar, string payload)
		{
			return await Request<T>(RequestMode.POST, urlPar, payload);
		}



		protected async Task<T> PostRegister<T>(RequestMode mode, string urlPar, string payload = "")
		{
			try
			{
				string url = HostName + urlPar;

				using (var result = (mode == RequestMode.GET) ? await Client.GetAsync(url) : await Client.PostAsync(url, new StringContent(payload, Encoding.UTF8, "application/json")))
				{

					string resultsContent = await result.Content.ReadAsStringAsync();
					if (result.IsSuccessStatusCode)
					{
						//var resultObj = JsonConvert.DeserializeObject<T>(resultsContent);
						return default(T);
					}
					else
					{
						var resultObj = JsonConvert.DeserializeObject<ErrorModel>(resultsContent);
						throw new ErrorModelException(resultObj);
						Console.WriteLine("sth happend");
						//T tempValue = (T)(object)resultsContent;
						return (T)(object)resultsContent;
					}

				}
			}

			catch(ErrorModelException ex)
			{
				return (T)(object)ex.Message;
			}
			catch (Exception ex)
			{

				Console.WriteLine("sth happend");
				return (T)(object)ex.Message;


			}
		}


	}
}
