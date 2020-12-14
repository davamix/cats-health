namespace CatsHealth.API.Data.Database
{
    public interface IDatabaseBootstrap
    {
        void Setup(bool addTestData = false);
    }
}