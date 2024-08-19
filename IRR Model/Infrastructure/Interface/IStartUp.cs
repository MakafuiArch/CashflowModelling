using Microsoft.EntityFrameworkCore;

namespace CashflowModelling.Infrastructure.Interface
{
    public interface IStartUp
    {
        Task StartAsync(string[] args);
    }
}
