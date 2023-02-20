using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Abstractions;
using MeetUp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace MeetUp.Persistence.Repositories
{
    public class ReadRepository<TContext, T> : IReadRepository<T> where TContext : DbContext
                                                                  where T : EntitySoftDeletableIntKey
    {
        private readonly TContext _context;

        public ReadRepository(TContext context)
        {
            _context = context;
        }


        public async Task<List<TDest>> GetAll<TDest>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperty, Expression<Func<T, TDest>> SelectExpression)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
            }

            return await query.Select(SelectExpression).ToListAsync();

        }

        public async Task<TDest> GetSingle<TDest>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperty, Expression<Func<T, TDest>> SelectExpression)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperty != null)
            {
                query = query.Include(includeProperty);
            }

            return await query.Select(SelectExpression).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                   query= query.Include(includeProperty);
                }
            }
            
            

            return await query.ToListAsync();
        }

        public async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().CountAsync(predicate);
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
