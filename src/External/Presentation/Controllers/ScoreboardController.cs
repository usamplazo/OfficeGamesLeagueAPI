using Application.Scoreboards.Commands.CreateScoreboard;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Controllers;

[Route("api/scoreboards")]
public sealed class ScoreboardController : ApiController
{
    public ScoreboardController(ISender sender) 
        : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> RegisterScoreboard(CancellationToken cancellationToken)
    {
        //scoreboardId should be guid and not hardcoded
        var command = new CreateScoreboardCommand(
            new Guid()
            , new Guid()
            , new Guid()
            , int.Parse(DateTime.Now.ToString("yyyymmdd"))
            , DateTime.Now
            , DateTime.Now.AddMinutes(15));

        var result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
