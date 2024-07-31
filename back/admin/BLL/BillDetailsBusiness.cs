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
	public class BillDetailsBusiness : IBillDetailsBusiness
	{
		private IBillDetaislRepository _res;
		public BillDetailsBusiness(IBillDetaislRepository res)
		{
			_res = res;
		}

		public BillDetail GetAllByIdBill(int id)
		{
			return _res.GetAllByIdBill(id);
		}

		public bool DeleteBillDetail(string id)
		{
			return _res.DeleteBillDetail(id);
		}
	}
}
