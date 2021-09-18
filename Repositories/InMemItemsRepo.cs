using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Models;

namespace Catalog.Repositories
{
    public class InMemItemsRepo
    {
        private readonly List<Item> Items = new()
        {
            new Item { Id = System.Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDay = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Iron Sword", Price = 15, CreatedDay = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Bronze Sheild", Price = 9, CreatedDay = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return Items;
        }
        public Item GetItem(Guid id)
        {
            return Items.Where(i => i.Id == id).SingleOrDefault();
        }
    }
}