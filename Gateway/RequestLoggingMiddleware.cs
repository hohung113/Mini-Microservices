namespace Gateway
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next , ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;        
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Response.StatusCode == 429) 
            {
                _logger.LogWarning("Rate limit exceeded for client: {ClientId} at {Time}", context.Request.Headers["X-Client-Id"], DateTime.Now);
            }
            var requestTime = DateTime.UtcNow;
            var method = context.Request.Method;
            var path = context.Request.Path;
            _logger.LogWarning($"Request received at {requestTime:yyyy-MM-dd HH:mm:ss} - Method: {method} - Path: {path}");
            await _next(context);
        }
    }
}
