using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;

namespace MeetUp.Application.Abstractions.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : EntitySoftDeletableIntKey
    {
        Task<List<TDest>> GetAll<TDest>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperty,
            Expression<Func<T, TDest>> SelectExpression);
        Task<TDest> GetSingle<TDest>(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includeProperty,
            Expression<Func<T, TDest>> SelectExpression);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate);

    }
}
