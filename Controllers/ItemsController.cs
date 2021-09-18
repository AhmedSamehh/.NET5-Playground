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
        private readonly InMemItemsRepo repository;
        public ItemsController()
        {
            repository = new InMemItemsRepo();
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