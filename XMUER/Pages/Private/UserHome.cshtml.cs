using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages.Private
{
    public class UserHomeModel : PageModel
    {
        private readonly MyContext _db;
        private Models.Home.User user;
        private int userId;

        public string WelcomeMessage { get; set; }
        public string StudySchool { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string imgUrl { get; set; }
        public string Description { get; set; }
        public List<string> Comments { get; set; }
        public List<Avatar> Avatar { get; set; }

        public UserHomeModel(MyContext db)
        {
            _db = db;
            user = _db.Users.Find(userId);
        }
        
        public IActionResult OnGet()
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(tmp))
            {
                return Redirect("/SignIn");
            }
            userId = Convert.ToInt32(tmp);
            getAvatarContent(userId);
            user = _db.Users.Find(userId);
            WelcomeMessage = user.userName;
            StudySchool = user.university != null ? user.university : "匿名学校";
            Email = user.email;
            Department = user.Department;
            Description = user.homePageDescription == null? "用户太懒了，还没有写个人简介" : user.homePageDescription;
            Comments = new List<string>(); // TODO
            imgUrl = user.Avatar == null ? "../avatar/defaultAvatar.png" : user.Avatar;
            return Page();
        }

        public IActionResult OnPost()
        {
            user = _db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("userId")));
            IEnumerator<KeyValuePair<string, StringValues>> enumerator = Request.Form.GetEnumerator();
            //string test = "";
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, StringValues> tmp = enumerator.Current;
                //test += tmp.ToString();
                if (tmp.Key == "Description")
                {
                    user.homePageDescription = tmp.Value.ToString() == "用户太懒了，还没有写个人简介"
                        ? null
                        : tmp.Value.ToString();
                }
            }

            //return Content(test);
            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return Redirect("/Private/UserHome");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        private void getAvatarContent(int userId)
        {
            var avatar = from av in _db.Avatars
                            where av.UserID == userId
                         select av;
            Avatar = avatar.ToList();
            user = _db.Users.Find(userId);
            if (avatar.Count() != 0)
            {
                user.Avatar = ".."+Url.Content(Avatar[0].Picture);
            }
            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }
    }
}
