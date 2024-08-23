using Microsoft.EntityFrameworkCore;

namespace IRR.Infrastructure.Interface
{
    public interface IStartUp
    {
        Task StartAsync(string[] args);
    }
}
