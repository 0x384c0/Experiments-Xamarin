using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactiveUI;
namespace XamarinExperiments {
	public class BaseRestService {

		public static IObservable<T> getHttpClientObservable<T>(string baseAddress, string query) {
			//LoggingMessageHandler handler = new LoggingMessageHandler(new HttpClientHandler());
			//HttpClient client = new HttpClient(handler);
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
			client.BaseAddress = new Uri(baseAddress);


			var observable = Observable
				.Create((IObserver<T> arg) => {
					//Task.Delay(5000).Wait();
					var result = client
						.GetAsync(query)
						.Result;
					var content = result.Content.ReadAsStringAsync().Result;
					var user = JsonConvert.DeserializeObject<T>(content);
					arg.OnNext(user);
					arg.OnCompleted();
					return Disposable.Empty;
				})
				.SubscribeOn(Scheduler.Default)
				.ObserveOn(RxApp.MainThreadScheduler);
			return observable;
		}


		public class LoggingMessageHandler : DelegatingHandler {
			public LoggingMessageHandler(HttpMessageHandler innerHandler)
				: base(innerHandler) {
			}

			protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
				Debug.WriteLine("Request:");
				Debug.WriteLine(request.ToString());
				if (request.Content != null) {
					Debug.WriteLine(await request.Content.ReadAsStringAsync());
				}

				var response = await base.SendAsync(request, cancellationToken);

				Debug.WriteLine("Response:");
				Debug.WriteLine(response.ToString());
				if (response.Content != null) {
					Debug.WriteLine(await response.Content.ReadAsStringAsync());
				}

				return response;
			}
		}
	}
}