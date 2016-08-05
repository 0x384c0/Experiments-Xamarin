using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class NetworkListPage : ContentPage {
		public NetworkListPage() {
			InitializeComponent();
			listView.ItemsSource = new CellData[]{
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "title 1",subtitle ="subtitle 1"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "title 2",subtitle ="subtitle 2"},
				new CellData { image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/53/Google_%22G%22_Logo.svg/1024px-Google_%22G%22_Logo.svg.png", title = "title 3",subtitle ="subtitle 3"},
			};
		}


		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
			if (e.SelectedItem == null) return; // has been set to null, do not 'process' tapped event
			DisplayAlert("Tapped", ((CellData)e.SelectedItem).title + " row was tapped", "OK");
			((ListView)sender).SelectedItem = null; // de-select the row
		}

	}



	class CellData {
		public string image { get; set; }
		public string title { get; set; }
		public string subtitle { get; set; }
	}
}

