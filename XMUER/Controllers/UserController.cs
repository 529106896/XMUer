using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XMUER.Mapper.Base;
using XMUER.Common.Infrastructure;
using XMUER.Models.Home;
using XMUER.Models.ModelsList;
using XMUER.Service.Implement;
using XMUER.Service.Interface;

namespace XMUER.Controllers
{
    [Route("/home/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        protected readonly MyContext Context;
        protected readonly IUserService UserService;

        public UserController(IUserService userService, MyContext context)
        {
            UserService = userService;
            Context = context;
        }

		[HttpGet("share")]
		public IActionResult GetShareThing([FromQuery(Name = "size")] int size)
		{

			ShareListModel shareListModel = new ShareListModel();

			IEnumerable<Status> statusesIE = Context.Statuses.ToList();
			List<Status> statuses = new List<Status>();
			if (statuses.Count() < size)
				statuses = statusesIE.ToList();
			else
				statuses = statusesIE.ToList().GetRange(0, size);

			List<Share> shares = new List<Share>();

			foreach (Status status in statuses)
			{
				Share share = new Share();
				share.ShareContent = status.Content;
				User user = Context.Users.SingleOrDefault(s => s.ID == status.UserID);
				share.Username = user.userName;
				share.UserId = user.ID;
				share.Avatar = user.Avatar;
				share.like = status.Like;
				share.commentCount = Context.Comments.Count(s => s.StatusID == status.ID);
				share.Time = status.Time.ToLongTimeString();
			}
			shareListModel.shares = shares;

			return View("/Pages/Index.cshtml", shareListModel);
		}


		[HttpGet]
		public IActionResult GetUsers()
		{
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUsers();
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}

			return View("/Pages/User/UserList.cshtml", userListModel);
		}


		[HttpGet("name")]
		public IActionResult GetUsersByName([FromQuery] string value)
		{
			string name = value;
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUserByName(name);
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}


			return View("/Pages/User/UserList.cshtml", userListModel);
		}

		[HttpGet("college")]
		public IActionResult GetUsersByColledge([FromQuery] string value)
		{
			string colledge = value;
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUserByCollege(colledge);
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}

			return View("/Pages/User/UserList.cshtml", userListModel);
		}

		[HttpGet("department")]
		public IActionResult GetUsersByDepartment([FromQuery] string value)
		{
			string department = value;
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUserByDepartment(department);
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}

			return View("/Pages/User/UserList.cshtml", userListModel);
		}

		[HttpGet("major")]
		public IActionResult GetUsersByMajor([FromQuery] string value)
		{
			string major = value;
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUserByMajor(major);
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}

			return View("/Pages/User/UserList.cshtml", userListModel);
		}

		[HttpGet("studentNo")]
		public IActionResult GetUsersByStudentNo([FromForm] string studentNo)
		{
			UserListModel userListModel = new UserListModel();

			IEnumerable<User> userIE = UserService.GetUserByStudentNo(studentNo);
			if (userIE != null)
			{
				userListModel.users.AddRange(userIE);
			}

			return View("/Pages/User/UserList.cshtml", userListModel);
		}

		[HttpPost("like/{id}")]
		public Message LikeOther(int id)
		{
			var status = Context.Statuses.SingleOrDefault(s => s.ID == id);
			var update = false;

			if (status != null)
			{
				status.Like++;
				update = Context.SaveChanges() > 0;
			}
			if (update)
				return new Message((int)MessageCode.OK, status.Like.ToString()); //供前端异步获取点赞数
			return new Message((int)MessageCode.INTERNAL_SERVER_ERR,
					MessageCode.INTERNAL_SERVER_ERR.GetDescription());
		}

		[HttpPost("comment/{id}")]
		public Message CommentOther(int id, [FromForm] string content)
		{
			string userIdStr = HttpContext.Session.GetString("userId");
			if (string.IsNullOrEmpty(userIdStr))
			{
				return new Message((int)MessageCode.NOT_LOGGED_IN, MessageCode.NOT_LOGGED_IN.GetDescription());
			}
			int userId = int.Parse(userIdStr);
			Comment comment = new Comment();
			comment.UserId = userId;
			comment.StatusID = id;
			comment.Content = content;
			comment.Time = DateTime.Now;
			Context.Comments.Add(comment);
			var saveState = Context.SaveChanges() > 0;
			if (saveState)
				return new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());
			return new Message((int)MessageCode.INTERNAL_SERVER_ERR,
					MessageCode.INTERNAL_SERVER_ERR.GetDescription());
		}

		[HttpPost("status")]
		public Message PublishStatus([FromQuery] int id, [FromQuery] string method, [FromForm] string content)
		{
			string userIdStr = HttpContext.Session.GetString("userId");
			if (string.IsNullOrEmpty(userIdStr))
			{
				return new Message((int)MessageCode.NOT_LOGGED_IN, MessageCode.NOT_LOGGED_IN.GetDescription());
			}
			int userId = int.Parse(userIdStr);
			// 保存新状态
			if (method == "post") // 发布
			{
				Status status = new Status();
				status.UserID = userId;
				status.Content = content;
				status.Like = 0;
				status.State = 2;
				status.Time = DateTime.Now;
				Context.Statuses.Add(status);
				Context.SaveChanges();
				Context.Entry(status);
			}
			else
			if (method == "draft") // 存草稿
			{
				Status status = new Status();
				status.UserID = userId;
				status.Content = content;
				status.Like = 0;
				status.State = 1;
				status.Time = DateTime.Now;
				Context.Statuses.Add(status);
				Context.SaveChanges();
				Context.Entry(status);
			}
			else
			if (method == "edit") // 编辑状态
			{
				if (HttpContext.Request.Query.ContainsKey("id"))
				{
					var statusList = from s in Context.Statuses
									 where
									 s.ID == id &&
									 s.UserID == userId && s.State != -1
									 select s;
					Status status = statusList.First();
					if (status != null)
					{
						status.Content = content;
						status.Time = DateTime.Now;
						Context.Statuses.Update(status);
						Context.SaveChanges();
					}
				}
			}
			return new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());
		}

		[HttpPost("logout")]
        public Message Logout()
        {
            HttpContext.Session.Clear();
            return new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());
        }
    }
}
