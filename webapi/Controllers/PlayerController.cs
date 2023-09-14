using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using webapi.Models;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private TestContext _db;
    private LeaderboardService _leaderboardService;
    private IMemoryCache _cache;
    const string LeaderboardCacheKey = "LeaderBoardCache";

    public PlayerController(TestContext db, LeaderboardService leaderboardService, IMemoryCache cache)
    {
        _db = db;
        _leaderboardService = leaderboardService;
        _cache = cache;
    }

    [HttpGet()]
    [Route("{uuid}")]
    public ActionResult<PlayerDetails> Get(string uuid)
    {
        var result = _db.PlayerDetails.FirstOrDefault(p => p.Uuid == uuid);
        if (result != null)
        {
            return Ok(result);
        }

        return NotFound();
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<PlayerDetails>> GetAll()
    {
        return Ok(_db.PlayerDetails.OrderByDescending(p => p.Score).ToList());
    }

    [HttpGet]
    [Route("GetLeaderboard")]
    public ActionResult<List<PlayerDetails>> GetLeaderboard()
    {
        // Try to get the leaderboard from cache
        if (!_cache.TryGetValue(LeaderboardCacheKey, out List<PlayerDetails> leaderboard))
        {
            // If it's not in the cache, fetch it from your service
            leaderboard = _leaderboardService.GetPlayerDetailsWithScore();

            // Set the leaderboard in the cache with a sliding expiration of 1 minute
            _cache.Set(LeaderboardCacheKey, leaderboard, TimeSpan.FromMinutes(1));
        }

        return Ok(leaderboard);
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create([FromBody] string name)
    {
        if (_db.PlayerDetails.FirstOrDefault(p => p.Name == name) != null)
        {
            return BadRequest("Player with this Name already exists.");
        }

        PlayerDetails playerDetail = new PlayerDetails(name, Guid.NewGuid().ToString());
        _db.PlayerDetails.Add(playerDetail);
        _db.SaveChanges();

        return Ok(playerDetail);
    }
}
