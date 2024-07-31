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
	public class ReceiptRepository : IReceiptRepository
	{
		private IDatabaseHelper _db;
		public ReceiptRepository(IDatabaseHelper db)
		{
			_db = db;
		}

		public List<ReceiptModel> GetAllReceipt()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_hien_thi_hdn");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<ReceiptModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public ReceiptModel GetDatabyIDReceipt(int id)
		{
			string msgError = "";
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError,
					 "sp_hien_thi_hoa_don_nhap",
					 "@MaHoaDon", id);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return dt.ConvertTo<ReceiptModel>().FirstOrDefault();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool CreateReceipt(ReceiptModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_them_hoa_don_nhap",
				"@nId", model.nId,
				"@hdnNgayLap", model.hdnNgayLap,
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

		public bool UpdateReceipt(ReceiptModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_sua_hoa_don_nhap",
				"@hdnId", model.hdnId,
				"@nId", model.nId,
				"@hdnNgayLap", model.hdnNgayLap,
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
