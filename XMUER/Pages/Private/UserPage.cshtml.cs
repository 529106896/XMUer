using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;

namespace XMUER.Pages.Private
{
    public class UserPageModel : PageModel
    {
        public string Name { get; set; }
        public string imgUrl { get; set; }
        public string StudySchool { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        private MyContext _db;

        public UserPageModel(MyContext db)
        {
            _db = db;
        }

        public IActionResult OnGet([FromQuery] string userId)
        {
            if (userId == null)
            {
                return Redirect("/");
            }

            int id = int.Parse(userId);
            // 获取用户资讯
            Models.Home.User user = _db.Users.Find(id);
            if (user == null)
            {
                return Redirect("/");
            }

            Name = user.realName;
            StudySchool = user.university ?? "未知的学校";
            imgUrl = user.Avatar;
            Department = user.Department;
            Description = user.homePageDescription;
            return Page();
        }
    }
}
