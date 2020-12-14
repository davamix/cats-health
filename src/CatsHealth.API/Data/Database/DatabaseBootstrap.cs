using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.Repositories;

namespace CatsHealth.API.Data.Database
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly IRepository<Profile> _profileRepository;

        public DatabaseBootstrap(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public void Setup(bool addTestData = false)
        {
            if(addTestData){
                AddTestData();
            }
        }

        private void AddTestData(){
            var p1 = new Profile(){
                Name = "Blacky"
            };

            var p2 = new Profile(){
                Name = "Niche"
            };

            _profileRepository.Insert(p1);
            _profileRepository.Insert(p2);
        }
    }
}