using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Data.SqlClient;

namespace IRR.Application.Exceptions
{
    public class SQLExceptionHandler(ILogger<IRRExceptionHandler> logger) : IExceptionHandler
    
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
            Exception exception, CancellationToken cancellationToken)
        {


            if(exception is SqlException) {

                logger.LogError(exception, exception.Message, cancellationToken);

                var response = new ErrorResponse(StatusCodes.Status500InternalServerError, "Bad Request", exception.Message);

                await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                return true;

            }

            return false;
           
        }




    }
}
