using GalleryAPI.Core.Models;

namespace GalleryAPI.Core.Repositories
{
    public interface IPictureRepository
    {

        List<Picture> GetAllPictures();

        Picture GetPictureById(int pictureId);

        List<Picture> GetPicturesByQuery(string query);
    }
}
