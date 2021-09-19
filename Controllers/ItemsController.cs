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
    }
}