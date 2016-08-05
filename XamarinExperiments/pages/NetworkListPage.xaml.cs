using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class NetworkListPage : ContentPage {
		const string 
		G_IMAGES_TITLE = "Google Images",
		G_IMAGES_TITLE_NON_MODAL = "Google Images NON_MODAL";


		public NetworkListPage() {
			InitializeComponent();
			listView.ItemsSource = new CellData[]{
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = G_IMAGES_TITLE,subtitle ="subtitle 1"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = G_IMAGES_TITLE_NON_MODAL,subtitle ="subtitle 2"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "title 3",subtitle ="subtitle 3"},
			};
		}


		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			string title = ((CellData)e.SelectedItem).title;
			((ListView)sender).SelectedItem = null; // de-select the row

			switch (title) {
				case G_IMAGES_TITLE:
					Navigation.PushModalAsync(new NavigationPage(new GoogleImagesPage()));
					break;
					
				case G_IMAGES_TITLE_NON_MODAL:
					Navigation.PushAsync(new GoogleImagesPage());
					break;

				default:
					DisplayAlert("Tapped", title + " row was tapped", "OK");
					break;
			}
		}

	}



	class CellData {
		public string image { get; set; }
		public string title { get; set; }
		public string subtitle { get; set; }
	}
}

