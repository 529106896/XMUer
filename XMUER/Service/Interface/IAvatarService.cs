using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Common.Infrastructure;
using XMUER.Models.Home;

namespace XMUER.Service.Interface
{
    public interface IAvatarService
    {
        #region 相片操作
        //创建照片
        Message CreateAvatar(Avatar avatar);

        //通过用户ID取照片
        Avatar GetAvatarByUserID(int userID);

        //通过照片id删除照片
        Message DeleteAvatarById(int avatarId);

        Avatar GetAvatarById(int pid);

        #endregion
    }
}
