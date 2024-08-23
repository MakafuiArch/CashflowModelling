using IRR.Infrastructure.Interface;

namespace IRR.Infrastructure
{
    public class StartFactory
    {
        public IStartUp GetStartup(IEnumerable<string> args)
        {

            return args.Contains("--migrate") ? new MigrationStartUp() : new WebApiStartUp();
        }
    }
}
