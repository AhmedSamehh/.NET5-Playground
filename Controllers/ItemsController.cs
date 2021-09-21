using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.DTOs;
using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase 
    {
        private readonly IItemsRepo repository;
        public ItemsController(IItemsRepo repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            var items =  repository.GetItems().Select(item => item.AsDTO());
            return items;
        }
        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item =  repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AsDTO();
        }
        [HttpPost]
        public ActionResult<ItemDTO> CreateItem(CreateItemDTO itemDTO)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDTO.Name,
                Price = itemDTO.Price,
                CreatedDay = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDTO());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDTO itemDTO)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            Item updatedItem = existingItem with {
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };
            repository.UpdateItem(updatedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if(existingItem is null){
                return NotFound();
            }
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}