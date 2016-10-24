using ReactiveUI;

using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class GoogleImagesDetailPage : ContentPage, IViewFor<GoogleImagesDetailViewModel> {
		public GoogleImagesDetailPage(CellData data) {
			InitializeComponent();
			BindingContext = new GoogleImagesDetailViewModel(data);
		}



		//The rest of the code below is plumbing:

		public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(nameof(ViewModel), typeof(GoogleImagesDetailViewModel), typeof(LoginPage), null, BindingMode.OneWay);

		public GoogleImagesDetailViewModel ViewModel {
			get { return (GoogleImagesDetailViewModel)GetValue(ViewModelProperty); }
			set { SetValue(ViewModelProperty, value); }
		}

		object IViewFor.ViewModel {
			get { return ViewModel; }
			set { ViewModel = (GoogleImagesDetailViewModel)value; }
		}
	}
}
