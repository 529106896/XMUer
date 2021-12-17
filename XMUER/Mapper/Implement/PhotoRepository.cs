using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Mapper.Base;
using xmuer.Mapper.Interface;
using XMUER.Models.Home;

namespace XMUER.Mapper.Implement
{
	public class PhotoRepository : IPhotoRepository
	{
		#region 属性声明

		public MyContext Context;

		#endregion

		#region 构造函数

		public PhotoRepository(MyContext context)
		{
			Context = context;
		}

		#endregion


		#region 相片操作
		//创建照片
		public bool CreatePhoto(Photo photo)
		{
			Context.Photos.Add(photo);
			return Context.SaveChanges() > 0;
		}

        public bool DeletePhoto(int photoId)
        {
            var photo = Context.Photos.SingleOrDefault(s => s.ID == photoId);
            Context.Photos.Remove(photo);
            return Context.SaveChanges() > 0;
        }

        public Photo getPhotoByID(int pid)
        {
            return Context.Photos.SingleOrDefault(s => s.ID == pid);
        }

		//通过相册ID取照片
		public IEnumerable<Photo> GetPhotosByAlbumID(int albumID)
		{
			return Context.Photos.Where(s => s.AlbumID == albumID);
		}
		#endregion
	}
}
