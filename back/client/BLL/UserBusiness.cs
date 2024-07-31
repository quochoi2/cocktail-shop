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
		public UserModel GetIdKhach(string username, string password)
		{
			return _res.GetIdKhach(username, password);
		}
		public List<UserModel> SearchUser(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            return _res.SearchUser(pageIndex, pageSize, out total, ten_khach, dia_chi);
        }
	}
}
