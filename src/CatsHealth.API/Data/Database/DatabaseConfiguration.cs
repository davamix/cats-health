using Microsoft.Extensions.Configuration;

namespace CatsHealth.API.Data.Database
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private readonly IConfiguration configuration;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString() => configuration["MongoDatabaseSettings:ConnectionString"];

        public string GetDatabase() => configuration["MongoDatabaseSettings:DatabaseName"];

        public string GetProfileCollection() => configuration["MongoDatabaseSettings:ProfileCollection"];
        public string GetWeightCollection() => configuration["MongoDatabaseSettings:WeightCollection"];
    }
}