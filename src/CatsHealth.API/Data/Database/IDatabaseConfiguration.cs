namespace CatsHealth.API.Data.Database{
    public interface IDatabaseConfiguration{
        string GetConnectionString();
        string GetDatabase();
        string GetProfileCollection();
        string GetWeightCollection();
    }
}