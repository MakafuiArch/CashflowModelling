using Microsoft.AspNetCore.Diagnostics;

namespace IRR.Application.Exceptions
{
    public class IRRExceptionHandler(ILogger<IRRExceptionHandler> logger): IExceptionHandler
    {
        private readonly ILogger<IRRExceptionHandler> Logger  = logger;

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
            Exception exception, CancellationToken cancellationToken)
        {

            Logger.LogError(exception, exception.Message, cancellationToken);

            var response = new ErrorResponse(StatusCodes.Status500InternalServerError, "Bad Request", exception.Message);

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return true;
        }
    }
}
