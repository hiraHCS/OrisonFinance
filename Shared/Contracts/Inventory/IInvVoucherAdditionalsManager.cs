
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract.Inventory
{
    public interface IInvVoucherAdditionalsManager :IDisposable
    {
        public Task<dtInvVoucherAdditionals> GetVoucherAdditionals(long VId);

    }
}
