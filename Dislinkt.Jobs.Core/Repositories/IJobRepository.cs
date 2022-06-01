using Dislinkt.Jobs.Domain.Jobs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.Core.Repositories
{
    public interface IJobRepository
    {
        Task AddJobAsync(Job job);
        Task<IReadOnlyList<Job>> SearchJobs(string searchParameter);
        Task<IReadOnlyCollection<Job>> GetAllAsync();
    }
}
