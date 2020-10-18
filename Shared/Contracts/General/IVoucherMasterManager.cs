
using OrisonFinance.Shared.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract
{
   public  interface IVoucherMasterManager : IDisposable
    {
        public Task<List<VoucherMaster>> ListAll(int vtype);
        public Task<int> Count();
    }
}
