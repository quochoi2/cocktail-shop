﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAccountRepository
    {
        List<AccountModel> GetAll();
        AccountModel Login(string username, string password);
        AccountModel GetDataById(string id);
        bool Create(AccountModel model);
        bool Update(AccountModel model);
        bool Delete(string id);
		List<AccountModel> SearchAccount(int pageIndex, int pageSize, string ten, out long total);
	}
}
