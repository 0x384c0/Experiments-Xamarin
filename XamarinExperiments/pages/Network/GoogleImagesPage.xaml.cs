using System;
using System.Diagnostics;

using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class GoogleImagesPage : ContentPage {
		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e) {
			Entry entry = (Entry) sender;
			Debug.WriteLine(entry.Text);
		}

		public GoogleImagesPage() {
			InitializeComponent();
			listView.ItemsSource = new CellData[]{
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 1",subtitle ="subtitle 1"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 2",subtitle ="subtitle 2"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "image 3",subtitle ="subtitle 3"},
			};
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			((ListView)sender).SelectedItem = null; // de-select the row
			Navigation.PushAsync(new GoogleImagesDetailPage());
		}
	}
}

