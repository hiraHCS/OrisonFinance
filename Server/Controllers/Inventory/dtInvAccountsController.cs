using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrisonFinance.Server.Data;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Shared.DataModel.Inventory;

namespace OrisonFinance.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class dtInvAccountsController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvAccounts _repository;

        
        public dtInvAccountsController(SqlDbContext context, IWebHostEnvironment environment,IInvAccounts repository)
        {
            _context = context;
            _environment = environment;
            _repository = repository;
        }

        // GET: api/dtInvAccounts?AccCategory=Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtInvAccounts>>> GetdtInvAccounts(string AccCategory)
        {
            return await _repository.GetAccounts(AccCategory);
        //   // return await _context.dtInvAccounts.ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<dtInvAccounts>>> GetdtInvAccountsCategory(string AccCategory, string AccSubCategory)
        {
            return await _repository.GetAccountsByCategory(AccCategory, AccSubCategory);
            // return await _context.dtInvAccounts.ToListAsync();
        }
        // GET: api/dtInvAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtInvAccounts>> GetdtInvAccounts(int id)
        {
            var dtInvAccounts = await _context.dtInvAccounts.FindAsync(id);

            if (dtInvAccounts == null)
            {
                return NotFound();
            }

            return dtInvAccounts;
        }

        // PUT: api/dtInvAccounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtInvAccounts(int id, dtInvAccounts dtInvAccounts)
        {
            if (id != dtInvAccounts.ID)
            {
                return BadRequest();
            }

            _context.Entry(dtInvAccounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtInvAccountsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/dtInvAccounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtInvAccounts>> PostdtInvAccounts(dtInvAccounts dtInvAccounts)
        {
            _context.dtInvAccounts.Add(dtInvAccounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtInvAccounts", new { id = dtInvAccounts.ID }, dtInvAccounts);
        }

        // DELETE: api/dtInvAccounts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtInvAccounts>> DeletedtInvAccounts(int id)
        {
            var dtInvAccounts = await _context.dtInvAccounts.FindAsync(id);
            if (dtInvAccounts == null)
            {
                return NotFound();
            }

            _context.dtInvAccounts.Remove(dtInvAccounts);
            await _context.SaveChangesAsync();

            return dtInvAccounts;
        }

        private bool dtInvAccountsExists(int id)
        {
            return _context.dtInvAccounts.Any(e => e.ID == id);
        }
    }
}
