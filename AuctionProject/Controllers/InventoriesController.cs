using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuctionProject.Models;

namespace AuctionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly AuctionProjectDBContext _context;

        public InventoriesController(AuctionProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInventory>>> GetTblInventories()
        {
            return await _context.TblInventories.ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInventory>> GetTblInventory(int id)
        {
            var tblInventory = await _context.TblInventories.FindAsync(id);

            if (tblInventory == null)
            {
                return NotFound();
            }

            return tblInventory;
        }

        // PUT: api/Inventories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInventory(int id, TblInventory tblInventory)
        {
            if (id != tblInventory.InventoryId)
            {
                return BadRequest();
            }

            _context.Entry(tblInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInventoryExists(id))
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

        // POST: api/Inventories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblInventory>> PostTblInventory(TblInventory tblInventory)
        {
            _context.TblInventories.Add(tblInventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblInventory", new { id = tblInventory.InventoryId }, tblInventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInventory>> DeleteTblInventory(int id)
        {
            var tblInventory = await _context.TblInventories.FindAsync(id);
            if (tblInventory == null)
            {
                return NotFound();
            }

            _context.TblInventories.Remove(tblInventory);
            await _context.SaveChangesAsync();

            return tblInventory;
        }

        private bool TblInventoryExists(int id)
        {
            return _context.TblInventories.Any(e => e.InventoryId == id);
        }
    }
}
