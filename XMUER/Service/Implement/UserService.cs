using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xmuer.Mapper.Interface;
using XMUER.Common.Infrastructure;
using XMUER.Mapper.Interface;
using XMUER.Models.Home;
using XMUER.Service.Interface;

namespace XMUER.Service.Implement
{
	public class UserService : IUserService
	{
		#region 属性声明

		IUserRepository UserRepository;

		//IAvatorRepository PhotoRepository;


		#endregion

		#region	构造函数
		public UserService(IUserRepository userRepository)
		{
			UserRepository = userRepository;
		}
		#endregion

		//取用户
		public IEnumerable<User> GetUserByName(string name)
		{
			return UserRepository.GetUserByName(name);
		}
		//取用户
		public IEnumerable<User> GetUserByStudentNo(string studentNo)
		{
			return UserRepository.GetUserByStudentNo(studentNo);
		}
		//取用户
		public IEnumerable<User> GetUserByCollege(string college)
		{
			return UserRepository.GetUserByCollege(college);
		}
		//取用户
		public IEnumerable<User> GetUserByDepartment(string department)
		{
			return UserRepository.GetUserByDepartment(department);
		}
		//取用户
		public IEnumerable<User> GetUserByMajor(string major)
		{
			return UserRepository.GetUserByMajor(major);
		}
		//取全部用户
		public IEnumerable<User> GetUsers()
		{
			return UserRepository.GetUsers();
		}

		////创建照片
		//public Message CreatePhoto(Photo photo)
		//{
		//	var msg = new Message((int)MessageCode.OK, MessageCode.OK.GetDescription());

		//	if (photo == null)
		//	{
		//		msg.Code = (int)MessageCode.DATA_NOT_EMPTY;
		//		msg.Msg = MessageCode.DATA_NOT_EMPTY.GetDescription();
		//		return msg;
		//	}
		//	var addState = PhotoRepository.CreatePhoto(photo);
		//	if (addState)
		//	{
		//		msg.Code = (int)MessageCode.OK;
		//		msg.Msg = MessageCode.OK.GetDescription();
		//	}
		//	else
		//	{
		//		msg.Code = (int)MessageCode.INTERNAL_SERVER_ERR;
		//		msg.Msg = MessageCode.INTERNAL_SERVER_ERR.GetDescription();
		//	}
		//	return msg;
		//}

		//public Photo GetPhotoById(int pid)
		//{
		//	return PhotoRepository.getPhotoByID(pid);
		//}
	}
}
