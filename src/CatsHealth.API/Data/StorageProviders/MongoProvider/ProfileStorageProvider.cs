using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Database;
using CatsHealth.API.Data.Entities;
using MongoDB.Driver;

namespace CatsHealth.API.Data.StorageProviders.MongoProvider
{
    public class ProfileStorageProvider : ProviderBase<Profile> //IStorageProvider<Profile>
    {
        // private readonly IDatabaseConfiguration configuration;
        // private readonly MongoClient client;
        // private readonly IMongoDatabase database;
        private IMongoCollection<Profile> profileCollection;

        public ProfileStorageProvider(IDatabaseConfiguration configuration)
        : base(configuration)
        {
            // this.configuration = configuration;

            // client = new MongoClient(configuration.GetConnectionString());
            // database = client.GetDatabase(configuration.GetDatabase());

            profileCollection = database.GetCollection<Profile>(configuration.GetProfileCollection());
        }

        public override Profile Get(string id)
        {
            return profileCollection.Find<Profile>(x => x.Id == id).FirstOrDefault();
        }
        public override IList<Profile> Get()
        {
            return profileCollection.Find(x => true).ToList();
        }
        public override void Insert(Profile item)
        {
            profileCollection.InsertOne(item);
        }
        public override Profile Update(string id, Profile item)
        {
            // var filter = Builders<Profile>.Filter.Eq("_id", id);

            var update = Builders<Profile>.Update.Set(p => p.LastWeight, item.LastWeight);

            profileCollection.UpdateOne(p => p.Id == id, update);

            return item;
        }
        public override void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}