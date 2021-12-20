using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace XMUER.Mapper.Interface
{
    public interface IAvatarRepository
    {
        #region 相片操作
        //创建照片
        bool CreateAvatar(Avatar avatar);

        //通过用户ID取照片
        Avatar GetAvatarByUserID(int userID);

        // 通过照片id取照片
        Avatar getAvatarByID(int pid);

        // 通过id删除照片
        bool DeleteAvatar(int avatarId);

        #endregion
    }
}
