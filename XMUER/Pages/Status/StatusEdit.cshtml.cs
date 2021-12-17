using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;

namespace XMUER.Pages.Status
{
    public class StatusEditModel : PageModel
    {
        private readonly MyContext _db;
        private int userId;

        public StatusEditModel(MyContext db)
        {
            _db = db;
        }

        public IActionResult OnGet([FromQuery] int id)
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (tmp == "" || tmp == null)
            {
                return Redirect("/SignIn");
            }
            userId = Convert.ToInt32(tmp);

            if (HttpContext.Request.Query.ContainsKey("new"))
            {
                return Page();
            }
            else if (HttpContext.Request.Query.ContainsKey("id"))
            {

                var statusList = from s in _db.Statuses
                    where
                        s.ID == id &&
                        s.UserID == userId && s.State != -1
                    select s;
                Models.Home.Status status = statusList.First();

                if (status != null)
                {
                    if (HttpContext.Request.Query.ContainsKey("post"))
                    {
                        status.State = 2;
                        _db.Statuses.Update(status);
                        _db.SaveChanges();
                        _db.Entry(status);
                        return Redirect("/Status/StatusList");
                    }
                    else if (HttpContext.Request.Query.ContainsKey("delete"))
                    {
                        status.State = -1;
                        _db.Statuses.Update(status);
                        _db.SaveChanges();
                        _db.Entry(status);
                        return Redirect("/Status/StatusList");
                    }
                }
            }
            return Redirect("/Status/StatusList");
        }

        public IActionResult OnPost([FromQuery] int id)
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(tmp))
            {
                return Redirect("/SignIn");
            }
            userId = Convert.ToInt32(tmp);

            if (HttpContext.Request.Query.ContainsKey("new"))
            {
                if (HttpContext.Request.Query.ContainsKey("post"))
                {
                    Models.Home.Status status = new Models.Home.Status();
                    status.UserID = int.Parse(HttpContext.Session.GetString("userId"));
                    status.Content = HttpContext.Request.Form["content"];
                    status.Like = 0;
                    status.State = 2;
                    status.Time = DateTime.Now;
                    _db.Statuses.Add(status);
                    _db.SaveChanges();
                    _db.Entry(status);
                }
                if (HttpContext.Request.Query.ContainsKey("draft"))
                {
                    Models.Home.Status status = new Models.Home.Status();
                    status.UserID = int.Parse(HttpContext.Session.GetString("userId"));
                    status.Content = HttpContext.Request.Form["content"];
                    status.Like = 0;
                    status.State = 1;
                    status.Time = DateTime.Now;
                    _db.Statuses.Add(status);
                    _db.SaveChanges();
                    _db.Entry(status);
                }

            }
            if (HttpContext.Request.Query.ContainsKey("edit"))
            {
                if (HttpContext.Request.Query.ContainsKey("id"))
                {

                    var statusList = from s in _db.Statuses
                                     where
                                     s.ID == id &&
                                     s.UserID == userId && s.State != -1
                                     select s;
                    Models.Home.Status status = statusList.First();

                    if (status != null)
                    {
                        status.Content = HttpContext.Request.Form["content"];
                        status.Time = DateTime.Now;
                        _db.Statuses.Update(status);
                        _db.SaveChanges();
                    }

                    return Content("OK");
                }

            }
            return Page();
        }
    }
}
