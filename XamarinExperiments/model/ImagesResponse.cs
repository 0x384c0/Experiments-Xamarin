using System;
namespace XamarinExperiments {
	public class ImagesResponse {
		string kind;
		Item[] items;
	}


	class Item {
		string kind;
		string title;
		Image image;
	}

	class Image {
		string thumbnailLink;
		string contextLink;
	}
}

