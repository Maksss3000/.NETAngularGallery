using GalleryAPI.Core.Models;
using GalleryAPI.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GalleryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPictureRepository _repository;

        //Injecting our Service , for working with our "repository" in our
        //case hardcodedList,in real life DB.
        
        public PicturesController(IPictureRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        //Endpoint to Get All Pictures.
        public ActionResult<List<Picture>> Pictures()
        {
            List<Picture> pictureList;
                
            pictureList=_repository.GetAllPictures();

            if (pictureList.Count == 0 || pictureList == null)
            {
                return NotFound();
            }
            return Ok(pictureList);
        }


        [HttpGet("{id}")]
        //Getting specific Picture.
        public ActionResult<Picture> Picture(int id)
        {
            Picture picture=_repository.GetPictureById(id);
            if (picture==null)
            {
                return NotFound(id);
            }

            return Ok(picture);
        }


        [HttpGet]
        [Route("search")]
        public ActionResult<List<Picture>> SearchPictures([FromQuery]string query)
        {
            return Ok(_repository.GetPicturesByQuery(query));
        }
    }
}
