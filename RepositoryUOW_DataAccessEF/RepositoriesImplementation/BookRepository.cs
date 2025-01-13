using Microsoft.EntityFrameworkCore;
using RepositoryUOW_DataAccessEF.Data;
using RepositoryUOW_Entities.Models;
using RepositoryUOW_Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUOW_DataAccessEF.RepositoriesImplementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
       

        public BookRepository(ApplicationDbContext context): base(context) 
        {
            
        }
        public IEnumerable<Book> SpecialBook()
        {
            return _context.Books.Where(d=>d.Id==1) ;
        }
    }
}
