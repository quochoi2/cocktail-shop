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
    public class AccountRepository : IAccountRepository
    {
        private IDatabaseHelper _db;

        public AccountRepository(IDatabaseHelper db)
        {
            _db = db;
        }

        public AccountModel Login(string username, string password)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
                    "sp_tai_khoan",
					"@taiKhoan", username,
					"@matKhau", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List< AccountModel > GetAll()
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteQuery( "sp_hien_thi_tai_khoan");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return data.ConvertTo<AccountModel>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public AccountModel GetDataById(string id)
        {
            string msgError = "";
            try
            {
                var data = _db.ExecuteSProcedureReturnDataTable(
                    out msgError,
					"sp_tim_kiem_tai_khoan", 
                    "@tId", id);
                if (!string.IsNullOrEmpty(msgError)) 
                    throw new Exception(msgError);
                return data.ConvertTo<AccountModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Create(AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
                "sp_them_tai_khoan",
                "@tTaiKhoan", model.tTaiKhoan,
                "@tMatKhau", model.tMatKhau,
				"@kTen", model.kTen,
				"@tLoai", model.tLoai);


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

        public bool Update(AccountModel model)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_tai_khoan",
                "@tId", model.tId,
				"@tMatKhau", model.tMatKhau);
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_xoa_tai_khoan",
                "@tId", id);
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

		public List<AccountModel> SearchAccount(int pageIndex, int pageSize, string ten, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_tai_khoan",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten", ten);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<AccountModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
