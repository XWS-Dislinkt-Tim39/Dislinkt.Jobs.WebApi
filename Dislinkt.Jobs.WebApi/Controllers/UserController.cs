using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dislinkt.Jobs.Application.AddUser.Commands;
using Dislinkt.Jobs.Application.AssignSkill.Commands;
using Dislinkt.Jobs.Application.GetJobRecommendations.Commands;
using Dislinkt.Jobs.Application.RemoveSkill.Commands;
using Dislinkt.Jobs.Domain.Jobs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Dislinkt.Jobs.WebApi.Controllers
{
    /// <summary>
    /// Users controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string ApiTag = "Users";
        private readonly IMediator _mediator;

        /// <summary>
        /// Init of controller
        /// </summary>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add new job offer
        /// </summary>
        /// <returns>Status of publishing job offer</returns>
        /// /// <param name="userData">for job</param>
        [HttpPost]
        [SwaggerOperation(Tags = new[] {ApiTag})]
        [Route("/addUser")]
        public async Task<bool> AddUser(UserData userData)
        {
            return await _mediator.Send(new AddUserCommand(userData));
        }

        /// <summary>
        /// Assigns a skill to a user
        /// </summary>
        /// <returns>Status of assigning a skill to a user</returns>
        /// /// <param name="assignSkillData">for job</param>
        [HttpPost]
       
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/assignSkill")]
        public async Task<bool> AssignSkill([FromBody]AssignSkillData assignSkillData)
        {
            return await _mediator.Send(new AssignSkillCommand(assignSkillData));
        }

        /// <summary>
        /// Remove a skill from a user
        /// </summary>
        /// <returns>Status of remove a skill from a user</returns>
        /// /// <param name="assignSkillData">for job</param>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/removeSkill")]
        public async Task<bool> RemoveSkill([FromBody] AssignSkillData assignSkillData)
        {
            return await _mediator.Send(new RemoveSkillCommand(assignSkillData));
        }

        /// <summary>
        /// Recommends jobs for a user
        /// </summary>
        /// <returns>List of recommended jobs</returns>
        /// /// <param name="sourceId">for user</param>
        [HttpGet]
        [Authorize]
        [SwaggerOperation(Tags = new[] { ApiTag })]
        [Route("/getJobRecommendations")]
        public async Task<IReadOnlyList<Job>> GetJobRecommendations(Guid sourceId)
        {
            return await _mediator.Send(new GetJobRecommendationsCommand(sourceId));
        }

    }
}
