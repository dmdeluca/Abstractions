using Microsoft.EntityFrameworkCore;

namespace DataLayerAbstractions.Tests;

public class AnimalContext : DbContext
{
    public DbSet<Beaver> Beavers => Set<Beaver>();
}
