using Microsoft.EntityFrameworkCore;
using webapi.Enums;

namespace webapi.Models;

[PrimaryKey(nameof(Id))]
public class PlayerActivity
{
    public PlayerActivity(string playerId, ActivityLogType logType, string data = "") 
    {
        PlayerId = playerId;
        LogType = logType;
        Data = data;
        Date = DateTime.UtcNow;
    }  
    public int Id { get; set; }
    public string PlayerId { get; set; }
    public ActivityLogType LogType { get; set; }
    public string Data { get; set; }
    public DateTime? Date { get; set; }
}
