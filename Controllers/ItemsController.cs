using System;
using System.Collections.Generic;
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
        public IEnumerable<Item> GetItems()
        {
            return repository.GetItems();
        }
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            Item item =  repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item;
        }
    }
}