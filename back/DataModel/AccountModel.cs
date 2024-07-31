using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AccountModel
    {
		public int? tId { get; set; }
		public string? tTaiKhoan { get; set; }
		public string? tMatKhau { get; set; }
        public string? kTen { get; set; }
        public string? tLoai { get; set; }
		public string? token { get; set; }
	}

}
