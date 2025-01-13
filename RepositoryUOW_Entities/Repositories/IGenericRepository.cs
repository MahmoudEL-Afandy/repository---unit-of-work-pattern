using RepositoryUOW_Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryUOW_Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        IEnumerable<T> GetAll();//Expression<Func<T,bool>>? predicate=null,string? IncludeWord=null);
        T GetFirstOrDefault(Expression<Func<T, bool>> predicate , string? IncludeWord = null);
        IEnumerable<T> GetByWhere (Expression<Func<T,bool>> predicate , string? IncludeWord = null);

        T GetById(int id);

        // if i need add async method 

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> FindAll(Expression<Func<T,bool>> predicate , int take ,int skip );

        IEnumerable<T> FindAll(Expression<Func<T,bool>> predicate , int? take , int? skip ,
            Expression<Func<T,object>> orderBy = null , string orderByDirection = OrderBy.Ascending );

        T Add(T entity);
        IEnumerable<T> AddRnage(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange (IEnumerable<T> entities);

        T UpDate(T entity);

        void Attach (T entity);
        int Count();
        int Count(Expression<Func<T,bool>> predicate);

    }
}
