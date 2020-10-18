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

namespace Orison.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherMastersController : ControllerBase
    {
        private  SqlDbContext _context;
        private  IWebHostEnvironment _environment;
        private IVoucherMasterManager _repository;
        public VoucherMastersController(SqlDbContext context, IWebHostEnvironment environment, IVoucherMasterManager repository)
        {
            _environment = environment;
            _context = context;
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        //private readonly SqlDbContext _context;

        //public VoucherMastersController(SqlDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/VoucherMasters?vtype=75
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<VoucherMaster>>> GetVoucherMaster(int vtype)
        {
            //return (await _repository.ListAll(vtype));
            return await _repository.ListAll(vtype);
            //return await _context.VoucherMaster.ToListAsync();
        }

        // GET: api/VoucherMasters/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<VoucherMaster>> GetVoucherMasterAll(long id)
        //{
        //    var voucherMaster = await _context.VoucherMaster.FindAsync(id);

        //    if (voucherMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return voucherMaster;
        //}
        [HttpGet("{id}")]
        public async Task<ActionResult<VoucherMaster>> GetVoucherMaster1(int id)
        {
            var voucherMaster = await _repository.ListAll(id);

            if (voucherMaster == null)
            {
                return NotFound();
            }

            return voucherMaster.FirstOrDefault();
    }

        // PUT: api/VoucherMasters/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucherMaster(long id, VoucherMaster voucherMaster)
        {
            if (id != voucherMaster.ID)
            {
                return BadRequest();
            }

            _context.Entry(voucherMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherMasterExists(id))
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

        // POST: api/VoucherMasters
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VoucherMaster>> PostVoucherMaster(VoucherMaster voucherMaster)
        {
            _context.VoucherMaster.Add(voucherMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoucherMaster", new { id = voucherMaster.ID }, voucherMaster);
        }

        // DELETE: api/VoucherMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VoucherMaster>> DeleteVoucherMaster(long id)
        {
            var voucherMaster = await _context.VoucherMaster.FindAsync(id);
            if (voucherMaster == null)
            {
                return NotFound();
            }

            _context.VoucherMaster.Remove(voucherMaster);
            await _context.SaveChangesAsync();

            return voucherMaster;
        }

        private bool VoucherMasterExists(long id)
        {
            return _context.VoucherMaster.Any(e => e.ID == id);
        }
    }
}
