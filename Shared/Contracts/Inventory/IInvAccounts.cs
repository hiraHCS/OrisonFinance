
using OrisonFinance.Shared.DataModel.Inventory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract.Inventory
{
    public interface IInvAccounts : IDisposable
    {
        public Task<List<dtInvAccounts>> GetAccounts(string AccCategory);
        public Task<List<dtInvAccounts>> GetAccountsByCategory(string AccCategory, string AccSubCategory);
    }
}
