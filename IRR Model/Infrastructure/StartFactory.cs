using CashflowModelling.Infrastructure.Interface;

namespace CashflowModelling.Infrastructure
{
    public class StartFactory
    {
        public IStartUp GetStartup(IEnumerable<string> args)
        {

            return args.Contains("--migrate") ? new MigrationStartUp() : new WebApiStartUp();
        }
    }
}
