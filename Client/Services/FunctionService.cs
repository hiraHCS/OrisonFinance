using OrisonFinance.Shared;
using OrisonFinance.Shared.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrisonFinance.Client.Services
{
    public class FunctionService
    {

        private IDBOperation idbopn;
        public FunctionService()
        {
        }
        public decimal getVRate()
        {
            return (decimal)idbopn.GetScalar("Select (SellingPrice+((SellingPrice*VATPercen)/100)) as VRate from [Inv].[ItemMaster]");
        }
        public decimal getAmount(string Qty)
        {
            return (decimal)idbopn.GetScalar("Select ((SellingPrice+((SellingPrice*VATPercen)/100))*("+Qty+")) as Amount from [Inv].[ItemMaster]");
        }
    }
     
}