using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using Refit;

namespace XamarinExperiments {
	public class LoginViewModel : ReactiveObject {
		public ReactiveCommand<System.Reactive.Unit> Login { get; protected set; }

		string _email;
		public string Email {
			get { return _email; }
			set { this.RaiseAndSetIfChanged(ref _email, value); }
		}

		string _password;
		public string Password {
			get { return _password; }
			set { this.RaiseAndSetIfChanged(ref _password, value); }
		}

		readonly ObservableAsPropertyHelper<bool> _isLoading;
		public bool IsLoading {
			get { return _isLoading.Value; }
		}


		public LoginViewModel() {
			load();
		}

		async void load() {
			LoggingMessageHandler handler = new LoggingMessageHandler(new HttpClientHandler());
			HttpClient client = new HttpClient(handler);
			client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");
			client.BaseAddress = new Uri("https://api.github.com");
			IGitHubApi gitHubApi = RestService.For<IGitHubApi>(client);//("https://api.github.com");
			Debug.WriteLine("gitHubApi.GetUser(\"octocat\")");
			var user = await gitHubApi.GetUser("octocat");

			Debug.WriteLine("USER - " + user.Name);
		}
	}


	public interface IGitHubApi {
		[Get("/users/{user}")]
		Task<User> GetUser(string user);
	}


	public class User {
		public string Login { get; set; }
		public int Id { get; set; }
		public string AvatarUrl { get; set; }
		public string GravatarId { get; set; }
		public string Url { get; set; }
		public string HtmlUrl { get; set; }
		public string FollowersUrl { get; set; }
		public string FollowingUrl { get; set; }
		public string GistsUrl { get; set; }
		public string StarredUrl { get; set; }
		public string SubscriptionsUrl { get; set; }
		public string OrganizationsUrl { get; set; }
		public string ReposUrl { get; set; }
		public string EventsUrl { get; set; }
		public string ReceivedEventsUrl { get; set; }
		public string Type { get; set; }
		public string Name { get; set; }
		public string Company { get; set; }
		public string Blog { get; set; }
		public string Location { get; set; }
		public string Email { get; set; }
		public bool? Hireable { get; set; }
		public string Bio { get; set; }
		public int PublicRepos { get; set; }
		public int Followers { get; set; }
		public int Following { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public int PublicGists { get; set; }
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

