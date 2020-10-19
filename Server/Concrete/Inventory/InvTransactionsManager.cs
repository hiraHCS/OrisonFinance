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

        //public Task<int> Create(dtInvTransactions sale)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("ItemCode", sale.ItemCode, DbType.String);
        //    dbPara.Add("Qty", sale.Qty, DbType.String);
        //    dbPara.Add("Unit", sale.Unit, DbType.String);
        //    dbPara.Add("VAT", sale.VAT, DbType.String);
        //    dbPara.Add("Rate", sale.Rate, DbType.String);
        //    dbPara.Add("VRate", sale.VRate, DbType.String);
        //    dbPara.Add("Description", sale.Description, DbType.String);
        //    dbPara.Add("Amount", sale.Amount, DbType.String);
        //    dbPara.Add("SubTotal", sale.SubTotal, DbType.String);
        //    dbPara.Add("Discount", sale.Discount, DbType.String);
        //    var saleId = Task.FromResult(_dapperManager.Insert<int>("[dbo].[SPVoucher]",
        //                    dbPara,
        //                    commandType: CommandType.StoredProcedure));
        //    return saleId;
        //}

        //public async Task<List<dtInvTransactions>> PutdtInvTransactions(long id, dtInvTransactions dtInvTransactions)
        //{

        //}

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
