using ReactiveUI;
using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class GoogleImagesPage : ContentPage, IViewFor<GoogleImagesViewModel> {
		public GoogleImagesPage() {
			InitializeComponent();
			BindingContext = new GoogleImagesViewModel();

			//Observable.FromEventPattern(this.searchEntry, "TextChanged")
			//		  .Throttle(TimeSpan.FromMilliseconds(500))
			//		  .Subscribe(inp => Debug.WriteLine("User wrote: " + ((Entry)inp.Sender).Text));
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event

			Navigation.PushAsync(new GoogleImagesDetailPage(((CellData)e.SelectedItem)));

			((ListView)sender).SelectedItem = null; // de-select the row
		}

		//The rest of the code below is plumbing:

		public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(GoogleImagesViewModel), typeof(LoginPage), null, BindingMode.OneWay);

		public GoogleImagesViewModel ViewModel {
			get { return (GoogleImagesViewModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (GoogleImagesViewModel)value; }
		}
	}
}

