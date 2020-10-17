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
    public class dtInvVoucherEntriesController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvVoucherEntryManager _repository;


        public dtInvVoucherEntriesController(SqlDbContext context, IWebHostEnvironment environment, IInvVoucherEntryManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            
        }

        // GET: api/dtInvVoucherEntries?VId=10293
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtInvVoucherEntry>>> GetVoucherEntry(long VId)
        {
            return await _repository.GetVoucherEntry(VId);
           // return await _context.dtInvVoucherEntry.ToListAsync();
        }

        // GET: api/dtInvVoucherEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtInvVoucherEntry>> GetdtInvVoucherEntry(long id)
        {
            var dtInvVoucherEntry = await _context.dtInvVoucherEntry.FindAsync(id);

            if (dtInvVoucherEntry == null)
            {
                return NotFound();
            }

            return dtInvVoucherEntry;
        }

        // PUT: api/dtInvVoucherEntries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtInvVoucherEntry(long id, dtInvVoucherEntry dtInvVoucherEntry)
        {
            if (id != dtInvVoucherEntry.ID)
            {
                return BadRequest();
            }

            _context.Entry(dtInvVoucherEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtInvVoucherEntryExists(id))
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

        // POST: api/dtInvVoucherEntries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtInvVoucherEntry>> PostdtInvVoucherEntry(dtInvVoucherEntry dtInvVoucherEntry)
        {
            _context.dtInvVoucherEntry.Add(dtInvVoucherEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtInvVoucherEntry", new { id = dtInvVoucherEntry.ID }, dtInvVoucherEntry);
        }

        // DELETE: api/dtInvVoucherEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtInvVoucherEntry>> DeletedtInvVoucherEntry(long id)
        {
            var dtInvVoucherEntry = await _context.dtInvVoucherEntry.FindAsync(id);
            if (dtInvVoucherEntry == null)
            {
                return NotFound();
            }

            _context.dtInvVoucherEntry.Remove(dtInvVoucherEntry);
            await _context.SaveChangesAsync();

            return dtInvVoucherEntry;
        }

        private bool dtInvVoucherEntryExists(long id)
        {
            return _context.dtInvVoucherEntry.Any(e => e.ID == id);
        }
    }
}
