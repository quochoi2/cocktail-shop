using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _db;

        public UserRepository(IDatabaseHelper db)
        {
            _db = db;
        }

		public List<UserModel> GetAllUser()
        {
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_hien_thi_khach_hang");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<UserModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public UserModel GetDataByIdUser(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
					"sp_tim_kiem_khach_hang", 
                    "@kid", id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool UpdateUser(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_khach_hang",
				"@kId", model.kId,
				"@tId", model.tId,
				"@kTen", model.kTen,
				"@kSdt", model.kSdt,
				"@kDiaChi", model.kDiaChi,
				"@kEmail", model.kEmail);

                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		public bool DeleteUser(string id)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_khach_hang",
				"@kId", id);
				;
				if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
				{
					throw new Exception(Convert.ToString(result) + msgError);
				}
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<UserModel> SearchUser(int pageIndex, int pageSize, string ten_khach, out long total)
        {
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_khach",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten", ten_khach);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<UserModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
