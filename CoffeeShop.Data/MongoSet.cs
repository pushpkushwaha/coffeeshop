using CoffeeShop.Infra;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Data
{
    public class MongoSet<T> : IQueryable<T> where T : IEntity, new()
    {
        private string _collectionName;
        private IMongoDatabase _db;
        protected IMongoCollection<T> _collection => _db.GetCollection<T>(_collectionName);

        protected IQueryable<T> _collectionAsQuery => _collection.AsQueryable<T>();

        protected readonly DbSettings dbSettings;

        public MongoSet(IMongoDatabase db, string collectionName)
        {
            _collectionName = collectionName;
            _db = db;
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


        #region IQueryable

        public Type ElementType => _collectionAsQuery.ElementType;
        public Expression Expression => _collectionAsQuery.Expression;
        public IQueryProvider Provider => _collectionAsQuery.Provider;
        public IEnumerator<T> GetEnumerator() => _collectionAsQuery.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _collectionAsQuery.GetEnumerator();

        #endregion
    }
}
