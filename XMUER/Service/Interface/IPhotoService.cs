using XMUER.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace XMUER.Service.Interface
{
	public interface IPhotoService
	{
		#region 相片操作
		//创建照片
		Message CreatePhoto(Photo photo);

		//通过相册ID取照片
		IEnumerable<Photo> GetPhotosByAlbumID(int albumID);

		//通过照片id删除照片
        Message DeletePhotoById(int photoId);

        Photo GetPhotoById(int pid);

        #endregion
    }
}
