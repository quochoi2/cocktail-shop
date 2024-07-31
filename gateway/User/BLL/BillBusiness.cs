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
	public class BillBusiness : IBillBusiness
	{
		private IBillRepository _res;
		public BillBusiness(IBillRepository res)
		{
			_res = res;
		}

		public List<BillModel> GetAllBill()
		{
			return _res.GetAllBill();
		}

		public BillModel GetDatabyIDBill(int id)
		{
			return _res.GetDatabyIDBill(id);
		}
		public bool CreateBill(BillModel model)
		{
			return _res.CreateBill(model);
		}
		public bool UpdateBill(BillModel model)
		{
			return _res.UpdateBill(model);
		}
		public bool CheckBill(BillModel model)
		{
			return _res.CheckBill(model);
		}
		public List<BillModel> SearchBill(int pageIndex, int pageSize, string ten, out long total)
		{
			return _res.SearchBill(pageIndex, pageSize, ten, out total);
		}
		public List<StatisticsModel> StatisticsUser(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
		{
			return _res.StatisticsUser(pageIndex, pageSize, out total, ten_khach, fr_NgayTao, to_NgayTao);
		}
		public List<BillFromMonth> SearchByMonth(int month, out long total)
		{
			return _res.SearchByMonth(month, out total);
		}
		public List<BillModel> SearchBillByMonth(int pageIndex, int pageSize, DateTime? fr_NgayTao, DateTime? to_NgayTao, out long total)
		{
			return _res.SearchBillByMonth(pageIndex, pageSize, fr_NgayTao, to_NgayTao, out total);
		}
	}
}
