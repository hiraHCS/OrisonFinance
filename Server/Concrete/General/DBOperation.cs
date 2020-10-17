using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OrisonFinance.Contracts;
using OrisonFinance.Shared.Contract;

namespace OrisonFinance.Server.Concrete
{
     class DBOperation : IDBOperation
    {
        private readonly IConfiguration _config;
        private readonly IDapperManager _dapperManager;


        //private readonly IDapperManager _dapperManager;

        //public DBOperation(IDapperManager dapperManager)
        //{
        //    this._dapperManager = dapperManager;
        //}
        public DBOperation(IConfiguration config, IDapperManager dapperManager)
        {
            _config = config;
            this._dapperManager = dapperManager;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public DataTable GetTable(string CommandText)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_config.GetConnectionString("RemoteConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            con.Close();
            return dt;

        }

        public  DataTable GetTable(string CommandText, SqlConnection Con)
        {
            DataTable dt = new DataTable();
            Con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, Con);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
            return dt;
        }


        public  DataTable GetTable(string CommandText, SqlConnection Con, SqlTransaction tx)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(CommandText, Con, tx);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            return dt;
        }

        public  DataTable GetTable(string CommandText, String ConnectionString)
        {
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, Con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
            return dt;
        }

        public DataTable GetTable(string CommandText, DataTable dt)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("RemoteConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            con.Close();
            return dt;
        }

        public Object GetScalar(string CommandText, SqlConnection Con)
        {
            Object obj = null;
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                obj = ds.Tables[0].Rows[0][0].ToString();
            }
            return obj;
        }
        public Object GetScalar(string CommandText)
        {
            Object obj = null;
            SqlDataAdapter da = new SqlDataAdapter(CommandText, _config.GetConnectionString("RemoteConnection"));
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                obj = ds.Tables[0].Rows[0][0].ToString();
            }
            return obj;
        }

        public void ExecuteQuery(string CommandText)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("RemoteConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int Query(string CommandText)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("RemoteConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand(CommandText, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return i;
            }
            return 0;
        }
        public int Query(string CommandText, SqlConnection con, SqlTransaction tx)
        {
            SqlCommand cmd = new SqlCommand(CommandText, con, tx);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return i;
            }
            return 0;
        }
        public int QueryIDreturn(string CommandText, SqlConnection con, SqlTransaction tx)
        {
            SqlCommand cmd = new SqlCommand(CommandText, con, tx);
            cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int, 4, ParameterDirection.InputOutput, 16, 0, null, DataRowVersion.Current, false, DBNull.Value, "", "", ""));
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                int id = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                return id;// d;
            }
            return 0;

        }
        public void ExecuteQuery(string CommandText, SqlConnection con, SqlTransaction tx)
        {
            SqlCommand cmd = new SqlCommand(CommandText, con, tx);
            cmd.ExecuteNonQuery();
        }
        public Object GetScalar(string CommandText, SqlConnection Con, SqlTransaction tx)
        {
            Object obj = null;
            SqlCommand Cmd = new SqlCommand(CommandText, Con, tx);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                obj = ds.Tables[0].Rows[0][0].ToString();
            }
            return obj;
        }

        public Object GetScalar(string CommandText, String ConnectionString)
        {
            Object obj = null;
            DataTable dt = new DataTable();
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand Cmd = new SqlCommand(CommandText, Con);
            SqlDataReader sdr = Cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
            if (dt.Rows.Count > 0)
            {
                obj = dt.Rows[0][0];
            }
            return obj;
        }
        public DataTable GetUserInfo(String UserName, String ConnectionString)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select ID,AccountID, UserName,Category, Name from PortalUsers where UserName=@UserName", con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            con.Close();
            return dt;
        }
        public String GetUserAuthenticated(String UserName, String Password, String ConnectionString)
        {
            DataTable dt = new DataTable();
            SqlConnection Con = new SqlConnection(ConnectionString);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select UserName,Password from PortalUsers where UserName=@UserName and Status='Active'", Con);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            Con.Close();
            if (dt.Rows.Count == 0) return "Invalid User!!";
            //if (clsLogic.ComparePassword(dt.Rows[0]["Password"].ToString(), Password)) return "Success";
            //return "Invalid Password!!";
            if (dt.Rows[0]["Password"].ToString()== Password) return "Success";
            return "Invalid Password!!";
        }
        public string NewNumber(int vtype, DateTime d, int _BranchId)
        {

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            con.Open();
            SqlCommand cmd = new SqlCommand("select [dbo].NextNumber( @vtype ,  @BranchId ,  @date )", con);
            cmd.Parameters.AddWithValue("@vtype", vtype);
            cmd.Parameters.AddWithValue("@BranchId", _BranchId);
            cmd.Parameters.AddWithValue("@date", (d));
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            sdr.Close();
            con.Close();
            Object obj = null;
            obj = dt.Rows[0][0];
            return obj.ToString();
        }

        public string PasswordDecode(string Password)
        {
            throw new NotImplementedException();
        }

        public string PasswordEncode(string Pwd)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetVtype(string vtype)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("@Vtype", vtype, DbType.String);
            var Vouchertype = Task.FromResult(_dapperManager.Get<int>($"SELECT ID FROM VTypeTran WHERE VType=@Vtype", dbPara, commandType: CommandType.Text));
            return Vouchertype;
            //($"SELECT * FROM [Article] WHERE Title like '%{search}%' ORDER BY {orderBy} {direction} OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY; ", null, commandType: CommandType.Text));

            // return (int)idbopn.GetScalar("SELECT ID FROM VTypeTran WHERE VType='Sales POS'");
        }

        public Task<int> GetNextNo(int vtype, string d, int _BranchId)
        {
            DateTime dt = DateTime.Parse(d);
            var dbPara = new DynamicParameters();
            dbPara.Add("@Vtype", vtype, DbType.Int32);
            dbPara.Add("@date", dt, DbType.DateTime);
            dbPara.Add("@BranchId", _BranchId, DbType.Int32);
            var Vouchertype = Task.FromResult(_dapperManager.Get<int>("Select cast([dbo].NextNumber(@vtype,@BranchId,@date,NULL) as int)", dbPara, commandType: CommandType.Text));
            return Vouchertype;
        }

    }
}
