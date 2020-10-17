using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrisonFinance.Shared.Contract.Inventory;
using OrisonFinance.Server.Data;
using OrisonFinance.Shared.DataModel.Inventory;

namespace Orison.Server.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class dtInvTransactionsController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvTransactionsManager _repository;

        public dtInvTransactionsController(SqlDbContext context, IWebHostEnvironment environment, IInvTransactionsManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/dtInvTransactions?VId=10293
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtInvTransactions>>> GetTransactions(long VId)
        {
            return await _repository.GetTransactions(VId);
          //  return await _context.dtInvTransactions.ToListAsync();
        }

        // GET: api/dtInvTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtInvTransactions>> GetdtInvTransactions(long id)
        {
            var dtInvTransactions = await _context.dtInvTransactions.FindAsync(id);

            if (dtInvTransactions == null)
            {
                return NotFound();
            }

            return dtInvTransactions;
        }

        // PUT: api/dtInvTransactions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtInvTransactions(long id, dtInvTransactions dtInvTransactions)
        {
            if (id != dtInvTransactions.ID)
            {
                return BadRequest();
            }

            _context.Entry(dtInvTransactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtInvTransactionsExists(id))
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

        // POST: api/dtInvTransactions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtInvTransactions>> PostdtInvTransactions(dtInvTransactions dtInvTransactions)
        {
            _context.dtInvTransactions.Add(dtInvTransactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtInvTransactions", new { id = dtInvTransactions.ID }, dtInvTransactions);
        }

        // DELETE: api/dtInvTransactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtInvTransactions>> DeletedtInvTransactions(long id)
        {
            var dtInvTransactions = await _context.dtInvTransactions.FindAsync(id);
            if (dtInvTransactions == null)
            {
                return NotFound();
            }

            _context.dtInvTransactions.Remove(dtInvTransactions);
            await _context.SaveChangesAsync();

            return dtInvTransactions;
        }

        private bool dtInvTransactionsExists(long id)
        {
            return _context.dtInvTransactions.Any(e => e.ID == id);
        }
    }
}
