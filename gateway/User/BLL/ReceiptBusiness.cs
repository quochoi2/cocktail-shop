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
	public class ReceiptBusiness : IReceiptBusiness
	{
		private IReceiptRepository _res;
		public ReceiptBusiness(IReceiptRepository res)
		{
			_res = res;
		}

		public List<ReceiptModel> GetAllReceipt()
		{
			return _res.GetAllReceipt();
		}
		public ReceiptModel GetDatabyIDReceipt(int id)
		{
			return _res.GetDatabyIDReceipt(id);
		}

		public bool CreateReceipt(ReceiptModel model)
		{
			return _res.CreateReceipt(model);
		}

		public bool UpdateReceipt(ReceiptModel model)
		{
			return _res.UpdateReceipt(model);
		}
	}
}
