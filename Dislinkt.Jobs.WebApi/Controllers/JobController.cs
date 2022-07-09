using Dislinkt.Jobs.Application.AddJobOffer.Commands;
using Dislinkt.Jobs.Application.GetAllJobs.Commands;
using Dislinkt.Jobs.Application.GetByUserId;
using Dislinkt.Jobs.Application.SearchJobs.Commands;
using Dislinkt.Jobs.Domain.Jobs;
using Grpc.Net.Client;
using GrpcAddActivityService;
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
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/add-job-offer")]
        public async Task<bool> AddJobAsync(JobOfferData jobOfferData)
        {
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

            var channel2 = GrpcChannel.ForAddress("https://localhost:5003/");
            var client2 = new addActivityGreeter.addActivityGreeterClient(channel2);
            var reply2 = client2.addActivity(new ActivityRequest { UserId = jobOfferData.PublisherId.ToString(), Text = "Created job offer", Type = "Job", Date = DateTime.Now.AddHours(2).ToString() });

            if (!reply2.Successful)
            {
                Debug.WriteLine("Doslo je do greske prilikom kreiranja eventa za admina");
                return false;
            }

            Debug.WriteLine("Uspesno prosledjen na dashboard kod admina-- " + reply2.Message);


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
