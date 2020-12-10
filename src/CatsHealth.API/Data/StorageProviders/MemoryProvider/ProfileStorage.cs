using System;
using System.Linq;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;

namespace CatsHealth.API.Data.StorageProviders
{
    public class ProfileStorage : IStorageProvider<Profile>
    {
        IList<Profile> Profiles { get; set; }

        public ProfileStorage()
        {
            Profiles = new List<Profile>();

            AddFakeData();
        }

        public Profile Get(string id)
        {
            return Profiles.First(x => x.Id.Equals(id));
        }

        public IList<Profile> Get()
        {
            return Profiles;
        }

        public void Insert(Profile item)
        {
            Profiles.Add(item);
        }

        public Profile Update(string id, Profile item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        private void AddFakeData()
        {
            var p1 = new Profile() { Id = Guid.NewGuid().ToString(), Name = "Blacky" };
            var p2 = new Profile() { Id = Guid.NewGuid().ToString(), Name = "Niche" };

            Profiles.Add(p1);
            Profiles.Add(p2);

        }
    }
}