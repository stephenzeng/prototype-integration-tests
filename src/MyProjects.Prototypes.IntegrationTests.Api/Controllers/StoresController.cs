using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProjects.Prototypes.IntegrationTests.Dal;

namespace MyProjects.Prototypes.IntegrationTests.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StoresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<dynamic>> Get()
        {
            return await _dbContext.Stores.ToListAsync();
        }
        
    }
}