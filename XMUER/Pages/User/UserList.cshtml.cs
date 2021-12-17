using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace XMUER.Pages.User
{
    public class UserListModel : PageModel
    {
        public List<Models.Home.User> users { get; set; }

        public UserListModel()
        {
            users = new List<Models.Home.User>();
        }
    }
}
