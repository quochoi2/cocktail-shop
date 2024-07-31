﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountBusiness
    {
		AccountModel Login(string username, string password);
		AccountModel GetDataById(string id);
		bool Create(AccountModel model);
		bool Update(AccountModel model);
	}
}
