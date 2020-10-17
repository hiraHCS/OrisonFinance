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
     class InvTransactionsManager:IInvTransactionsManager
    {
        private readonly IDapperManager _dapperManager;

        public InvTransactionsManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        

        public async Task<List<dtInvTransactions>> GetTransactions(long vid)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VId", vid, DbType.Int32);
            dbPara.Add("Criteria", "Transactions", DbType.String);
            //dtInvVoucher voucher = new dtInvVoucher();
            var voucherentry = Task.FromResult(_dapperManager.GetAll<dtInvTransactions>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await voucherentry;

        }

    }
}
