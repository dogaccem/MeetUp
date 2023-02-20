using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetUp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace MeetUp.Persistence.Inceptors
{
    public class EFCommandInterceptor : IDbCommandInterceptor
    {
        public async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
            DbCommand command,
            CommandEventData eventData,
            InterceptionResult<DbDataReader> result,
            CancellationToken cancellationToken = default)
        {
            LogInfo(command.CommandText);

            return await new ValueTask<InterceptionResult<DbDataReader>>(result);
        }

        private void LogInfo(string commandText)
        {
            Console.WriteLine("Intercepted on: {0}",commandText);
        }
    }
}
