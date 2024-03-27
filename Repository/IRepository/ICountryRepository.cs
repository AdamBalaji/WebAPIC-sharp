using System.Diagnostics.Metrics;
using Test.Models;

namespace Test.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task Update(Country entity);
        
    }
}
