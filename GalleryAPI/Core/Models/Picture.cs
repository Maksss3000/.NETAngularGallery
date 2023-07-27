namespace GalleryAPI.Core.Models
{
    public class Picture
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Description { get; init; }

        public string ArtistName { get; init; }


        private string imgPath;
        private static int nextId = 1;

        public string ImgPath
        {
            get { return imgPath; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Image Path cannot be null or empty", nameof(ImgPath));
                }
                imgPath = value;
            }
        }

        public Picture(string title, string description, string artistName, string imgPath)
        {
            Id = nextId++;

            Title = title;
            Description = description;
            ArtistName = artistName;
            ImgPath = imgPath;
        }


    }

}
