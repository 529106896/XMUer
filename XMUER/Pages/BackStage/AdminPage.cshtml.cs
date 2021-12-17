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

            // ��ķ����ʽѡ��stateΪ0����ͨ�û�
            users = _db.Users.Where(s => s.state == 0 && s.type == 1).ToList();

            // ǰ����query����ʽ��id�����������������
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

        // �����û�ע��
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

        // �ܾ��û�ע��
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

        // �ж�����ȼ�
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

            if (grade == 1) return "���ڼ�";
            if (grade == 2) return "��";
            if (grade == 3) return "����";
            if (grade == 4) return "��ȫ";

            return "���뺬�зǷ��ַ�";
        }
    }
}
