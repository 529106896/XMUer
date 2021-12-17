using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace xmuer.Mapper.Interface
{
	public interface IPhotoRepository
	{
		#region 相片操作
		//创建照片
		bool CreatePhoto(Photo photo);

		//通过相册ID取照片
		IEnumerable<Photo> GetPhotosByAlbumID(int albumID);

        // 通过照片id取照片
        Photo getPhotoByID(int pid);

		// 通过id删除照片
		bool DeletePhoto(int photoId);

        #endregion
    }
}
