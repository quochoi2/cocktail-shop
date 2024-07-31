using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
		List<UserModel> GetAllUser();
		UserModel GetDataByIdUser(string id);
        bool UpdateUser(UserModel model);
		bool DeleteUser(string id);
		List<UserModel> SearchUser(int pageIndex, int pageSize, string ten_khach, out long total);
	}
}
