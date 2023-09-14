using webapi.Models;

namespace webapi.DB;

public class DBInitializer
{
    private TestContext _db;
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVW";
    const int lenght = 10;

    public DBInitializer(TestContext db)
    {
        _db = db;
        InitializePlayerDetails();

    }

    private void InitializePlayerDetails()
    {
        for (int i = 0; i < 5; i++)
        {
            _db.PlayerDetails.Add(new PlayerDetails(RandomString(), Guid.NewGuid().ToString()));
        }
    }

    public string RandomString()
    {
        Random rnd = new Random();
        var randomChars = Enumerable.Repeat(chars, lenght).Select(s => s[rnd.Next(s.Length)]).ToArray();
        return new string(randomChars);
    }
}