using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class ManafactureRepository : IManafactureRespository
	{
		private IDatabaseHelper _db;
		public ManafactureRepository(IDatabaseHelper db)
		{
			_db = db;
		}
		public List<ManafactureModel> GetAllManafacture()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_hien_thi_nha_san_xuat");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ManafactureModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		
		public ManafactureModel GetDataByIdManafacture(string id)
		{
			string msgError = "";
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_kiem_nha_san_xuat",
					 "@nId", id);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return dt.ConvertTo<ManafactureModel>().FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool CreateManafacture(ManafactureModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_them_nha_san_xuat",
				"@nTen", model.nTen,
				"@nSdt", model.nSdt,
				"@nDiaChi", model.nDiaChi,
				"@nEmail", model.nEmail);


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
		public bool UpdateManafacture(ManafactureModel md)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sua_nha_san_xuat",
				"@nId", md.nId,
				"@nTen", md.nTen,
				"@nSdt", md.nSdt,
				"@nDiaChi", md.nDiaChi,
				"@nEmail", md.nEmail);

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
		public bool DeleteManafacture(string id)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, 
					"sp_xoa_nha_san_xuat",
					"@nId", id);
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

		public List<ManafactureModel> SearchManafacture(int pageIndex, int pageSize, string ten, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_nha_san_xuat",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten", ten);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<ManafactureModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
