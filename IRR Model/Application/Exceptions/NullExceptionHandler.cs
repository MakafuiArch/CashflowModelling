using Microsoft.AspNetCore.Diagnostics;

using IRR.Application.Payload.Response;

namespace IRR.Application.Exceptions
{
    public class NullExceptionHandler(ILogger<NullExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<NullExceptionHandler> Logger = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {

            Logger.LogError(exception, exception.Message, cancellationToken);

            var response = new ErrorResponse(StatusCodes.Status500InternalServerError, "Null Object", exception.Message);

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return true;
        }
    }
}
