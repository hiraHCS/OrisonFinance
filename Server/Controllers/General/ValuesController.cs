using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisonFinance.Server.Data;
using OrisonFinance.Shared.Contract;

namespace OrisonFinance.Server.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IDBOperation _repository;
        public ValuesController(SqlDbContext context, IWebHostEnvironment environment, IDBOperation repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        // GET: api/values/'Sales POS'
        [HttpGet("{vtype}")]
        public async Task<int> GetVtype(string vtype)

        {
            return await _repository.GetVtype(vtype);
        }

        // GET: api/values/5/10-10-2020/31
        [HttpGet("{vtype}/{d}/{_BranchId}")]
        public async Task<int> GetVNo(int vtype, string d, int _BranchId)

        {
            return await _repository.GetNextNo(vtype, d, _BranchId);
        }
    }
}
