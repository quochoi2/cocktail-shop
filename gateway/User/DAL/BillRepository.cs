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

		public List<BillModel> GetAllBill()
		{
			string msgError = "";
			try
			{
				var data = _db.ExecuteQuery("sp_hien_thi_hdb");
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				return data.ConvertTo<BillModel>().ToList();
			}
			catch (Exception ex)
			{

				throw ex;
			}
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
		public bool UpdateBill(BillModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError, 
				"sp_sua_hoa_don_ban",
				"@hdbId", model.hdbId,
				"@kId", model.kId,
				"@hdbNgayLap", model.hdbNgayLap,
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

		public bool CheckBill(BillModel model)
		{
			string msgError = "";
			try
			{
				var result = _db.ExecuteScalarSProcedureWithTransaction(out msgError,
				"sp_kiem_duyet_hoa_don_ban",
				"@hdbId", model.hdbId,
				"@hdbMoTa", model.hdbMoTa);
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

		public List<StatisticsModel> StatisticsUser(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_khach",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten_khach", ten_khach,
					"@fr_NgayTao", fr_NgayTao,
					"@to_NgayTao", to_NgayTao
					 );
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<StatisticsModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<BillModel> SearchBill(int pageIndex, int pageSize, string ten, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_tim_hoa_don",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@ten", ten);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<BillModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<BillFromMonth> SearchByMonth(int month, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_hoa_don",
					"@month", month);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<BillFromMonth>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public List<BillModel> SearchBillByMonth(int pageIndex, int pageSize, DateTime? fr_NgayTao, DateTime? to_NgayTao, out long total)
		{
			string msgError = "";
			total = 0;
			try
			{
				var dt = _db.ExecuteSProcedureReturnDataTable(out msgError, "sp_thong_ke_hoa_don",
					"@page_index", pageIndex,
					"@page_size", pageSize,
					"@fr_NgayTao", fr_NgayTao,
					"@to_NgayTao", to_NgayTao);
				if (!string.IsNullOrEmpty(msgError))
					throw new Exception(msgError);
				if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
				return dt.ConvertTo<BillModel>().ToList();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
