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
    public class dtInvVoucherAdditionalsController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvVoucherAdditionalsManager _repository;

        public dtInvVoucherAdditionalsController(SqlDbContext context, IWebHostEnvironment environment, IInvVoucherAdditionalsManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        // GET: api/dtInvVoucherAdditionals?VId=10293
        [HttpGet]
        public async Task<IActionResult> Get(long VId)

        {
            return Ok(await _repository.GetVoucherAdditionals(VId));
        }


        //public async Task<ActionResult<IEnumerable<dtInvVoucherAdditionals>>> GetVoucherAdditionals(long VId)
        //{
        //    return await _repository.GetVoucherAdditionals(VId);//_context.dtInvVoucherAdditionals.ToListAsync();
        //}

        // GET: api/dtInvVoucherAdditionals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtInvVoucherAdditionals>> GetdtInvVoucherAdditionals(long id)
        {
            var dtInvVoucherAdditionals = await _context.dtInvVoucherAdditionals.FindAsync(id);

            if (dtInvVoucherAdditionals == null)
            {
                return NotFound();
            }

            return dtInvVoucherAdditionals;
        }

        // PUT: api/dtInvVoucherAdditionals/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtInvVoucherAdditionals(long id, dtInvVoucherAdditionals dtInvVoucherAdditionals)
        {
            if (id != dtInvVoucherAdditionals.VID)
            {
                return BadRequest();
            }

            _context.Entry(dtInvVoucherAdditionals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtInvVoucherAdditionalsExists(id))
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

        // POST: api/dtInvVoucherAdditionals
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtInvVoucherAdditionals>> PostdtInvVoucherAdditionals(dtInvVoucherAdditionals dtInvVoucherAdditionals)
        {
            _context.dtInvVoucherAdditionals.Add(dtInvVoucherAdditionals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtInvVoucherAdditionals", new { id = dtInvVoucherAdditionals.VID }, dtInvVoucherAdditionals);
        }

        // DELETE: api/dtInvVoucherAdditionals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtInvVoucherAdditionals>> DeletedtInvVoucherAdditionals(long id)
        {
            var dtInvVoucherAdditionals = await _context.dtInvVoucherAdditionals.FindAsync(id);
            if (dtInvVoucherAdditionals == null)
            {
                return NotFound();
            }

            _context.dtInvVoucherAdditionals.Remove(dtInvVoucherAdditionals);
            await _context.SaveChangesAsync();

            return dtInvVoucherAdditionals;
        }

        private bool dtInvVoucherAdditionalsExists(long id)
        {
            return _context.dtInvVoucherAdditionals.Any(e => e.VID == id);
        }
    }
}
