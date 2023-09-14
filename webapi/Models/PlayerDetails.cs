using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

[PrimaryKey(nameof(Uuid))]
public class PlayerDetails
{
    public PlayerDetails(string name, string uuid, int score = 0) 
    {
        Name = name;
        Uuid = uuid;
        Score = score;
    }  
    public string Name { get; set; }
    public string Uuid { get; set; }
    public int Score { get; set; }
}
