using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Persistence.Repositories
{
    public class WriteRepository<TContext, T> : IWriteRepository<T> where TContext : DbContext
        where T : EntitySoftDeletableIntKey
    {
        private readonly TContext _context;

        public WriteRepository(TContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        public async Task UpdateAsync(T model)
        {
            await Task.Run(() => _context.Set<T>().Update(model));
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _context.Set<T>().FindAsync(id);
            await Task.Run(() => _context.Set<T>().Remove(model));
        }

    }
}
