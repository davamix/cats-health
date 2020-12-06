using System.Collections.Generic;
using CatsHealth.API.Data.Entities;

namespace CatsHealth.API.Data.StorageProviders
{
    public interface IStorageProvider<T> where T : EntityBase<T>
    {
        T Get(string id);
        IList<T> Get();
        void Insert(T item);
        T Update(string id, T item);
        void Delete(string id);

    }
}