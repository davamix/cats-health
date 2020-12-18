using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.StorageProviders;

namespace CatsHealth.API.Data.Repositories
{
    public class ProfileRepository : RepositoryBase<Profile>// IRepository<Profile>
    {
        // private readonly IStorageProvider<Profile> storageProvider;

        public ProfileRepository(IStorageProvider<Profile> storageProvider) : base(storageProvider) { }
        // {
        //     this.storageProvider = storageProvider;
        // }

        // public Profile Get(string id)
        // {
        //     return storageProvider.Get(id);
        // }

        // public IList<Profile> Get()
        // {
        //     return storageProvider.Get();
        // }

        // public void Insert(Profile item)
        // {
        //     storageProvider.Insert(item);
        // }

        // public Profile Update(string id, Profile item)
        // {
        //     throw new NotImplementedException();
        // }

        // public void Delete(string id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}