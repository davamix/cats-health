using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Database;
using CatsHealth.API.Data.Entities;
using MongoDB.Driver;

namespace CatsHealth.API.Data.StorageProviders.MongoProvider
{
    public class WeightStorageProvider : ProviderBase<Weight>, IWeightStorageProvider
    {
        private IMongoCollection<Weight> weightCollection;

        public WeightStorageProvider(IDatabaseConfiguration configuration)
            : base(configuration)
        {
            weightCollection = database.GetCollection<Weight>(configuration.GetWeightCollection());
        }

        public override Weight Get(string id)
        {
            return weightCollection.Find<Weight>(x => x.Id == id).FirstOrDefault();
        }

        public override IList<Weight> Get()
        {
            return weightCollection.Find(x => true).ToList();
        }

        public override void Insert(Weight item)
        {
            weightCollection.InsertOne(item);
        }

        public override Weight Update(string id, Weight item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Weight GetLastWeight(string profileId)
        {
            return weightCollection.Find(x => x.ProfileId == profileId)
                .SortByDescending(x => x.RegisteredOn)
                .FirstOrDefault();
        }
    }
}