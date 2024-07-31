using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IReceiptBusiness
	{
		List<ReceiptModel> GetAllReceipt();
		ReceiptModel GetDatabyIDReceipt(int id);
		bool CreateReceipt(ReceiptModel model);
		bool UpdateReceipt(ReceiptModel model);
	}
}
