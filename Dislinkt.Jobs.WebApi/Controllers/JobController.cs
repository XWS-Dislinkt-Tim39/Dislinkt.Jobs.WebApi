using Dislinkt.Jobs.Application.AddJobOffer.Commands;
using Dislinkt.Jobs.Application.GetAllJobs.Commands;
using Dislinkt.Jobs.Application.GetByUserId;
using Dislinkt.Jobs.Application.SearchJobs.Commands;
using Dislinkt.Jobs.Domain.Jobs;
using Grpc.Net.Client;
using GrpcAddNotificationService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OpenTracing;

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
        private readonly ITracer _tracer;
        /// <summary>
        /// Init of controller
        /// </summary>
        public JobController(IMediator mediator, ITracer tracer)
        {
            _mediator = mediator;
            _tracer = tracer;
        }
        /// <summary>
        /// Add new job offer
        /// </summary>
        /// <returns>Status of publishing job offer</returns>
        /// /// <param name="jobOfferData">for job</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-job-offer")]
        public async Task<bool> AddJobAsync(JobOfferData jobOfferData)
        {
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            await _mediator.Send(new AddJobOfferCommand(jobOfferData));

            var channel = GrpcChannel.ForAddress("https://localhost:5002/");
            var client = new addNotificationGreeter.addNotificationGreeterClient(channel);
            foreach (string item in jobOfferData.followersId)
            {
                var reply = client.addNotification(new NotificationRequest { UserId = item, From = jobOfferData.PublisherId.ToString(), Type = "Job", Seen = false });

                if (!reply.Successful)
                {
                    Debug.WriteLine("Doslo je do greske prilikom kreiranja notifikacija za usera");
                    return false;
                }

                Debug.WriteLine("Uspesno prosledjen na registraciju u notifikacijama -- " + reply.Message);
            }

            return true;

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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
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
            var actionName = ControllerContext.ActionDescriptor.DisplayName;
            using var scope = _tracer.BuildSpan(actionName).StartActive(true);
            return await _mediator.Send(new GetByUserIdCommand(userId));
        }
    }
}
