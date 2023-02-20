using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Application.Abstractions.UnitOfWork;
using MeetUp.Domain.Abstractions;
using MeetUp.Persistence.Contexts;
using MeetUp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace MeetUp.Persistence.UnitOfWorkConcrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeetUpAppDbContext _context;
        private IDbContextTransaction _transaction;//public yapabilirsin
        public UnitOfWork(MeetUpAppDbContext context)
        {
            _context = context;
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task<int> Save(CancellationToken cancellationToken = new CancellationToken())
        {
            var datas = _context.ChangeTracker.Entries<EntitySoftDeletableIntKey>();
            foreach (var data in datas)
            {
                 switch(data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        data.Entity.IsDeleted = false;  
                        break;
                    case EntityState.Modified :
                        data.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                };
            }

            return await _context.SaveChangesAsync(cancellationToken);
        }

        public IReadRepository<T> GetReadRepository<T>() where T : EntitySoftDeletableIntKey
        {
            return new ReadRepository<MeetUpAppDbContext, T>(_context);
        }

        public IWriteRepository<T> GetWriteRepository<T>() where T : EntitySoftDeletableIntKey
        {
            return new WriteRepository<MeetUpAppDbContext, T>(_context);
        }
    }
}
