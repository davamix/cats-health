using System;
using System.Collections.Generic;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.Repositories;
using CatsHealth.API.Dtos;
using CatsHealth.API.Mappers;

namespace CatsHealth.API.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository<Profile> profileRepository;

        public ProfileService(IRepository<Profile> profileRepository)
        {
            this.profileRepository = profileRepository;
        }
        public ProfileResponseDto GetProfile(string id)
        {
            var profile = profileRepository.Get(id);

            return new ProfileResponseDto(profile.Id, profile.Name);
        }

        public IList<ProfileResponseDto> GetProfiles()
        {
            var profiles = profileRepository.Get();
            var dtos = new List<ProfileResponseDto>();

            foreach (var p in profiles)
            {
                dtos.Add(new ProfileResponseDto(p.Id, p.Name));
            }

            return dtos;
        }

        public ProfileResponseDto Save(ProfileRequestDto dto)
        {
            try
            {
                var entity = dto.ToProfile();

                entity.Id = Guid.NewGuid().ToString();

                profileRepository.Insert(entity);

                return new ProfileResponseDto(entity.Id, entity.Name);
            }
            catch (Exception) { throw; }
        }
    }
}