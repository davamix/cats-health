using System;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.Repositories;
using CatsHealth.API.Dtos;
using CatsHealth.API.Mappers;

namespace CatsHealth.API.Services.WeightService
{
    public class WeightService : IWeightService
    {
        // private readonly IRepository<Weight> weightRepository;
        private readonly IWeightRepository weightRepository;

        public WeightService(IWeightRepository weightRepository)
        {
            this.weightRepository = weightRepository;
        }
        public WeightResponse Save(AddWeightRequest dto)
        {
            try
            {
                weightRepository.Insert(dto.ToWeight());

                return new WeightResponse(dto.Value, dto.RegisteredOn);
            }
            catch (Exception) { throw; }
        }

        public WeightResponse GetLastWeight(string profileId)
        {
            var weight = weightRepository.GetLastWeight(profileId);

            return weight != null ? new WeightResponse(weight.Value, weight.RegisteredOn) : null;
        }
    }
}