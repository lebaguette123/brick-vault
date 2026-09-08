using BrickVault.Api.Services.Rebrickable;
using Microsoft.AspNetCore.Mvc;

namespace BrickVault.Api.Controllers;

[ApiController]
[Route("api/sets")]
public class SetsController : ControllerBase
{
    private readonly RebrickableClient _rebrickableClient;

    public SetsController(RebrickableClient rebrickableClient)
    {
        _rebrickableClient = rebrickableClient;
    }

    [HttpGet("{setNumber}")]
    public async Task<ActionResult<RebrickableSet>> GetSet(string setNumber)
    {
        var set = await _rebrickableClient.GetSetAsync(setNumber);
        return Ok(set);
    }
}