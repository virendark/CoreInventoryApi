using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblOutletsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public TblOutletsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/TblOutlets
        [HttpGet]
        public IEnumerable<TblOutlet> GetTblOutlets()
        {
            return _context.TblOutlets;
        }

        // GET: api/TblOutlets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblOutlet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblOutlet = await _context.TblOutlets.FindAsync(id);

            if (tblOutlet == null)
            {
                return NotFound();
            }

            return Ok(tblOutlet);
        }

        // PUT: api/TblOutlets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblOutlet([FromRoute] int id, [FromBody] TblOutlet tblOutlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblOutlet.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblOutlet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblOutletExists(id))
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

        // POST: api/TblOutlets
        [HttpPost]
        public async Task<IActionResult> PostTblOutlet([FromBody] TblOutlet tblOutlet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblOutlets.Add(tblOutlet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblOutlet", new { id = tblOutlet.Id }, tblOutlet);
        }

        // DELETE: api/TblOutlets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblOutlet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblOutlet = await _context.TblOutlets.FindAsync(id);
            if (tblOutlet == null)
            {
                return NotFound();
            }

            _context.TblOutlets.Remove(tblOutlet);
            await _context.SaveChangesAsync();

            return Ok(tblOutlet);
        }

        private bool TblOutletExists(int id)
        {
            return _context.TblOutlets.Any(e => e.Id == id);
        }
    }
}