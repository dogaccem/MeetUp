using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : EntitySoftDeletableIntKey
    {
        
    }
}
