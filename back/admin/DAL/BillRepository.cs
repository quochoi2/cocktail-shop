using DAL.Interfaces;
using DataAccessLayer;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class BillRepository : IBillRepository
	{
		private IDatabaseHelper _db;
		public BillRepository(IDatabaseHelper helper)
		{
			_db = helper;
		}

		public BillModel GetDatabyIDBill(int id)
		{
			string msgError = "";
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, 
					 "sp_hien_thi_hoa_don_ban",
					 "@MaHoaDon", id);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return dt.ConvertTo<BillModel>().FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool CreateBill(BillModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, 
				"sp_them_hoa_don_ban",
				"@kId", model.kId,
				"@hdbNgayLap", model.hdbNgayLap,
				"@hdbMoTa", model.hdbMoTa,
				"@list_json_chitiethoadon", model.list_json_chitiethoadon != null ? MessageConvert.SerializeObject(model.list_json_chitiethoadon) : null);
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
		
	}
}
