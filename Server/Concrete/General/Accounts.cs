using Dapper;

using OrisonFinance.Contracts;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Shared.Contracts.General;
using OrisonFinance.Shared.DataModel.Inventory;
using OrisonFinance.Shared.Models.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFinance.Server.Concrete.Inventory
{
    public class Accounts : IAccounts
    {

        private readonly IDapperManager _dapperManager;

        public Accounts(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public async Task<List<LoginModel>> LoginUserNew(string UserName,string Password)
        {
            var dbPara = new DynamicParameters();
            //dbPara.Add("Criteria", "AccountMaster", DbType.String);
            var Accounts = Task.FromResult(_dapperManager.GetAll<LoginModel>
                                ("Select ID,UserName,Password from [dbo].[Users]", dbPara,
                                commandType: CommandType.Text));
            return await Accounts;
        }

    }
}
