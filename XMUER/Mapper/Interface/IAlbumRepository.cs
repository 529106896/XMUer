using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace xmuer.Mapper.Interface
{
	public interface IAlbumRepository
	{
		#region 相册操作

		//创建相册
		bool CreateAlbum(Album album);

		//取全部相册
		IEnumerable<Album> GetAlubums();

		//通过ID取相册
		Album GetAlbumByID(int id);

		//通过用户ID取相册
		IEnumerable<Album> GetAlbumsByUserID(int userID);

		//修改相册封面
		bool ModifiyAlbumPictureByID(int id, string picture, string name);

		//删除相册
		bool DeleteAlbumByID(int id);

		#endregion
	}
}
