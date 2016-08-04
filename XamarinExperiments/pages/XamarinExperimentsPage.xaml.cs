using System;
using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class XamarinExperimentsPage : ContentPage {
		public XamarinExperimentsPage() {
			InitializeComponent();
		}
		async void OnNextPageButtonClicked(object sender, EventArgs e) {
			await Navigation.PushAsync(new DetailsPage());
		}
	}
}

