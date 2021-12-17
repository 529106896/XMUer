using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Models.Home;

namespace XMUER.Models.ModelsList
{
    public class AlbumListModel : PageModel
    {
        public List<Album> albums { get; set; }

        public List<Album> allAlbums { get; set; }

        public AlbumListModel()
        {
            albums = new List<Album>();
            allAlbums = new List<Album>();
        }
    }
}
