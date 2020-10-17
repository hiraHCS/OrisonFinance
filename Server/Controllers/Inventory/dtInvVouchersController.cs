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

namespace OrisonFinance.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class dtInvVouchersController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvVoucherManager _repository;


        public dtInvVouchersController(SqlDbContext context, IWebHostEnvironment environment, IInvVoucherManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        // GET: api/dtInvVouchers?vid=10293
        [HttpGet]
        //public Task<IActionResult> Get(int VId)
        //public  Task<dtInvVoucher> Get(long VId)
        public async Task<IActionResult> Get(long VId)

        {
            return Ok(await _repository.GetVoucher(VId));
        }


        // GET: api/dtInvVouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtInvVoucher>> GetdtInvVoucher(long id)
        {
            var dtInvVoucher = await _context.dtInvVoucher.FindAsync(id);

            if (dtInvVoucher == null)
            {
                return NotFound();
            }

            return dtInvVoucher;
            
        }

        // PUT: api/dtInvVouchers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtInvVoucher(long id, dtInvVoucher dtInvVoucher)
        {
            if (id != dtInvVoucher.ID)
            {
                return BadRequest();
            }

            _context.Entry(dtInvVoucher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtInvVoucherExists(id))
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

        // POST: api/dtInvVouchers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtInvVoucher>> PostdtInvVoucher(dtInvVoucher dtInvVoucher)
        {
            _context.dtInvVoucher.Add(dtInvVoucher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtInvVoucher", new { id = dtInvVoucher.ID }, dtInvVoucher);
        }

        // DELETE: api/dtInvVouchers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtInvVoucher>> DeletedtInvVoucher(long id)
        {
            var dtInvVoucher = await _context.dtInvVoucher.FindAsync(id);
            if (dtInvVoucher == null)
            {
                return NotFound();
            }

            _context.dtInvVoucher.Remove(dtInvVoucher);
            await _context.SaveChangesAsync();

            return dtInvVoucher;
        }

        private bool dtInvVoucherExists(long id)
        {
            return _context.dtInvVoucher.Any(e => e.ID == id);
        }
    }
}
