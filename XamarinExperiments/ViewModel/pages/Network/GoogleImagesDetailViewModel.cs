using ReactiveUI;
namespace XamarinExperiments {
	public class GoogleImagesDetailViewModel : BaseViewModel {

		public GoogleImagesDetailViewModel(CellData data) {
			_image = data.image;
			_title = data.title;
			_subtitle = data.subtitle;
		}


		string _image;
		public string image {
			get { return _image; }
			set { this.RaiseAndSetIfChanged(ref _image, value); }
		}
		string _title;
		public string title {
			get { return _title; }
			set { this.RaiseAndSetIfChanged(ref _title, value); }
		}
		string _subtitle;
		public string subtitle {
			get { return _subtitle; }
			set { this.RaiseAndSetIfChanged(ref _subtitle, value); }
		}
	}
}
