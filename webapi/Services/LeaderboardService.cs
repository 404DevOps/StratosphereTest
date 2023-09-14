using webapi.Models;
using webapi.Enums;

public interface ILeaderboardService
{
    int GetPlayerScore(string playerId, DateTime fromDate, DateTime toDate);
    List<PlayerDetails> GetPlayerDetailsWithScore();
}

public class LeaderboardService : ILeaderboardService
{
    private readonly TestContext _db;

    public LeaderboardService(TestContext db)
    {
        _db = db;
    }

    public int GetPlayerScore(string playerId, DateTime fromDate, DateTime toDate)
    {
        var scoreActivitiesInDateRange = _db.PlayerActivities.Where(p => p.LogType == ActivityLogType.EARNED_POINTS &&
                                                                 p.Date >= fromDate &&
                                                                 p.Date <= toDate &&
                                                                 p.PlayerId == playerId);

        int result = SumScore(scoreActivitiesInDateRange.ToList());
        return result;
    }

    public List<PlayerDetails> GetPlayerDetailsWithScore()
    {
        List<PlayerDetails> results = new();

        var playerList = _db.PlayerDetails.ToList();
        foreach (var player in playerList)
        {
            player.Score = GetPlayerScore(player.Uuid, DateTime.MinValue, DateTime.MaxValue);
            results.Add(player);
        }
        results = results.OrderByDescending(p => p.Score).ToList();
        return results;
    }

    private int SumScore(List<PlayerActivity> activities)
    {
        int scoreInRange = 0;
        foreach (var activity in activities)
        {
            if (int.TryParse(activity.Data, out int score)) { scoreInRange += score; };
        }
        return scoreInRange;
    }


}