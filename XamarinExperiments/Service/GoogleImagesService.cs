using System;

namespace XamarinExperiments {
	public class GoogleImagesService : BaseRestService {
		public static IObservable<ImagesResponse> searchImages(string query) {
			return getHttpClientObservable<ImagesResponse>("https://www.googleapis.com/customsearch/v1", "?alt=json&cx=013770233867257397766%3Ae7fh4k86up8&key=AIzaSyD-qVniTDTaTWgqkBpbCb38LsLR-Rxj9e4&q=" + query + "&searchType=image&start=1");
		}
	}

}

