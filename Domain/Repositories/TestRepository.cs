using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apicore.Domain.Contexts;
using apicore.Domain.Models;
namespace apicore.Domain.Repositories
    {
    public class TestRepository : BaseRepository,ITestRepository{
        public TestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Test>> ListAsync()
        {   
            var auto =  await _context.Tests.ToListAsync(); 
            return auto;
        }
        public async Task AddAsync(Test test){
            await _context.Tests.AddAsync(test);
        }
    }


}