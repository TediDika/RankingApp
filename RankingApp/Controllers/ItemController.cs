using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RankingApp.Models;

namespace RankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemContext _context;

        public ItemController(ItemContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModel>>> GetItems([FromQuery] int itemType = 0)
        {
          
            
            if (_context.Items == null)
          {
              return NotFound();
          }

            // If itemType is 0, return all items; otherwise, filter by itemType
            var itemsQuery = _context.Items.AsQueryable();

            if (itemType != 0)
            {
                itemsQuery = itemsQuery.Where(item => item.ItemType == itemType);
            }


            return await itemsQuery.ToListAsync();
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModel>> GetItemModel(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var itemModel = await _context.Items.FindAsync(id);

            if (itemModel == null)
            {
                return NotFound();
            }

            return itemModel;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemModel(int id, ItemModel itemModel)
        {
            if (id != itemModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemModelExists(id))
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

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemModel>> PostItemModel(ItemModel itemModel)
        {
          if (_context.Items == null)
          {
              return Problem("Entity set 'ItemContext.Items'  is null.");
          }
            _context.Items.Add(itemModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemModel), new { id = itemModel.Id }, itemModel);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemModel(int id)
        {
            if (_context.Items == null)
            {
                return NotFound();
            }
            var itemModel = await _context.Items.FindAsync(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            _context.Items.Remove(itemModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemModelExists(int id)
        {
            return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
