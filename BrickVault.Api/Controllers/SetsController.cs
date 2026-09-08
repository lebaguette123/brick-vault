using System.Net;
using BrickVault.Api.Services.LegoSets;
using BrickVault.Api.Services.Rebrickable;
using BrickVault.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrickVault.Api.Controllers;

[ApiController]
[Route("api/sets")]
public class SetsController(LegoSetService legoSetService) : ControllerBase
{
    [HttpGet("{setNumber}")]
    public async Task<ActionResult<RebrickableSet>> GetSet(string setNumber)
    {
        try
        {
            var set = await legoSetService.GetSetAsync(setNumber);
            return Ok(set);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
    }

    [HttpGet("search")]
    public async Task<ActionResult<LegoSetSearchResponse>> SearchSets([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Search query cannot be empty.");
        }

        try
        {
            var results = await legoSetService.SearchSetsAsync(query);
            return Ok(results);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound();
        }
    }
}