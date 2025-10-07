using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Data.Common;

public class DatabaseLoggerInterceptor : DbCommandInterceptor
{
    private readonly ILogger<DatabaseLoggerInterceptor> _logger;

    public DatabaseLoggerInterceptor(ILogger<DatabaseLoggerInterceptor> logger)
    {
        _logger = logger;
    }

    public override InterceptionResult<int> NonQueryExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<int> result)
    {
        LogCommand(command);
        return base.NonQueryExecuting(command, eventData, result);
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        LogCommand(command);
        return base.ReaderExecuting(command, eventData, result);
    }

    public override InterceptionResult<object> ScalarExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<object> result)
    {
        LogCommand(command);
        return base.ScalarExecuting(command, eventData, result);
    }

    public override DbDataReader ReaderExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result)
    {
        _logger.LogInformation(
            "Database Operation Completed: {CommandText} on {Connection}",
            command.CommandText,
            command.Connection?.ConnectionString);
        
        return base.ReaderExecuted(command, eventData, result);
    }

    public override int NonQueryExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        int result)
    {
        _logger.LogInformation(
            "Database Operation Completed: {CommandText} on {Connection}, Rows Affected: {Result}",
            command.CommandText,
            command.Connection?.ConnectionString,
            result);

        return base.NonQueryExecuted(command, eventData, result);
    }

    public override object ScalarExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        object result)
    {
        _logger.LogInformation(
            "Database Operation Completed: {CommandText} on {Connection}, Result: {Result}",
            command.CommandText,
            command.Connection?.ConnectionString,
            result);

        return base.ScalarExecuted(command, eventData, result);
    }

    private void LogCommand(DbCommand command)
    {
        var parameters = GetParameterValues(command);
        _logger.LogInformation(
            "Database Operation: {CommandText} on {Connection} with parameters: {Parameters}",
            command.CommandText,
            command.Connection?.ConnectionString,
            parameters);
    }

    private string GetParameterValues(DbCommand command)
    {
        if (command.Parameters != null && command.Parameters.Count > 0)
        {
            return string.Join(", ", command.Parameters);
        }
        else
        {
            return "No parameters available";
        }
    }
}
