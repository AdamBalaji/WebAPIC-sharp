using System.Diagnostics.Metrics;
using Test.Models;

namespace Test.Repository.IRepository
{
    public interface IStatesRepository : IGenericRepository<States>
    {
       
        Task Update(States entity);
        
    }
}
