﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using YngStrs.Chatbot.Api.BoundedContexts.UserAnswers.Commands;
using YngStrs.Chatbot.Api.Domain.Entities;
using YngStrs.Common.Api;
using YngStrs.Common.Hateoas.Core;

namespace YngStrs.Chatbot.Api.Controllers
{
    /// <summary>
    /// A controller responsible for Chat-bot functionality.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ChatbotController : ApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatbotController"/> class.
        /// </summary>
        /// <param name="resourceMapper"></param>
        /// <param name="mediator"></param>
        public ChatbotController(
            IResourceMapper resourceMapper,
            IMediator mediator)
            : base(resourceMapper, mediator)
        {
        }

        /// <summary>
        /// Creates new events for aggregates:
        /// <see cref="UserAnswers"/> and
        /// <see cref="UserPersonalData"/>.
        /// </summary>
        /// <param name="command"></param>
        /// <response code="201">User answers saved.</response>
        /// <response code="400">Could not parse answers or email or name.</response>
        [HttpPost("save-results", Name = nameof(SaveUserResults))]
        public async Task<IActionResult> SaveUserResults([FromBody] SaveUserAnswers command) =>
            (await Mediator.Send(command))
            .Match(
                some: _ => CreatedAtAction(nameof(SaveUserResults), null),
                none: Error);
    }
}