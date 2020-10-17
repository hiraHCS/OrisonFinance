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
        Task<IEnumerable<LoginModel>> LoginUserNew1(string Username, string Password);
        Task<IEnumerable<LoginModel>> LoginUserNew2(string Username, string Password);
        Task<IEnumerable<LoginModel>> LoginUserNew3(string Username, string Password);
        Task<IEnumerable<LoginModel>> LoginUserNew4(string Username, string Password);
        Task<IEnumerable<LoginModel>> LoginUserNew5(string Username, string Password);
        Task<IEnumerable<LoginModel>> Roshanshan(string Username, string Password);

    }
}
