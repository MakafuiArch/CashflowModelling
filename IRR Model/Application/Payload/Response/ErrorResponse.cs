namespace IRR.Application.Payload.Response
{
    public record ErrorResponse(

        int StatusCode,
        string Title,
        string ErrorMessage


        )
    {
    }
}
