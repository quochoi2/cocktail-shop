﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IBillDetaislRepository
	{
		BillDetail GetAllByIdBill(int id);
		bool DeleteBillDetail(string id);
	}
}
