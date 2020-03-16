using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

using AutoMapper;
using apicore.Domain.Services;
using apicore.Domain.Models;
using apicore.Domain.Resources;

namespace apicore.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    
    public class TestController : ControllerBase
    {
        private readonly IDemoService _demoService;
        private readonly IMapper _mapper;
         
        public TestController(IDemoService IDemoService, IMapper mapper)
        {
            _demoService = IDemoService;
            _mapper = mapper;
        }

        [Authorize]  
        [HttpGet]
        public async Task<IEnumerable<TestResource>> Get()
        {
          
          return _mapper.Map<IEnumerable<Test>, IEnumerable<TestResource>>(await _demoService.Test());
        }

        
        [HttpGet]
        public async Task<string> Add()
        {
          string name = this.Request.Query["name"];
          bool result = await _demoService.AddNewTest(new Test(){Name = name});
        
          if (result){
            return "success";
          }
          return "failed";

        }
    }
}
