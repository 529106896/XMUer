using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Models.Home;

namespace XMUER.Models.ModelsList
{
    public class UserListModel : PageModel
    {
        public List<User> users { get; set; }

        public UserListModel()
        {
            users = new List<User>();
        }
    }
}
