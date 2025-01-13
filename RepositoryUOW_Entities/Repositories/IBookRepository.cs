using RepositoryUOW_Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUOW_Entities.Repositories
{
    public interface IBookRepository: IGenericRepository<Book> 
    {

        IEnumerable<Book> SpecialBook();
    }
}
