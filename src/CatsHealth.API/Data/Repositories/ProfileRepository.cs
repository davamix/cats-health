using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.StorageProviders;

namespace CatsHealth.API.Data.Repositories
{
    public class ProfileRepository : RepositoryBase<Profile>
    {
        public ProfileRepository(IStorageProvider<Profile> storageProvider) : base(storageProvider) { }
    }
}