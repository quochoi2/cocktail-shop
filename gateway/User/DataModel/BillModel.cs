using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class BillFromMonth
	{
		public int? hdbId { get; set; }
	}
	public class BillModel
	{
		public int? hdbId { get; set; }
		public int? kId { get; set; }
		public DateTime? hdbNgayLap { get; set; }
        public string? hdbMoTa { get; set; }
        public List<BillDetail>? list_json_chitiethoadon { get; set; }
	}
	public class BillDetail
	{
		public int? ctbId { get; set; }
		public int? hdbId { get; set; }
		public int? spId { get; set; }
		public int? ctbSoLuong { get; set; }
		public int? ctbTongTien { get; set; }
	}
}
