using Microsoft.EntityFrameworkCore;
using RepositoryUOW_DataAccessEF.Data;
using RepositoryUOW_Entities.Constants;
using RepositoryUOW_Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryUOW_DataAccessEF.RepositoriesImplementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
            
        }

        public IEnumerable<T> AddRnage(IEnumerable<T> entities)
        {
           _dbSet.AddRange(entities);
            return entities;
        }

        public void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
             return _dbSet.Count(predicate);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int take, int skip)
        {
           
            return _dbSet.Where(predicate).Skip(skip).Take(take).ToList();


        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _dbSet.Where(predicate);

            if (take.HasValue)
                query = query.Skip(take.Value);
            if (skip.HasValue)
                query = query.Skip(skip.Value);
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else 
                    query = query.OrderByDescending(orderBy);

            }

            return query.ToList();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();

        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IEnumerable<T> GetByWhere(Expression<Func<T, bool>> predicate, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet; // = _context.Set<T>();
            if (IncludeWord != null)
            {
                foreach (var word in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(word);

                }
            }

            return query.Where(predicate).ToList(); // = _context.Set<T>().Include(word).Where(predicate).ToList();;
        }

        //there are two ways to implement the GetFirstOrDefault 

        //public T GetFirstOrDefault(Expression<Func<T, bool>> predicate , string? IncludeWord = null)
        //{
        //    IQueryable<T> query = _dbSet;
        //    //if (predicate != null)
        //    //{
        //    query = query.Where(predicate);

        //    //}
        //    if (IncludeWord != null)
        //    {
        //        foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(item);

        //        }
        //    }
        //    return query.SingleOrDefault();
        //}
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate, string? IncludeWord = null)
        {
            IQueryable<T> query = _dbSet;
            
            if (IncludeWord != null)
            {
                foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);

                }
            }
            return query.SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public T UpDate(T entity)
        {
             _dbSet.Update(entity);
            return entity;
        }
    }
}
