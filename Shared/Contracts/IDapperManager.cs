using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace OrisonFinance.Contracts
{
    public interface IDapperManager : IDisposable
    {
        DbConnection GetConnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    }
}
