namespace Presentation.WebAPI.Middlewares;

public class OtherMiddleware(RequestDelegate next)
{
   public async Task Invoke(HttpContext context, ILogger<OtherMiddleware> logger)
   {
      var correlationId = context.Request.Headers["X-Correlation-Id"];
      
      NLog.ScopeContext.PushProperty("CorrelationId", correlationId);
      logger.LogInformation("Middleware: OtherMiddleware - Request ({CorrelationId}): {Request}", correlationId, context.Request.Path);
      
      await next(context);
   }
}