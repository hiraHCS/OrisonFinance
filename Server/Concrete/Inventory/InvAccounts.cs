using Dapper;

using OrisonFinance.Contracts;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFinance.Server.Concrete.Inventory
{
    public class InvAccounts:IInvAccounts
    {

        private readonly IDapperManager _dapperManager;

        public InvAccounts(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }
      

        public async Task<List<dtInvAccounts>> GetAccounts(string AccCategory)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccCategory", AccCategory, DbType.String);
            dbPara.Add("Criteria", "AccountMaster", DbType.String);
            //dtInvVoucher voucher = new dtInvVoucher();
            var Accounts = Task.FromResult(_dapperManager.GetAll<dtInvAccounts>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await Accounts;
        }

        public async Task<List<dtInvAccounts>> GetAccountsByCategory(string AccCategory, string AccSubCategory)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("AccCategory", AccCategory, DbType.String);
            dbPara.Add("AccSubCategory", AccSubCategory, DbType.String);
            dbPara.Add("Criteria", "AccountMasterByCategory", DbType.String);
            //dtInvVoucher voucher = new dtInvVoucher();
            var Accounts = Task.FromResult(_dapperManager.GetAll<dtInvAccounts>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await Accounts;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
