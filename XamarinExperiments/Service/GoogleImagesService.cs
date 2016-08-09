using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinExperiments {
	public class GoogleImagesService {
		public static IObservable<ImagesResponse> searchImages(string query) {
			return BaseRestService.GetResources<ImagesResponse>();
		}
	}


	class BaseRestService {
		public static IObservable<T> GetResources<T>() {
			throw new NotImplementedException();
		}
	}

}

