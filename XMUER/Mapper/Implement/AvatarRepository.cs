using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Mapper.Base;
using XMUER.Mapper.Interface;
using XMUER.Models.Home;

namespace XMUER.Mapper.Implement
{
    public class AvatarRepository : IAvatarRepository
	{
		#region 属性声明

		public MyContext Context;

		#endregion

		#region 构造函数

		public AvatarRepository(MyContext context)
		{
			Context = context;
		}

		#endregion


		#region 相片操作
		//创建照片
		public bool CreateAvatar(Avatar avatar)
		{
			Context.Avatars.Add(avatar);
			return Context.SaveChanges() > 0;
		}

		public bool DeleteAvatar(int avatarId)
		{
			var avatar = Context.Avatars.SingleOrDefault(s => s.ID == avatarId);
			Context.Avatars.Remove(avatar);
			return Context.SaveChanges() > 0;
		}

		public Avatar getAvatarByID(int pid)
		{
			return Context.Avatars.SingleOrDefault(s => s.ID == pid);
		}

		//通过用户ID取照片
		public Avatar GetAvatarByUserID(int userID)
		{
			return Context.Avatars.SingleOrDefault(s => s.UserID == userID);
		}

        #endregion
    }
}
