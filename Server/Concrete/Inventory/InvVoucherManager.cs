using Dapper;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Contracts;
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OrisonFinance.Server.Concrete.Inventory
{
    class InvVoucherManager:IInvVoucherManager
    {
        private readonly IDapperManager _dapperManager;

        public InvVoucherManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        //public async Task<dtVoucher> GetVoucher(int vid)
        public  async Task<dtInvVoucher> GetVoucher(long VId)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VId", VId, DbType.Int32);
            dbPara.Add("Criteria", "Voucher", DbType.String);
          //dtInvVoucher voucher = new dtInvVoucher();
            var voucher =  Task.FromResult(_dapperManager.Get<dtInvVoucher>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await voucher;
        }
    }
}
