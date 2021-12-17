using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;
using XMUER.Models.Home;

namespace XMUER.Pages.Status
{
    public class StatusModel : PageModel
    {
        private readonly MyContext Context;

        public StatusModel(MyContext context)
        {
            this.Context = context;
        }

        public string Username { get; set; }
        public Share Share { get; set; }
        public List<CommentVo> Comments { get; set; }

        public IActionResult OnGet(int shareId)
        {
            Models.Home.Status status = Context.Statuses.Find(shareId);
            if (status == null)
            {
                Redirect("/");
            }
            Share = new Share();
            Share.ShareContent = status.Content;
            Share.ID = status.ID;
            Models.Home.User user = Context.Users.SingleOrDefault(s => s.ID == status.UserID);
            Share.Username = user.realName;
            Share.UserId = user.ID;
            Share.Avatar = user.Avatar;
            Share.like = status.Like;
            Share.commentCount = Context.Comments.Count(s => s.StatusID == status.ID);
            Share.Time = status.Time.ToString();

            // 获取评论
            IQueryable<Comment> commentsQuery = from c in Context.Comments
                where c.StatusID == Share.ID
                select c;

            Comments = new List<CommentVo>();
            foreach (var comment in commentsQuery)
            {
                // 获取评论源头用户资讯
                Models.Home.User commentByUser = Context.Users.Find(comment.UserId);
                if (commentByUser == null)
                {
                    continue;
                }
                CommentVo vo = new CommentVo(comment);
                vo.Username = commentByUser.realName;
                vo.Avatar = commentByUser.Avatar;
                Comments.Add(vo);
            }

            return Page();
        }
    }
}
