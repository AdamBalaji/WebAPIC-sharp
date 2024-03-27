using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;
using Test.Repository.IRepository;

namespace Test.Repository
{
    public class StatesRepository : GenericRepository<States>, IStatesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StatesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }


        public async Task Update(States entity)
        {
            _dbContext.States.Update(entity);
            _dbContext.SaveChanges();
            
        }

       
    }
}