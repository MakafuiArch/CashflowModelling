using IRR.Infrastructure;
using Microsoft.AspNetCore.Hosting.Builder;

public static class Program
{

    public static async Task Main(string[] args)
    {
        var startup = new StartFactory().GetStartup(args);
        await startup.StartAsync(args);

    }
}




