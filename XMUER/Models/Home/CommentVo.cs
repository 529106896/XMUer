 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XMUER.Models.Home
{
    // 供前端使用的Comment对象，上过OOAD应该都知道啥意思
    public class CommentVo
    {
        public int ID { get; set; }
        public int StatusID { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }

        public DateTime Time { get; set; }

        // 前端需要的两个属性
        public string Username { get; set; }
        public string Avatar { get; set; }

        public CommentVo(Comment comment)
        {
            this.ID = comment.ID;
            this.StatusID = comment.StatusID;
            this.UserId = comment.UserId;
            this.Content = comment.Content;
            this.Time = comment.Time;
        }
	}
}
