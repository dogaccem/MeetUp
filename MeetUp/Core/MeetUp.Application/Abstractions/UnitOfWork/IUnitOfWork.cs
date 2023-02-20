using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Application.Abstractions.Repositories;
using MeetUp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task<int> Save(CancellationToken cancellationToken);
        IReadRepository<T> GetReadRepository<T>() where T : EntitySoftDeletableIntKey;
        IWriteRepository<T> GetWriteRepository<T>() where T : EntitySoftDeletableIntKey;
    }
}
