using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data
{
    public class BaseRepository<T> where T : IEntity, new()
    {
        protected readonly IMongoCollection<T> _collection;

        protected readonly DbSettings dbSettings;

        public BaseRepository(IOptions<DbSettings> dbSettingsOptions, string collectionName)
        {
            dbSettings = dbSettingsOptions.Value;
            var mongoClient = new MongoClient(dbSettings.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(dbSettings.DatabaseName);
            _collection = mongoDb.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
        await _collection.Find(_ => true).ToListAsync();

        public async Task<T> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(T entity) =>
            await _collection.InsertOneAsync(entity);

        public async Task InsertManyAsync(IEnumerable<T> entities) =>
           await _collection.InsertManyAsync(entities);
        public async Task UpdateAsync(string id, T updatedEntity) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedEntity);

        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
