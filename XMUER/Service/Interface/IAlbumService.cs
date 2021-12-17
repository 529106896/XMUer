using XMUER.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace XMUER.Service.Interface
{
	public interface IAlbumService
	{
		#region 相册操作

		//创建相册
		Message CreateAlbum(Album album);

		//取全部相册
		IEnumerable<Album> GetAlubums();

		//通过ID取相册
		Album GetAlbumByID(int id);

		//通过用户ID取相册
		IEnumerable<Album> GetAlbumsByUserID(int userID);

		//通过用户ID分页取相册
		IEnumerable<Album> GetAlbumsByUserID(int userID, int pageLimit, int pageIndex);

		//修改相册封面
		Message ModifiyAlbumPictureByID(int id, string picture, string name);
		
		//删除相册
		Message DeleteAlbumByID(int id);

		#endregion
	}
}
