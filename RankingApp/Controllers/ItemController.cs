using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RankingApp.Models;
using RankingApp.Repositories;

namespace RankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;
        private UnitOfWork _unitOfWork;

        public ItemController(ItemContext context, IMapper mapper, UnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemModelDTO>>> GetItems([FromQuery] int itemType = 0)
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

            var items = _unitOfWork.ItemRepository.GetItems();
            var itemDTO = _mapper.Map<List<ItemModelDTO>>(items);
            return itemDTO;
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemModelDTO>> GetItemModel(int id)
        {
          if (_context.Items == null)
          {
              return NotFound();
          }
            var itemModel = _unitOfWork.ItemRepository.GetItemByID(id);

            if (itemModel == null)
            {
                return NotFound();
            }

            ItemModelDTO itemModelDTO = _mapper.Map<ItemModelDTO>(itemModel);
            return itemModelDTO;
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

            _unitOfWork.ItemRepository.UpdateItem(itemModel);

            try
            {
                _unitOfWork.Save();
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
            _unitOfWork.ItemRepository.InsertItem(itemModel);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetItemModel), new { id = itemModel.Id }, itemModel);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemModel(int id)
        {
            var itemModel = _unitOfWork.ItemRepository.GetItemByID(id);
            if (itemModel == null)
            {
                return NotFound();
            }

            _unitOfWork.ItemRepository.DeleteItem(id);
            _unitOfWork.Save();

            return NoContent();
        }

        private bool ItemModelExists(int id)
        {
            return _unitOfWork.ItemRepository.GetItemByID(id) != null;
        }
    }
}
