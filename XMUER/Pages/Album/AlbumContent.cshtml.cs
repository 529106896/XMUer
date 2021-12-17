using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages.Album
{
    public class AlbumContentModel : PageModel
    {
        private readonly MyContext _db;
        private Models.Home.Album albumInfo;

        public List<Photo> Photos { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

        public AlbumContentModel(MyContext db)
        {
            this._db = db;
        }

        public IActionResult OnGet([FromQuery] string albumId)
        {
            string userId = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userId))
            {
                return Redirect("/SignIn");
            }

            try
            {
                AlbumId = Convert.ToInt32(albumId);
            }
            catch (Exception e)
            {
                return Redirect("/home/album");
            }

            if (AlbumId <= 0)
            {
                return Redirect("/home/album");
            }

            albumInfo = _db.Albums.Find(AlbumId);
            if (null == albumInfo)
            {
                return Redirect("/home/album");
            }

            AlbumName = albumInfo.Name;
            getAlbumContent();
            return Page();
        }

        private void getAlbumContent()
        {
            var photoList = from ph in _db.Photos
                where ph.AlbumID == AlbumId
                select ph;
            Photos = photoList.ToList();
        }
    }
}
