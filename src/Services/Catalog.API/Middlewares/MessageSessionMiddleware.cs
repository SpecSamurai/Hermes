using NServiceBus.TransactionalSession;

namespace Hermes.Catalog.API.Middlewares;

public class MessageSessionMiddleware
{
    private readonly RequestDelegate _next;

    public MessageSessionMiddleware(RequestDelegate next) =>
        _next = next;

    public async Task InvokeAsync(HttpContext httpContext, ITransactionalSession transactionalSession)
    {
        await transactionalSession.Open(new SqlPersistenceOpenSessionOptions());
        await _next(httpContext);
        await transactionalSession.Commit();
    }
}