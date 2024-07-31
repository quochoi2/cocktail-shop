using BLL.Interfaces;
using DAL.Interfaces;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _res;
        public UserBusiness(IUserRepository res)
        {
            _res = res;
        }
		public List<UserModel> GetAllUser()
		{
			return _res.GetAllUser();
		}
		public UserModel GetDataByIdUser(string id)
        {
            return _res.GetDataByIdUser(id);
        }
        public bool UpdateUser(UserModel model)
        {
            return _res.UpdateUser(model);
        }
		public bool DeleteUser(string id)
		{
			return _res.DeleteUser(id);
		}
		public List<UserModel> SearchUser(int pageIndex, int pageSize, string ten_khach, out long total)
        {
            return _res.SearchUser(pageIndex, pageSize, ten_khach, out total);
        }
	}
}
