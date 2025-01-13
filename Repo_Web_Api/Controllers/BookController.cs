using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryUOW_Entities.Constants;
using RepositoryUOW_Entities.Models;
using RepositoryUOW_Entities.Repositories;
using RepositoryUOW_DataAccessEF.RepositoriesImplementation;

namespace Repo_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        // private readonly IGenericRepository<Book> _booksrepository; // Before UnitOfWork 
        private readonly IUnitOfWork _BooksIunitOfWork;

        // Before UnitOfWork 
        //public BookController(IGenericRepository<Book> booksrepository)
        //{
        //    _booksrepository = booksrepository;
        //}

        // After UnitOfWork

        public BookController(IUnitOfWork unitOfWork)
        {
            _BooksIunitOfWork = unitOfWork;

            
        }

        [HttpGet]
        public IActionResult GetbyId(int id)
        {
            return Ok(_BooksIunitOfWork.Books.GetById(id));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {

            return Ok(await _BooksIunitOfWork.Books.GetByIdAsync(id));

        }

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_booksrepository.GetAll());
        //}

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_BooksIunitOfWork.Books.GetAll());
        }

        [HttpGet("GetFirstOrDefault")]
        public IActionResult GetFirstOrDefault(string title)
        {

            return Ok(_BooksIunitOfWork.Books.GetFirstOrDefault(x => x.Title == title,"Author"));



        }
        [HttpGet("FindAllwithOrder")]
        public IActionResult FindAll ()
        {
            return Ok(_BooksIunitOfWork.Books.FindAll(b=>b.Title=="testbook2" , null, null , o=>o.Id ,OrderBy.Descending));

        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
           var book= _BooksIunitOfWork.Books.Add(new Book { Title = "testbook3", AuthorId = 2 });
            _BooksIunitOfWork.Complete();

            return Ok(book);
            
        }

        [HttpGet("SpecialBook")]
        public IActionResult SpecialBook()
        {
            return Ok(_BooksIunitOfWork.Books.SpecialBook());

        }



    }
}
