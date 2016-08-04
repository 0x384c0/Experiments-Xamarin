using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinExperiments {
	public partial class DetailsPage : ContentPage {
		public DetailsPage() {
			InitializeComponent();
		}

		async void OnPreviousPageButtonClicked(object sender, EventArgs e) {
			await Navigation.PopAsync();
		}
	}
}

