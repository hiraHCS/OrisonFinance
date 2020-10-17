
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
       


    }
}
