namespace IRR.Application.Exceptions
{
    public record ErrorResponse(
        
        int StatusCode, 
        string Title, 
        string ErrorMessage
        
        
        )
    {
    }
}
