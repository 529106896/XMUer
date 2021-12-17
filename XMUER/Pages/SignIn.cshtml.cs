using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Primitives;
using XMUER.Common.Infrastructure;
using XMUER.Mapper.Base;

namespace XMUER.Pages
{
    public class SignInModel : PageModel
    {
        private readonly MyContext _db;
        private Models.Home.User user;

        public string userName { get; set; }
        public string userPass { get; set; }

        public SignInModel(MyContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        public IActionResult OnPost()
        {
            IEnumerator<KeyValuePair<string, StringValues>> enumerator = Request.Form.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, StringValues> tmp = enumerator.Current;
                if (tmp.Key.Equals("userName")) 
                    userName = tmp.Value.ToString();
                if (tmp.Key.Equals("userPass")) 
                    userPass = tmp.Value.ToString();
            }

            try
            {
                string md5Pass = MD5Encrypt16(userPass);

                var users = from u in _db.Users
                    where u.userName == userName && u.Md5Password == md5Pass
                    select u;
                if (users.ToList().Count == 0)
                {
                    return Content("�û������������");
                }
                Models.Home.User loginUser = users.First();
                if (null != loginUser && loginUser.Md5Password.Equals(md5Pass))
                {
                    if (loginUser.state == 0)
                        return Content("�˺���δ��ˣ�");
                    if (loginUser.state == -1)
                        return Content("���ע�ᱻ�ܾ���������ע�ᣡ");
                    HttpContext.Session.Clear();
                    HttpContext.Session.Set("userId", System.Text.Encoding.Default.GetBytes(loginUser.ID.ToString()));
                    HttpContext.Session.Set("userName", System.Text.Encoding.Default.GetBytes(loginUser.userName));
                }

                // ����ǹ���Ա�������̨����
                if (loginUser.type == 0)
                {
                    return Redirect("/BackStage/AdminPage");
                }
                // �������ͨ�û�����ת����ҳ
                return Redirect("/Index");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
    }
}
