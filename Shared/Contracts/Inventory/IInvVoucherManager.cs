
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract.Inventory
{
    public interface IInvVoucherManager : IDisposable
    {
        //public  Task<dtInvVoucher> GetVoucher(long id);
        public  Task<dtInvVoucher> GetVoucher(long VId);
        public Task<dtInvVoucher> CreateVoucher(dtInvVoucher InvVoucher);
        //public Task<List<dtInvVoucher>> CreateVoucher(List<dtInvVoucher> InvVoucher);

    }
}
