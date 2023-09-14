using Microsoft.EntityFrameworkCore;
using webapi.Models;

public class TestContext : DbContext 
{
    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    { 
        Database.EnsureCreated();
    }

    public TestContext() { }

    public virtual DbSet<PlayerDetails> PlayerDetails => Set<PlayerDetails>();
    public virtual DbSet<PlayerActivity> PlayerActivities => Set<PlayerActivity>();
}