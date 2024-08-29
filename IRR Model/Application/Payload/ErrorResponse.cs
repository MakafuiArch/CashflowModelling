namespace IRR.Application.Payload
{
    public record ErrorResponse(

        int StatusCode,
        string Title,
        string ErrorMessage


        )
    {
    }
}
