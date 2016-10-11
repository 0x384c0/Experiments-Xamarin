using System;
using ReactiveUI;

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

		void load() {
			Email = "-> Loading...";

			IObservable<User> observable = GithubService.getUser("users/octocat");
			observable
				.Subscribe(user => {
					Email = user.Name;
					//Application.Current.MainPage.DisplayAlert("ActionSheet: SavePhoto?", user.Name, "Delete");
				});

		}
	}

}

