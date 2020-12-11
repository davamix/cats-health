using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Database;
using CatsHealth.API.Data.Entities;
using MongoDB.Driver;

namespace CatsHealth.API.Data.StorageProviders.MongoProvider
{
    public class ProfileStorageProvider : IStorageProvider<Profile>
    {
        private readonly IDatabaseConfiguration configuration;
        private readonly MongoClient client;
        private readonly IMongoDatabase database;
        private IMongoCollection<Profile> profileCollection;

        public ProfileStorageProvider(IDatabaseConfiguration configuration)
        {
            this.configuration = configuration;

            client = new MongoClient(configuration.GetConnectionString());
            database = client.GetDatabase(configuration.GetDatabase());

            profileCollection = database.GetCollection<Profile>(configuration.GetProfileCollection());
        }

        public Profile Get(string id){
            return profileCollection.Find<Profile>(x=>x.Id == id).FirstOrDefault();
        }
        public IList<Profile> Get(){
            return profileCollection.Find(x=>true).ToList();
        }
        public void Insert(Profile item){
            profileCollection.InsertOne(item);
        }
        public Profile Update(string id, Profile item){
            throw new NotImplementedException();
        }
        public void Delete(string id){
            throw new NotImplementedException();
        }
    }
}