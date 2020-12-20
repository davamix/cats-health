using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.StorageProviders;

namespace CatsHealth.API.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase<T>
    {
        protected readonly IStorageProvider<T> storageProvider;

        public RepositoryBase(IStorageProvider<T> storageProvider)
        {
            this.storageProvider = storageProvider;
        }

        public T Get(string id)
        {
            return storageProvider.Get(id);
        }

        public IList<T> Get()
        {
            return storageProvider.Get();
        }

        public void Insert(T item)
        {
            storageProvider.Insert(item);
        }

        public T Update(string id, T item)
        {
            return storageProvider.Update(id, item);
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}