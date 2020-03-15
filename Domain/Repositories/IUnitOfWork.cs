using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apicore.Domain.Contexts;
namespace apicore.Domain.Repositories
    {
     public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}