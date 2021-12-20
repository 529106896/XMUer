using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Common.Infrastructure;
using xmuer.Mapper.Interface;
using XMUER.Models.Home;
using XMUER.Service.Interface;
using XMUER.Mapper.Interface;

namespace XMUER.Service.Implement
{
    public class AvatarService : IAvatarService
    {
		#region 属性声明

		IAvatarRepository AvatarRepository;

		#endregion

		#region	构造函数
		public AvatarService(IAvatarRepository avatarRepository)
		{
			AvatarRepository = avatarRepository;
		}
		#endregion

		#region 照片操作

		//创建照片
		public Message CreateAvatar(Avatar avatar)
		{
			var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

			if (avatar == null)
			{
				msg.Code = (int)MessageCode.DATA_NOT_EMPTY;
				msg.Msg = MessageCode.DATA_NOT_EMPTY.GetDescription();
				return msg;
			}
			Avatar tempAvatar = new Avatar();
			var addState = AvatarRepository.CreateAvatar(avatar);
			if (addState)
			{
				msg.Code = (int)MessageCode.OK;
				msg.Msg = MessageCode.OK.GetDescription();
			}
			else
			{
				msg.Code = (int)MessageCode.INTERNAL_SERVER_ERR;
				msg.Msg = MessageCode.INTERNAL_SERVER_ERR.GetDescription();
			}
			return msg;
		}

		public Avatar GetAvatarById(int pid)
		{
			return AvatarRepository.getAvatarByID(pid);
		}

        //通过用户ID取照片
        public Avatar GetAvatarByUserID(int userID)
        {
            return AvatarRepository.GetAvatarByUserID(userID);
        }

		public Message DeleteAvatarById(int avatarId)
		{
			var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

			var upState = AvatarRepository.DeleteAvatar(avatarId);
			if (upState)
			{
				msg.Code = (int)MessageCode.OK;
				msg.Msg = MessageCode.OK.GetDescription();
			}
			else
			{
				msg.Code = (int)MessageCode.INTERNAL_SERVER_ERR;
				msg.Msg = MessageCode.INTERNAL_SERVER_ERR.GetDescription();
			}
			return msg;
		}


		#endregion

	}
}
