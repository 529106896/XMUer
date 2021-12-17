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
    public class UserInfoModel : PageModel
    {
        private readonly MyContext _db;
        public Models.Home.User user;
        private int userId;

        public string university { get; set; }
        public string highSchool { get; set; }
        public string juniorHighSchool { get; set; }
        public string primarySchool { get; set; }
        public string hobbyMusic { get; set; }
        public string hobbyBook { get; set; }
        public string hobbyMovie { get; set; }
        public string hobbyGame { get; set; }
        public string hobbyAnime { get; set; }
        public string hobbySport { get; set; }
        public string hobbyOther { get; set; }
        public string realName { get; set; }
        public int gender { get; set; }
        public DateTime birthday { get; set; }
        public string hometown { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string studentNo { get; set; }
        public string college { get; set; }
        public string department { get; set; }
        public string major { get; set; }

        public UserInfoModel(MyContext db)
        {
            _db = db;
            user = _db.Users.Find(userId);
        }

        public IActionResult OnPost()
        {
            user = _db.Users.Find(Convert.ToInt32(HttpContext.Session.GetString("userId")));
            IEnumerator<KeyValuePair<string, StringValues>> enumerator = Request.Form.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, StringValues> tmp = enumerator.Current;
                if (tmp.Key == "university")
                    user.university = tmp.Value.ToString();
                if (tmp.Key == "highSchool") 
                    user.highSchool = tmp.Value.ToString();
                if (tmp.Key == "juniorHighSchool") 
                    user.juniorHighSchool = tmp.Value.ToString();
                if (tmp.Key == "primarySchool") 
                    user.primarySchool = tmp.Value.ToString();
                if (tmp.Key == "hobbyMusic")
                    user.hobbyMusic = tmp.Value.ToString();
                if (tmp.Key == "hobbyBook")
                    user.hobbyBook = tmp.Value.ToString();
                if (tmp.Key == "hobbyMovie")
                    user.hobbyMovie = tmp.Value.ToString();
                if (tmp.Key == "hobbyGame")
                    user.hobbyGame = tmp.Value.ToString();
                if (tmp.Key == "hobbyAnime")
                    user.hobbyAnime = tmp.Value.ToString();
                if (tmp.Key == "hobbySport")
                    user.hobbySport = tmp.Value.ToString();
                if (tmp.Key == "hobbyOther")
                    user.hobbyOther = tmp.Value.ToString();
                if (tmp.Key == "realName")
                    user.realName = tmp.Value.ToString();
                if (tmp.Key == "gender")
                {
                    if (tmp.Value.ToString().Equals("Ñ¡Ôñ..."))
                    {
                        user.gender = 0;
                    }
                    else
                    {
                        user.gender = Convert.ToInt32(tmp.Value.ToString());
                    }
                }
                if (tmp.Key == "hometown") 
                    user.hometown = tmp.Value.ToString();
                if (tmp.Key == "email") 
                    user.email = tmp.Value.ToString();
                if (tmp.Key == "mobile") 
                    user.mobile = tmp.Value.ToString();
                if (tmp.Key == "birthday")
                {
                    DateTime formatDt = Convert.ToDateTime(tmp.Value.ToString());
                    user.birthday = Convert.ToDateTime(formatDt.ToShortDateString());
                }

                if (tmp.Key == "studentNo")
                {
                    user.StudentNo = tmp.Value.ToString();
                }
                if (tmp.Key == "college")
                {
                    user.College = tmp.Value.ToString();
                }
                if (tmp.Key == "department")
                {
                    user.Department = tmp.Value.ToString();
                }
                if (tmp.Key == "major")
                {
                    user.Major = tmp.Value.ToString();
                }
            }

            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
                return Redirect("/Private/UserInfo");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        public IActionResult OnGet()
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(tmp))
            {
                return Redirect("/SignIn");
            }
            userId = Convert.ToInt32(tmp);
            user = _db.Users.Find(userId);
            university = user.university;
            highSchool = user.highSchool;
            juniorHighSchool = user.juniorHighSchool;
            primarySchool = user.primarySchool;
            hobbyMusic = user.hobbyMusic;
            hobbyBook = user.hobbyBook;
            hobbyMovie = user.hobbyMovie;
            hobbyGame = user.hobbyGame;
            hobbyAnime = user.hobbyAnime;
            hobbySport = user.hobbySport;
            hobbyOther = user.hobbyOther;
            realName = user.realName;
            gender = user.gender;
            birthday = user.birthday;
            hometown = user.hometown;
            email = user.email;
            mobile = user.mobile;
            studentNo = user.StudentNo;
            college = user.College;
            department = user.Department;
            major = user.Major;
            return Page();
        }
    }
}
