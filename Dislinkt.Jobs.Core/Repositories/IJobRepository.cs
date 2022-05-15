using Dislinkt.Jobs.Domain.Jobs;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Core.Repositories
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
    }
}
