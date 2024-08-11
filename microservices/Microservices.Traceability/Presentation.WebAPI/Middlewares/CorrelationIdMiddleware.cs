using Microsoft.Extensions.Primitives;

namespace Presentation.WebAPI.Middlewares;

public class CorrelationIdMiddleware(RequestDelegate next)
{
    private const string correlationIdHeaderKey = "X-Correlation-Id";

    public async Task InvokeAsync(HttpContext context, ILogger<CorrelationIdMiddleware> logger)
    {
        string correlationId = Guid.NewGuid().ToString();

        if (context.Request.Headers.TryGetValue(correlationIdHeaderKey, out StringValues _correlationId))
            correlationId = _correlationId!;
        else
            context.Request.Headers.Append(correlationIdHeaderKey, correlationId);

        NLog.ScopeContext.PushProperty("CorrelationId", correlationId);
        logger.LogDebug("Middleware: CorrelationIdMiddleware - CorrelationId: {CorrelationId}", correlationId);

        context.Response.OnStarting(() =>
        {
            if (context.Response.Headers.TryGetValue(correlationIdHeaderKey, out _))
                context.Response.Headers.Append(correlationIdHeaderKey, correlationId);

            return Task.CompletedTask;
        });

        context.Items["CorrelationId"] = correlationId;

        await next(context);
    }
}