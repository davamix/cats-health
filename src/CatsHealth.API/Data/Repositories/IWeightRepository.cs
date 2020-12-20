using CatsHealth.API.Data.Entities;

namespace CatsHealth.API.Data.Repositories
{
    public interface IWeightRepository : IRepository<Weight>
    {
        Weight GetLastWeight(string profileId);
    }
}