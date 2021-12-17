using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XMUER.Common.Infrastructure;
using XMUER.Models.Home;
using XMUER.Models.ModelsList;
using XMUER.Service.Interface;

namespace XMUER.Controllers
{
    [Route("/home/[controller]")]
    [ApiController]
    public class AlbumController : Controller
    {
        protected IAlbumService AlbumService;
        protected IPhotoService PhotoService;

        public AlbumController(IAlbumService albumService, IPhotoService photoService)
        {
            AlbumService = albumService;
            PhotoService = photoService;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UploadPhoto(int id, IFormFile iFormFile)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }

            Message message = new Message();
            if (iFormFile == null || iFormFile.Length == 0)
                return new JsonResult(new Message((int)MessageCode.UPLOAD_FILE_EMPTY,
                    MessageCode.UPLOAD_FILE_EMPTY.GetDescription()));
            var filePath = "wwwroot/album/" + iFormFile.FileName;
            //Console.WriteLine(filePath);
            //Console.WriteLine(iFormFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await iFormFile.CopyToAsync(stream);
            }
            Photo photo = new Photo();
            photo.Picture = "~/album/" + iFormFile.FileName;
            photo.AlbumID = id;

            //Album album = AlbumService.GetAlbumByID(id);
            //AlbumService.ModefiyAlbumPictureByID(id, photo.Picture);
            message = PhotoService.CreatePhoto(photo);
            return new JsonResult(message);
        }

        // 修改相册
        [HttpPut("{id}")]
        public ActionResult<Message> modifyAlbum(int id, [FromForm] string albumName, [FromForm] string albumPageUrl)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }
            Message msg = AlbumService.ModifiyAlbumPictureByID(id, albumPageUrl, albumName);
            return new JsonResult(msg);
            //return AlbumService.ModifiyAlbumPictureByID(id, albumPageUrl, albumName);
        }

        // 删除照片
        [HttpDelete("delphoto/{pid}")]
        public ActionResult<Message> delPhoto(int pid)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }

            // 从实际文件夹中删除对应图片
            Photo photo = PhotoService.GetPhotoById(pid);
            string photoPath = photo.Picture;
            string tmpPath = photoPath.Substring(2);
            string actualPath = "wwwroot//" + tmpPath;

            try
            {
                System.IO.File.Delete(actualPath);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            Message msg = PhotoService.DeletePhotoById(pid);
            return new JsonResult(msg);
        }

        // 删除相册
        [HttpDelete("{id}")]
        public ActionResult<Message> delAlbum(int id)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }

            Message msg = AlbumService.DeleteAlbumByID(id);
            return new JsonResult(msg);
        }

        // 获取相册列表
        [HttpGet]
        public IActionResult getAlbumList(int pageLimit, int pageIndex)
        {
            AlbumListModel albumListModel = new AlbumListModel();

            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }

            var uId = Convert.ToInt32(userId);
            IEnumerable<Album> albumIE = AlbumService.GetAlbumsByUserID(uId, pageLimit = 4, pageIndex);
            IEnumerable<Album> allAlbums = AlbumService.GetAlbumsByUserID(uId);
            if (albumIE != null)
            {
                albumListModel.albums.AddRange(albumIE);
                albumListModel.allAlbums.AddRange(allAlbums);
            }

            return View("/Pages/Album/MyAlbum.cshtml", albumListModel);
        }

        // 创建相册
        [HttpPost]
        public ActionResult<Message> CreateAlbum(Album album)
        {
            if (album.Picture == null)
                album.Picture = "~/album/timg.png";
            string tmp = HttpContext.Session.GetString("userId");
            if (tmp == "" || tmp == null)
            {
                return Redirect("/SignIn");
            }

            var userId = Convert.ToInt32(tmp);
            album.UserID = userId;
            Message message = AlbumService.CreateAlbum(album);
            return new JsonResult(message);
        }

        //[Route("del")]
        //public IActionResult 
    }
}
