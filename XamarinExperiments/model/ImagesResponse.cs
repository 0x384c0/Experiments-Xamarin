using System;
namespace XamarinExperiments {
	public class ImagesResponse {
		public string kind;
		public Item[] items;
	}


	public class Item {
		public string kind;
		public string title;
		public Image image;
	}

	public class Image {
		public string thumbnailLink;
		public string contextLink;
	}
}

