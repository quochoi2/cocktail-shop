using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ReceiptModel
	{
		public int hdnId { get; set; }
		public int nId { get; set; }
		public string hdnNgayLap { get; set; }
		public List<ReceiptDetail> list_json_chitiethoadon { get; set; }
	}
	public class ReceiptDetail
	{
		public int ctnId { get; set; }
		public int hdnId { get; set; }
		public int spId { get; set; }
		public int ctnSoLuong { get; set; }
		public int ctnTongTien { get; set; }
	}
}
