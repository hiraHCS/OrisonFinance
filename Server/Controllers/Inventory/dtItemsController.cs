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
    public class dtItemsController : ControllerBase
    {
        private readonly SqlDbContext _context;
        private IWebHostEnvironment _environment;
        private IInvItemsManager _repository;


        public dtItemsController(SqlDbContext context, IWebHostEnvironment environment, IInvItemsManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        // GET: api/dtItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dtItems>>> GetdtItems()
        {
            return await _repository.GetItems(31);
            //return await _context.dtItems.ToListAsync();
        }

        // GET: api/dtItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dtItems>> GetdtItems(int id)
        {
            var dtItems = await _context.dtItems.FindAsync(id);

            if (dtItems == null)
            {
                return NotFound();
            }

            return dtItems;
        }

        // PUT: api/dtItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdtItems(int id, dtItems dtItems)
        {
            if (id != dtItems.ID)
            {
                return BadRequest();
            }

            _context.Entry(dtItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dtItemsExists(id))
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

        // POST: api/dtItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<dtItems>> PostdtItems(dtItems dtItems)
        {
            _context.dtItems.Add(dtItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetdtItems", new { id = dtItems.ID }, dtItems);
        }

        // DELETE: api/dtItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<dtItems>> DeletedtItems(int id)
        {
            var dtItems = await _context.dtItems.FindAsync(id);
            if (dtItems == null)
            {
                return NotFound();
            }

            _context.dtItems.Remove(dtItems);
            await _context.SaveChangesAsync();

            return dtItems;
        }

        private bool dtItemsExists(int id)
        {
            return _context.dtItems.Any(e => e.ID == id);
        }
    }
}
