using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;
using Test.Repository.IRepository;

namespace Test.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }
       

        public async Task Update(Country entity)
        {
             _dbContext.Countries.Update(entity);
             _dbContext.SaveChanges();
        }
    }
}
