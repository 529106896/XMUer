using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages
{
    public class IndexModel : PageModel
    {
        protected MyContext Context;

		public List<Share> Shares { get; set; }

        public IndexModel(MyContext context)
        {
            Context = context;
        }

        public void OnGet()
        {
            int size = 10; // todo

            IEnumerable<Models.Home.Status> statusesIE = Context.Statuses.Where(s=>s.State == 2).ToList();
            List<Models.Home.Status> statuses = new List<Models.Home.Status>();
            if (statuses.Count() < size)
                statuses = statusesIE.ToList();
            else
                statuses = statusesIE.ToList().GetRange(0, size);

            List<Share> shares = new List<Share>();
            foreach (Models.Home.Status status in statuses)
            {
                Share share = new Share();
                share.ShareContent = status.Content;
                share.ID = status.ID;
                Models.Home.User user = Context.Users.SingleOrDefault(s => s.ID == status.UserID);
                share.Username = user.realName;
                share.UserId = user.ID;
                share.Avatar = user.Avatar;
                share.like = status.Like;
                share.commentCount = Context.Comments.Count(s => s.StatusID == status.ID);
                share.Time = status.Time.ToLongTimeString();

                shares.Add(share);
            }

            this.Shares = shares;
        }
	}
}
