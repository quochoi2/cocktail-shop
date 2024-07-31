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
		UserModel GetIdKhach(string username, string password);
		List<UserModel> SearchUser(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi);
	}
}
