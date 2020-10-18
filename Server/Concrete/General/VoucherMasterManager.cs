using Dapper;

using OrisonFinance.Contracts;
using OrisonFinance.Shared.Contract;
using OrisonFinance.Shared.DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Server.Concrete
{
    class VoucherMasterManager: IVoucherMasterManager
    {
        private readonly IDapperManager _dapperManager;

        public VoucherMasterManager(IDapperManager dapperManager)
        {
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<VoucherMaster>> ListAll(int vtype)
        //(int skip, int take, string orderBy, string direction = "DESC", string search = "")
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VType", vtype, DbType.Int32);
            dbPara.Add("BranchId", 31, DbType.Int32);
            dbPara.Add("Criteria", "VoucherMaster", DbType.String);
            var vouchermaster = Task.FromResult(_dapperManager.GetAll<VoucherMaster>
                                ("[FINWEB_INVENTORYVoucherSP]", dbPara, 
                                commandType: CommandType.StoredProcedure));
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));
            return await vouchermaster;
        }
        public Task<int> Count()
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("VType", 5, DbType.Int32);
            dbPara.Add("BranchId", 31, DbType.Int32);
            var totArticle = Task.FromResult(_dapperManager.Get<int>($"select COUNT(*) from [voucher] WHERE Vtype=@VType and branchid=@BranchId",dbPara,
                    commandType: CommandType.Text));
            return totArticle;
        }

    }
}
