using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace OrisonFinance.Shared.Contract
{
   public interface IDBOperation
    {
        public DataTable GetTable(string CommandText);
        public DataTable GetTable(string CommandText, SqlConnection Con);
        public DataTable GetTable(string CommandText, SqlConnection Con, SqlTransaction tx);
        public DataTable GetTable(string CommandText, String ConnectionString);
        public DataTable GetTable(string CommandText, DataTable dt);
        public Object GetScalar(string CommandText);
        public Object GetScalar(string CommandText, SqlConnection Con);
        public void ExecuteQuery(string CommandText);
        public int Query(string CommandText);
        public int Query(string CommandText, SqlConnection con, SqlTransaction tx);
        public int QueryIDreturn(string CommandText, SqlConnection con, SqlTransaction tx);
        public void ExecuteQuery(string CommandText, SqlConnection con, SqlTransaction tx);
        public Object GetScalar(string CommandText, SqlConnection Con, SqlTransaction tx);
        Task<int> GetVtype(string vtype);
        public Object GetScalar(string CommandText, String ConnectionString);
        public DataTable GetUserInfo(String UserName, String ConnectionString);
        Task<int> GetNextNo(int vtype, string d, int branchId);
        public String GetUserAuthenticated(String UserName, String Password, String ConnectionString);


        public String NewNumber(int vtype, DateTime d, int _BranchId);

        public String PasswordDecode(string Pwd);
        public String PasswordEncode(string Pwd);








    }
}
