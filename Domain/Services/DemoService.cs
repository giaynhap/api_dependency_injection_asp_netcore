
using System.Collections.Generic;
using System.Threading.Tasks;
using apicore.Domain.Repositories;
using System;
using apicore.Domain.Models;
namespace apicore.Domain.Services
{
    public class DemoService:IDemoService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITestRepository _testRepository; 
        public DemoService(ITestRepository testRepository, IUnitOfWork unitOfWork){
            this._testRepository = testRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Test>> Test()
        {
           return await this._testRepository.ListAsync();
        }   

        public async Task<bool> AddNewTest(Test test){
            try{
                
            await this._testRepository.AddAsync(test);
            await _unitOfWork.CompleteAsync();
            return true;
            }catch{
                return false;
            }
        }
    }
}