using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMUER.Models.Home;

namespace XMUER.Mapper.Interface
{
	public interface IUserRepository
	{
		//取用户
		IEnumerable<User> GetUserByName(string name);
		//取用户
		IEnumerable<User> GetUserByStudentNo(string studentNo);
		//取用户
		IEnumerable<User> GetUserByCollege(string college);
		//取用户
		IEnumerable<User> GetUserByDepartment(string department);
		//取用户
		IEnumerable<User> GetUserByMajor(string major);
		//取全部用户
		IEnumerable<User> GetUsers();
	}
}
