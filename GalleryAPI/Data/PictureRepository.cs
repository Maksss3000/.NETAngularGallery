using GalleryAPI.Core;
using GalleryAPI.Core.Models;
using GalleryAPI.Core.Repositories;

namespace GalleryAPI.Data
{
    public class PictureRepository : IPictureRepository
    {
        public List<Picture> GetAllPictures()
        {
            return PictureManager.GetPictures();
        }

        public Picture GetPictureById(int pictureId)
        {
            List<Picture> pictures;

            pictures = PictureManager.GetPictures();

            if (!IsEmpty(pictures))
            {
                foreach (Picture picture in pictures)
                {

                    if (picture.Id == pictureId)
                        return picture;
                }
            }
            return null!;
        }

        //Search for pictures.
        public List<Picture> GetPicturesByQuery(string query)
        {
            List<Picture> pictures = new List<Picture>();
            pictures = PictureManager.GetPictures();

            List<Picture> foundedPictures = new List<Picture>();
            if (!IsEmpty(pictures))
            {
                foundedPictures = pictures
                .Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            p.ArtistName.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();
            }
            return foundedPictures;
        }



        private bool IsEmpty(List<Picture> pictures)
        {
            if (pictures != null && pictures.Count != 0)
                return false;

            return true;
        }
    }
}
