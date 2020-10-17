using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrisonFinance.Shared.Contract;
using OrisonFinance.Server.Data;
using OrisonFinance.Shared.DataModel;
using OrisonFinance.Shared.Models.General;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using OrisonFinance.Shared.Contracts.General;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace OrisonFinance.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly SqlConnectionConfiguration _configuration;

        public AccountsController(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("LoginUserNew")]
        public async Task<IEnumerable<LoginModel>> LoginUserNew(LoginModel User)
        {
            IEnumerable<LoginModel> enumUser;
            var parameters = new DynamicParameters();
            parameters.Add("@UserName", User.Username, DbType.String);
            parameters.Add("@Password", User.Password, DbType.String);


            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    enumUser = await conn.QueryAsync<LoginModel>("FINWEB_UserLoginSP", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return enumUser;
        }
    }
}
