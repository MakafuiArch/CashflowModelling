
using IRR.Infrastructure;

public static class Program
{

    public static async Task Main(string[] args)
    {
        var startup = new StartFactory().GetStartup(args);
        await startup.StartAsync(args);

    }
}




