using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly MyContext _db;

        public string userName { get; set; }
        public string userPass { get; set; }
        public string userPassAgain { get; set; }

        public SignUpModel(MyContext db)
        {
            this._db = db;
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
            Models.Home.User newUser = new Models.Home.User();
            IEnumerator<KeyValuePair<string, StringValues>> enumerator = Request.Form.GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<string, StringValues> tmp = enumerator.Current;
                if (tmp.Key.Equals("userName"))
                {
                    userName = tmp.Value.ToString();
                }

                if (tmp.Key.Equals("userPass"))
                {
                    userPass = tmp.Value.ToString();
                }

                if (tmp.Key.Equals("userPassAgain"))
                {
                    userPassAgain = tmp.Value.ToString();
                }
            }

            if (!userPass.Equals(userPassAgain))
            {
                return Content("�����������벻һ�£�");
            }

            newUser.userName = userName;
            newUser.password = userPass;
            // ʹ��MD5���������м���
            newUser.Md5Password = MD5Encrypt16(userPass);
            // typeΪ1��ʾ��ͨ�û�
            newUser.type = 1;
            // stateΪ0��ʾδ��˵����û�
            newUser.state = 0;
            newUser.birthday = new DateTime(2001, 1, 1);
            newUser.Avatar = "../avatar/defaultAvatar.png";
            try
            {
                _db.Users.Add(newUser);
                _db.SaveChanges();
                // ��ȡ����ʵ��� DbEntityEntry ����
                // �Ա��ṩ�����ʵ���йص���Ϣ�ķ����Լ���ʵ��ִ�в����Ĺ���
                _db.Entry(newUser);
                return Redirect("/SignIn");
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }
    }
}
