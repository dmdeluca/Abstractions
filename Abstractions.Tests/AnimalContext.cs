using Microsoft.EntityFrameworkCore;

namespace Abstractions.Tests;

public class AnimalContext : DbContext
{
    public DbSet<Beaver> Beavers => Set<Beaver>();
}
