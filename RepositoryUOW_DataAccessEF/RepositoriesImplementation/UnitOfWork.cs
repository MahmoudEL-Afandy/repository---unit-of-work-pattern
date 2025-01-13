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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        // every table we want to get it in the controller we must add it it's own GenericInterface here .
        //before Add IBookRepository 
       // public IGenericRepository<Book> Books {  get; private set; }
       // After Add IBookRepoSitory
       public IBookRepository Books { get; private set; }

        public IGenericRepository<Author> Authors { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new GenericRepository<Author>(_context);
            
        }

        public int Complete()
        {
           return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
