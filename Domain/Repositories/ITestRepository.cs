using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apicore.Domain.Contexts;
using apicore.Domain.Models;

namespace apicore.Domain.Repositories
    {
    public interface ITestRepository {
        
        Task<IEnumerable<Test>> ListAsync();
        Task AddAsync(Test test);
    }


}