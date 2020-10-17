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
    public class InvItemsManager : IInvItemsManager
    {
        private readonly IDapperManager _dapperManager;

        public InvItemsManager(IDapperManager dapperManager)
        { 
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public async Task<List<dtItems>> GetItems(int BranchId)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("BranchId", BranchId, DbType.Int32);
            dbPara.Add("Criteria", "ItemMaster", DbType.String);
            //dtInvVoucher voucher = new dtInvVoucher();
            var Items = Task.FromResult(_dapperManager.GetAll<dtItems>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara,
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await Items;
        }

    }
}
