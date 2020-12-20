using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.StorageProviders;
using CatsHealth.API.Data.StorageProviders.MongoProvider;

namespace CatsHealth.API.Data.Repositories
{
    public class WeightRepository : RepositoryBase<Weight>, IWeightRepository
    {
        public WeightRepository(IWeightStorageProvider storageProvider) : base(storageProvider) { }

        public Weight GetLastWeight(string profileId)
        {
            return (storageProvider as IWeightStorageProvider).GetLastWeight(profileId);
        }
    }
}