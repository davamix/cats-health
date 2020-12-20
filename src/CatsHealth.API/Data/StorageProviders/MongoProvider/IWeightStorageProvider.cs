using CatsHealth.API.Data.Entities;

namespace CatsHealth.API.Data.StorageProviders.MongoProvider
{
    public interface IWeightStorageProvider : IStorageProvider<Weight>
    {
        Weight GetLastWeight(string profileId);
    }
}