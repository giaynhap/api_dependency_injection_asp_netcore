
using System.Collections.Generic;
using System.Threading.Tasks;
using apicore.Domain.Models;
namespace apicore.Domain.Services
{
    public interface IDemoService
    {
         Task<IEnumerable<Test>> Test();
         Task<bool> AddNewTest(Test test);
    }
}