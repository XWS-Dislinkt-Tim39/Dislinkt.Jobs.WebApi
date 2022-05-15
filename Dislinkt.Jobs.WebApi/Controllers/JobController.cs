using Dislinkt.Jobs.Application.AddJobOffer.Commands;
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
        public async Task<bool> AddPostAsync(JobOfferData jobOfferData)
        {
            return await _mediator.Send(new AddJobOfferCommand(jobOfferData));

        }
    }
}
