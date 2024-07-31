using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IReceiptRepository
	{
		List<ReceiptModel> GetAllReceipt();
		ReceiptModel GetDatabyIDReceipt(int id);
		bool CreateReceipt(ReceiptModel model);
		bool UpdateReceipt(ReceiptModel model);
	}
}
