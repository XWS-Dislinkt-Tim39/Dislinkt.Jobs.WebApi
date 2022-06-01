using Dislinkt.Jobs.Application.AddJobOffer.Commands;
using Dislinkt.Jobs.Application.GetAllJobs.Commands;
using Dislinkt.Jobs.Application.GetByUserId;
using Dislinkt.Jobs.Application.SearchJobs.Commands;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dislinkt.Jobs.WebApi.Controllers
{
    /// <summary>
    /// Jobs controler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private const string ApiTag = "Jobs";
        private readonly IMediator _mediator;
        /// <summary>
        /// Init of controller
        /// </summary>
        public JobController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add new job offer
        /// </summary>
        /// <returns>Status of publishing job offer</returns>
        /// /// <param name="jobOfferData">for job</param>
        [HttpPost]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-job-offer")]
        public async Task<bool> AddJobAsync(JobOfferData jobOfferData)
        {
            return await _mediator.Send(new AddJobOfferCommand(jobOfferData));

        }
        /// <summary>
        /// Search job offer
        /// </summary>
        /// <returns>Jobs</returns>
        /// /// <param name="searchParameter">for job</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/search-job")]
        public async Task<IReadOnlyList<Job>> SearchJobAsync(string searchParameter)
        {
            return await _mediator.Send(new SearchJobsCommand(searchParameter));

        }

        /// <summary>
        /// Get all jobs
        /// </summary>
        /// <returns>Get all jobs</returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-all-jobs")]
        public async Task<IReadOnlyCollection<Job>> GetAllJobsAsync()
        {
            return await _mediator.Send(new GetAllJobsCommand());
        }

        /// <summary>
        /// Get jobs by user
        /// </summary>
        /// <returns>Get user jobs</returns>
        /// /// <param name="userId">for job</param>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/get-user-jobs")]
        public async Task<IReadOnlyCollection<Job>> GetUserJobsAsync(Guid userId)
        {
            return await _mediator.Send(new GetByUserIdCommand(userId));
        }
    }
}
