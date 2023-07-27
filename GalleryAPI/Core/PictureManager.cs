using GalleryAPI.Core.Models;

namespace GalleryAPI.Core
{
    //Our "Database"
    public static class PictureManager
    {
        private static List<Picture> pictures;
        public static void GeneratePictureGallery()
        {
            pictures = new List<Picture>()
            {

                 new Picture("Forest","Beautiful Forest","Moyshe","Bertvthul.jpg"),
                 new Picture("SunsetTree","Beautiful Sunset Tree","Alex","Bessi.jpg"),
                 new Picture("LakeTree","Beautiful Lake Tree","Shara","Cleverpix.jpg"),
                 new Picture("Flowers","Beautiful Flowers","Ortal","Hans.jpg"),
                 new Picture("Grass","Morning Grass","Larisa","LarisaKoshkina.jpg"),
                 new Picture("Blue Butterflies","Amaizing Butterfliest","Sergey","Stergo.jpg"),
                 new Picture("Autumn Forest","Lovely Autumn Forest","Valentin","Valentin.jpg"),
                 new Picture("Golden Forest","Amazing Yellow Forest","Valerij","Valerij.jpg"),
            };
        }


        public static List<Picture> GetPictures()
        {
            return pictures;
        }
    }
}
