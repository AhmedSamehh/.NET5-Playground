using System;
using System.Collections.Generic;
using Catalog.Models;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBItemsRepo : IItemsRepo
    {
        private readonly IMongoCollection<Item> itemsCollection;
        private const string dbName = "catalog";
        private const string collectionName = "items";
        public MongoDBItemsRepo(IMongoClient mongoClient){
        }
        public void CreateItem(Item item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}