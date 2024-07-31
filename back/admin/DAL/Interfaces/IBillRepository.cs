using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IBillRepository
	{
		List<BillModel> GetAllBill();
		BillModel GetDatabyIDBill(int id);
		bool CreateBill(BillModel model);
		bool UpdateBill(BillModel model);
		bool CheckBill(BillModel model);
		List<BillModel> SearchBill(int pageIndex, int pageSize, string ten, out long total);
		List<StatisticsModel> StatisticsUser(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);
		List<BillFromMonth> SearchByMonth(int month, out long total);
		List<BillModel> SearchBillByMonth(int pageIndex, int pageSize, DateTime? fr_NgayTao, DateTime? to_NgayTao, out long total);
	}
}
