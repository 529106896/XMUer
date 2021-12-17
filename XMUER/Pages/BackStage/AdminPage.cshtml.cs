using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages.BackStage
{
    public class AdminPageModel : PageModel
    {
        private readonly MyContext _db;
        public List<Models.Home.User> users { get; set; }

        public AdminPageModel(MyContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(tmp))
            {
                return Redirect("/SignIn");
            }

            // 拉姆达表达式选出state为0的普通用户
            users = _db.Users.Where(s => s.state == 0 && s.type == 1).ToList();

            // 前端用query的形式把id传回来，在这里接收
            if (HttpContext.Request.Query.ContainsKey("id"))
            {
                if (HttpContext.Request.Query.ContainsKey("accept"))
                {
                    if (HttpContext.Request.Query["accept"] == "1")
                    {
                        AcceptUser(int.Parse(HttpContext.Request.Query["id"].ToString()));
                    }
                    else if (HttpContext.Request.Query["accept"] == "0")
                    {
                        DeclineUser(int.Parse(HttpContext.Request.Query["id"].ToString()));
                    }
                }
            }

            users = _db.Users.Where(s => s.state == 0 && s.type == 1).ToList();
            return Page();
        }

        // 接受用户注册
        public void AcceptUser(int index)
        {
            Models.Home.User user = users[index];
            user.state = 1;

            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        // 拒绝用户注册
        public void DeclineUser(int index)
        {
            Models.Home.User user = users[index];
            user.state = -1;

            try
            {
                _db.Users.Update(user);
                _db.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

        // 判断密码等级
        public String PasswordGrade(String pwd)
        {
            bool num = false;
            bool lowchar = false;
            bool highchar = false;
            bool other = false;
            foreach (char c in pwd)
            {
                if ('0' <= c && c <= '9')
                {
                    num = true;
                }
                else if ('a' <= c && c <= 'z')
                {
                    lowchar = true;
                }
                else if ('A' <= c && c <= 'Z')
                {
                    highchar = true;
                }
                else
                {
                    other = true;
                }
            }

            int grade = 0;
            if (num) 
                grade++;
            if (lowchar) 
                grade++;
            if (highchar) 
                grade++;
            if (other) 
                grade++;

            if (grade == 1) return "过于简单";
            if (grade == 2) return "简单";
            if (grade == 3) return "复杂";
            if (grade == 4) return "安全";

            return "密码含有非法字符";
        }
    }
}
