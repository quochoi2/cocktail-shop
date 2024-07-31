using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class StatisticsModel
    {
        public string kTen { get; set; }
        public string kDiaChi { get; set; }
        public DateOnly hdbNgayLap { get; set; }
        public int spId { get; set; }
        public string sTen { get; set; }
        public int ctbSoLuong { get; set; }
        public int ctbTongTien { get; set; }
    }
}