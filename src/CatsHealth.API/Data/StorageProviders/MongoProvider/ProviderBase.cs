using System.Collections.Generic;
using CatsHealth.API.Data.Database;
using CatsHealth.API.Data.Entities;
using MongoDB.Driver;

namespace CatsHealth.API.Data.StorageProviders.MongoProvider{
    public abstract class ProviderBase<T> : IStorageProvider<T> where T:EntityBase<T>{
        protected readonly IDatabaseConfiguration configuration;
        protected readonly MongoClient client;
        protected readonly IMongoDatabase database;
        // private IMongoCollection<T> profileCollection;

        public ProviderBase(IDatabaseConfiguration configuration)
        {
            this.configuration = configuration;

            client = new MongoClient(configuration.GetConnectionString());
            database = client.GetDatabase(configuration.GetDatabase());

            // profileCollection = database.GetCollection<T>(configuration.GetProfileCollection());
        }

        public abstract T Get(string id);
        public abstract IList<T> Get();
        public abstract void Insert(T item);
        public abstract T Update(string id, T item);
        public abstract void Delete(string id);
    }
}