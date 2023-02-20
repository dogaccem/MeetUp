using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;

namespace MeetUp.Application.Abstractions.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : EntitySoftDeletableIntKey
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(int id);
    }
}
