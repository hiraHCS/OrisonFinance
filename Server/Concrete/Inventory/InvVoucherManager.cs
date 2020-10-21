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

        //public Task<dtInvVoucher> CreateVoucher(dtInvVoucher InvVoucher)
        //{
        //    var dbPara = new DynamicParameters();
        //    dbPara.Add("VNo", InvVoucher.VNo, DbType.String);
        //    dbPara.Add("EffectiveDate", InvVoucher.EffectiveDate, DbType.String);
        //    dbPara.Add("VDate", InvVoucher.VDate, DbType.String);
        //    dbPara.Add("DueDate", InvVoucher.DueDate, DbType.String);
        //    dbPara.Add("CreatedDate", InvVoucher.CreatedDate, DbType.String);
        //    dbPara.Add("ModifiedDate", InvVoucher.ModifiedDate, DbType.String);
        //    dbPara.Add("StaffName", InvVoucher.StaffName, DbType.String);
        //    dbPara.Add("VType", InvVoucher.VType, DbType.String);
        //    dbPara.Add("BranchID", InvVoucher.BranchID, DbType.String);
        //    dbPara.Add("VATAmt", InvVoucher.VATAmt, DbType.String);
        //    dbPara.Add("VATPaid", InvVoucher.VATPaid, DbType.String);
        //    dbPara.Add("VRound", InvVoucher.VRound, DbType.String);
        //    dbPara.Add("SubTotal", InvVoucher.SubTotal, DbType.String);
        //    dbPara.Add("IsCanceled", InvVoucher.IsCanceled, DbType.String);
        //    dbPara.Add("CreatedUserID", InvVoucher.CreatedUserID, DbType.String);
        //    dbPara.Add("ModifiedUserID", InvVoucher.ModifiedUserID, DbType.String);
        //    dbPara.Add("ExchangeRate", InvVoucher.ExchangeRate, DbType.String);
        //    dbPara.Add("Currency", InvVoucher.Currency, DbType.String);
        //    var VId = Task.FromResult(_dapperManager.Insert<dtInvVoucher>("[VoucherSP]",
        //                    dbPara,
        //                    commandType: CommandType.StoredProcedure));
        //    return VId;
        //}

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
