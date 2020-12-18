using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.StorageProviders;

namespace CatsHealth.API.Data.Repositories
{
    public class WeightRepository : RepositoryBase<Weight> //IRepository<Weight>
    {
        // private readonly IStorageProvider<Weight> storageProvider;

        public WeightRepository(IStorageProvider<Weight> storageProvider) : base(storageProvider) { }
        // {
        //     this.storageProvider = storageProvider;
        // }

        // public Weight Get(string id)
        // {
        //     return storageProvider.Get(id);
        // }

        // public IList<Weight> Get()
        // {
        //     return storageProvider.Get();
        // }

        // public void Insert(Weight item)
        // {
        //     storageProvider.Insert(item);
        // }

        // public Weight Update(string id, Weight item)
        // {
        //     throw new NotImplementedException();
        // }

        // public void Delete(string id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}