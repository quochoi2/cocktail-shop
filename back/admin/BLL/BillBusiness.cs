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

		public BillModel GetDatabyIDBill(int id)
		{
			return _res.GetDatabyIDBill(id);
		}
		public bool CreateBill(BillModel model)
		{
			return _res.CreateBill(model);
		}
	}
}
