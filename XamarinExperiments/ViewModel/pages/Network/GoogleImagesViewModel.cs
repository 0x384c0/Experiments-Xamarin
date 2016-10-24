using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;
using System.Diagnostics;

namespace XamarinExperiments {
	public class GoogleImagesViewModel : BaseViewModel {
		public GoogleImagesViewModel() {
			setupBindings();
			SearchText = "Google";
		}

		void setupBindings() {
			searchEntryObservable = this.WhenAnyValue(x => x.SearchText);

			_refreshCommand = new Command(() => {
				//IsRefreshing = true;
				loadImages(() => { IsRefreshing = false; return 0; });
			});

			searchEntryObservable
				.Throttle(TimeSpan.FromMilliseconds(500))
				.Subscribe(inp => _refreshCommand.Execute(null));
		}



		void loadImages(Func<int> complete) {
			Debug.WriteLine("_searchText " + _searchText);
			if (_searchText == null || _searchText == "") {
				ItemsSource.Clear();
				return;
			}

			GoogleImagesService
				.searchImages(_searchText)
				.Subscribe(images => {
					var itemsSource = new ObservableCollection<CellData>();
					foreach (var item in images.items) {
						var cellData = new CellData {
							image = item.image.thumbnailLink,
							title = item.title,
							subtitle = _searchText
						};
						itemsSource.Add(cellData);
					}
					ItemsSource = itemsSource;
				});

			//ItemsSource = new ObservableCollection<CellData>{
			//	new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 11",subtitle = _searchText},
			//	new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 2",subtitle = _searchText},
			//	new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 3",subtitle = _searchText},
			//};
			complete();
		}



		//Bindings
		IObservable<string> searchEntryObservable;

		ObservableCollection<CellData> _itemsSource;
		public ObservableCollection<CellData> ItemsSource {
			get { return _itemsSource; }
			set { this.RaiseAndSetIfChanged(ref _itemsSource, value); }
		}

		string _searchText;
		public string SearchText {
			get { return _searchText; }
			set { this.RaiseAndSetIfChanged(ref _searchText, value); }
		}

		bool _isRefreshing;
		public bool IsRefreshing {
			get { return _isRefreshing; }
			set { this.RaiseAndSetIfChanged(ref _isRefreshing, value); }
		}

		Command _refreshCommand;
		public Command RefreshCommand {
			get { return _refreshCommand; }
		}
	}
}

