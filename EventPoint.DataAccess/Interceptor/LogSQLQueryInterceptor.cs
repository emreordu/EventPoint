using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics;

namespace EventPoint.DataAccess.Interceptor
{
    public class LogSQLQueryInterceptor : DbCommandInterceptor
    {
        public override async ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, CommandExecutedEventData eventData, DbDataReader result, CancellationToken cancellationToken = default)
        {
            Debug.WriteLine("Intercepted on: {0} \n--Execution Time: {1} ms", command.CommandText, eventData.Duration.TotalMilliseconds);
            return await base.ReaderExecutedAsync(command, eventData, result, cancellationToken);
        }
    }
}