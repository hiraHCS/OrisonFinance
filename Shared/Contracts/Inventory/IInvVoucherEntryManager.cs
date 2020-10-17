
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract.Inventory
{
    public interface IInvVoucherEntryManager : IDisposable
    {
        public  Task<List<dtInvVoucherEntry>> GetVoucherEntry(long vid);

    }
}
