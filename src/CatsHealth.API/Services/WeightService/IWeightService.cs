using CatsHealth.API.Dtos;

namespace CatsHealth.API.Services.WeightService
{
    public interface IWeightService
    {
        WeightResponse Save(AddWeightRequest dto);
        WeightResponse GetLastWeight(string profileId);
    }
}