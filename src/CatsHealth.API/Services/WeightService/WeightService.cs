using System;
using CatsHealth.API.Data.Entities;
using CatsHealth.API.Data.Repositories;
using CatsHealth.API.Dtos;
using CatsHealth.API.Mappers;

namespace CatsHealth.API.Services.WeightService
{
    public class WeightService : IWeightService
    {
        private readonly IRepository<Weight> weightRepository;

        public WeightService(IRepository<Weight> weightRepository)
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
    }
}