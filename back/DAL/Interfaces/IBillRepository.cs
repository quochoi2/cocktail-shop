﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IBillRepository
	{
		BillModel GetDatabyIDBill(int id);
		bool CreateBill(BillModel model);
	}
}
