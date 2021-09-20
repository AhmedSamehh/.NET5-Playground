using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.DTOs;
using Catalog.Models;

namespace Catalog.Repositories
{

    public class InMemItemsRepo : IItemsRepo
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = System.Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDay = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Iron Sword", Price = 15, CreatedDay = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Bronze Sheild", Price = 9, CreatedDay = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(i => i.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
    }
}