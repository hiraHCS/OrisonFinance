using OrisonFinance.Shared.Models.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contracts.General
{
    public interface IAccounts:IDisposable
    {
        Task<IEnumerable<LoginModel>> LoginUserNew(string Username,string Password);
    }
}
