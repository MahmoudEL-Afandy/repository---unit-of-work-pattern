using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryUOW_DataAccessEF.RepositoriesImplementation;
using RepositoryUOW_Entities.Models;
using RepositoryUOW_Entities.Repositories;

namespace Repo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        
            private readonly IUnitOfWork _authorsIUnitOfWork;

            public AuthorController(IUnitOfWork authorsIUnitOfWork)
            {
                 _authorsIUnitOfWork = authorsIUnitOfWork;
            }

            [HttpGet]
            public IActionResult GetbyId(int id)
            {
                return Ok(_authorsIUnitOfWork.Authors.GetById(id));
            }
            [HttpGet("GetByIdAsync")]
            public async Task<IActionResult> GetByIdAsync(int id)
            {

                return Ok(await _authorsIUnitOfWork.Authors.GetByIdAsync(id));

            }


            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {
                 return Ok(_authorsIUnitOfWork.Authors.GetAll());



            }

        [HttpGet("GetFirstOrDefault")]   
        public IActionResult GetFirstOrDefault(string name)   
        {
               
            return Ok(_authorsIUnitOfWork.Authors.GetFirstOrDefault(x => x.Name == name));


          
        }







    }
}
